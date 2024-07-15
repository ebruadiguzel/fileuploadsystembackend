using FileUploadSystem.Domain.Contexts;
using FileUploadSystem.Domain.Entities.Users;
using FileUploadSystem.Domain.Repositories.Generic;

namespace FileUploadSystem.Domain.Repositories.Users;

/// <summary>
/// UserRepository
/// </summary>
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BaseDbContext dbContext) : base(dbContext)
    {
        
    }
}