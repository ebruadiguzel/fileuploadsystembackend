using System.Linq.Expressions;
using FileUploadSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace FileUploadSystem.Domain.Repositories.Generic;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: BaseEntity
{
    private readonly DbContext _dbContext;
    public GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<TEntity> Query() => (IQueryable<TEntity>) _dbContext.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default (CancellationToken))
    {
        EntityEntry<TEntity> entityEntry = await _dbContext.AddAsync<TEntity>(entity, cancellationToken);
        int num = await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    
    public async Task<ICollection<TEntity>> AddRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default (CancellationToken))
    {
        await _dbContext.AddRangeAsync((IEnumerable<object>) entities, cancellationToken);
        int num = await _dbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }
    
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default (CancellationToken))
    {
        entity.UpdatedDate = DateTime.UtcNow;
        _dbContext.Update<TEntity>(entity);
        int num = await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> DeleteAsync(
        TEntity entity,
        bool permanent = false,
        CancellationToken cancellationToken = default (CancellationToken))
    {
        entity.DeletedDate = DateTime.UtcNow;;
        int num = await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    
    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default (CancellationToken))
    {
        IQueryable<TEntity> source = this.Query();
        if (!enableTracking)
            source = source.AsNoTracking<TEntity>();
        if (include != null)
            source = (IQueryable<TEntity>) include(source);
        if (withDeleted)
            source = source.IgnoreQueryFilters<TEntity>();
        return await source.FirstOrDefaultAsync<TEntity>(predicate, cancellationToken);
    }
    
    public IQueryable<TEntity> GetList(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default (CancellationToken))
    {
        IQueryable<TEntity> source = this.Query();
        if (!enableTracking)
            source = source.AsNoTracking<TEntity>();
        if (include != null)
            source = (IQueryable<TEntity>) include(source);
        if (withDeleted)
            source = source.IgnoreQueryFilters<TEntity>();
        return source.Where(predicate).AsQueryable();
    }
    
    
}


