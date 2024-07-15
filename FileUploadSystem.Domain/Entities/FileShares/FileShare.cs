namespace FileUploadSystem.Domain.Entities.FileShares;

public class FileShare : BaseEntity
{
    public Guid FileId { get; set; }
    public Guid UserId { get; set; }
}