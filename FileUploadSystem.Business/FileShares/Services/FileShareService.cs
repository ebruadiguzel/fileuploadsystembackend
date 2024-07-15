using FileUploadSystem.Domain.Repositories.FileShares;
using FileShare = FileUploadSystem.Domain.Entities.FileShares.FileShare;

namespace FileUploadSystem.Business.FileShares.Services;

public class FileShareService : IFileShareService
{
    private readonly IFileShareRepository _fileShareRepository;

    public FileShareService(IFileShareRepository fileShareRepository)
    {
        _fileShareRepository = fileShareRepository;
    }

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="fileId"></param>
    /// <param name="userId"></param>
    public async Task Add(Guid fileId, Guid userId)
    {
        var fileShareEntity = new FileShare();
        fileShareEntity.FileId = fileId;
        fileShareEntity.UserId = userId;

        await _fileShareRepository.AddAsync(fileShareEntity);
    }
    
    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="fileId"></param>
    public async Task DeleteByFileIdAsync(Guid fileId)
    {
        var fileShares =  _fileShareRepository.GetList(a => a.FileId == fileId);
        foreach (var fileShare in fileShares)
            await _fileShareRepository.DeleteAsync(fileShare);
    }
}