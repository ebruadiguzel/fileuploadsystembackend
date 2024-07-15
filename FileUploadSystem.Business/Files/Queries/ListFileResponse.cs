namespace FileUploadSystem.Business.Files.Queries;

public class ListFileResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public DateTime UploadedDate { get; set; }
}