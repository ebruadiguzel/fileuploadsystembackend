using FileUploadSystem.Domain.Repositories.Generic;
using FileShare = FileUploadSystem.Domain.Entities.FileShares.FileShare;

namespace FileUploadSystem.Domain.Repositories.FileShares;

public interface IFileShareRepository : IGenericRepository<FileShare>
{
    
}