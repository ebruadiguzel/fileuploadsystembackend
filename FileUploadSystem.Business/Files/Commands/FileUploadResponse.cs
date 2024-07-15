namespace FileUploadSystem.Business.Files.Commands;

public class FileUploadResponse
{
    public string Path { get; set; }
    public string Name { get; set; }
    public DateTime UploadDate { get; set; }
}