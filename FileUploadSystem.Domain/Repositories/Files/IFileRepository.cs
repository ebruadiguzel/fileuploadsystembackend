using FileUploadSystem.Domain.Repositories.Generic;
using File = FileUploadSystem.Domain.Entities.Files.File;

namespace FileUploadSystem.Domain.Repositories.Files;

public interface IFileRepository : IGenericRepository<File>
{
    
}