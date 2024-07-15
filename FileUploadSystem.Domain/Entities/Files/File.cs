using System.ComponentModel.DataAnnotations.Schema;
using FileUploadSystem.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FileShare = FileUploadSystem.Domain.Entities.FileShares.FileShare;

namespace FileUploadSystem.Domain.Entities.Files;

/// <summary>
/// File
/// </summary>
public class File : BaseEntity
{
    public string Name { get; set; }
    public string Path { get; set; }
    public DateTime UploadDate { get; set; }
    
    [ForeignKey("FileId")]
    public virtual List<FileShare> FileShares { get; set; }

}

public class FileConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.ToTable("Files").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");
    }
    
}