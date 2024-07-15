using AutoMapper;
using FileUploadSystem.Business.Files.Commands;
using File = FileUploadSystem.Domain.Entities.Files.File;

namespace FileUploadSystem.Business.Files.Profiles;

public class FileMapper : Profile
{
    public FileMapper()
    {
        CreateMap<File, FileEditResponse>();
    }
}