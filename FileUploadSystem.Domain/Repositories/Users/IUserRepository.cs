using FileUploadSystem.Domain.Entities.Users;
using FileUploadSystem.Domain.Repositories.Generic;

namespace FileUploadSystem.Domain.Repositories.Users;

public interface IUserRepository : IGenericRepository<User>
{
    
}