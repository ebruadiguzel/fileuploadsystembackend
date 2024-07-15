using FileUploadSystem.Business.FileShares.Services;
using FileUploadSystem.Domain.Repositories.Files;
using FileUploadSystem.Domain.Repositories.Users;
using MediatR;

namespace FileUploadSystem.Business.Files.Commands;

public class FileDeleteCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    
    public class FileDeleteHandler : IRequestHandler<FileDeleteCommand, bool>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileShareService _fileShareService;
        public FileDeleteHandler(IFileRepository fileRepository, IFileShareService fileShareService)
        {
            _fileRepository = fileRepository;
            _fileShareService = fileShareService;
        }
        
        public async Task<bool> Handle(FileDeleteCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetAsync(a => a.Id == request.Id, cancellationToken : cancellationToken);
            if (file is not null)
            {
                await _fileRepository.DeleteAsync(file, cancellationToken: cancellationToken);
                await _fileShareService.DeleteByFileIdAsync(file.Id);
                return true;
            }
            else
                throw new Exception("File not found");
        }
    }
}

