using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

namespace FileUploadSystem.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}