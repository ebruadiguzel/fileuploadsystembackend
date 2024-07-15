using FileUploadSystem.Domain.Contexts;
using FileUploadSystem.Domain.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using FileShare = FileUploadSystem.Domain.Entities.FileShares.FileShare;

namespace FileUploadSystem.Domain.Repositories.FileShares;

public class FileShareRepository : GenericRepository<FileShare> , IFileShareRepository
{
    public FileShareRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }
}