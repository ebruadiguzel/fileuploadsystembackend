namespace FileUploadSystem.Business.FileShares.Services;

public interface IFileShareService
{
    Task Add(Guid fileId, Guid userId);

    Task DeleteByFileIdAsync(Guid fileId);
}