using System.Reflection;
using FileUploadSystem.Domain.Entities.Files;
using FileUploadSystem.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace FileUploadSystem.Domain.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
      
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.ApplyConfiguration(new FileConfiguration());
        
        
    }
    
    public DbSet<User> Users { get; set; }
}