using System.Security.Claims;
using FileUploadSystem.Business.FileShares.Services;
using FileUploadSystem.Domain.Repositories.Files;
using MediatR;
using Microsoft.AspNetCore.Http;
using File = FileUploadSystem.Domain.Entities.Files.File;

namespace FileUploadSystem.Business.Files.Commands;

public class FileUploadCommand : IRequest<FileUploadResponse>
{
    public IFormFile File { get; set; }

    public class FileUploadHandler : IRequestHandler<FileUploadCommand, FileUploadResponse>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IFileShareService _fileShareService;

        public FileUploadHandler(IFileRepository fileRepository, IHttpContextAccessor contextAccessor,
            IFileShareService fileShareService)
        {
            _fileRepository = fileRepository;
            _contextAccessor = contextAccessor;
            _fileShareService = fileShareService;
        }

        public async Task<FileUploadResponse> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            if (request.File is not null && request.File.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);
                var filePath = Path.Combine(uploadPath, request.File.FileName);

                await using var stream = new FileStream(filePath, FileMode.Create);
                await request.File.CopyToAsync(stream, cancellationToken);

                var userId = _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(a => a.Type.Equals(ClaimTypes.UserData))!.Value;

                var fileEntity = new File
                {
                    Path = filePath,
                    Name = request.File.Name,
                    UploadDate = DateTime.UtcNow
                };

                var file = await _fileRepository.AddAsync(fileEntity, cancellationToken);

                await _fileShareService.Add(file.Id, Guid.Parse(userId));

                return new FileUploadResponse()
                {
                    Name = file.Name,
                    Path = file.Path,
                    UploadDate = file.UploadDate
                };
            }

            throw new Exception("File cannot be empty.");
        }
    }
}