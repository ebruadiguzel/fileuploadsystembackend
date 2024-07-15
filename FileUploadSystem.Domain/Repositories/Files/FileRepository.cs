using FileUploadSystem.Domain.Contexts;
using FileUploadSystem.Domain.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using File = FileUploadSystem.Domain.Entities.Files.File;

namespace FileUploadSystem.Domain.Repositories.Files;

public class FileRepository : GenericRepository<File> , IFileRepository
{
    public FileRepository(BaseDbContext dbContext) : base(dbContext)
    {
        
    }
}