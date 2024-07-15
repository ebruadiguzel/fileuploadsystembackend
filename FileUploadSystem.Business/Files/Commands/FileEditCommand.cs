using AutoMapper;
using FileUploadSystem.Domain.Repositories.Files;
using MediatR;

namespace FileUploadSystem.Business.Files.Commands;

public class FileEditCommand : IRequest<FileEditResponse>
{
    public Guid Id { get; set; }
    public string NewName { get; set; }

    public class FileEditHandler : IRequestHandler<FileEditCommand, FileEditResponse>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileEditHandler(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<FileEditResponse> Handle(FileEditCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetAsync(x => x.Id.Equals(request.Id),
                cancellationToken: cancellationToken);

            if (file is not null)
            {
                var extension = Path.GetExtension(file.Path);
                var destinationFilePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads",
                    string.Concat(request.NewName, extension));

                File.Move(file.Path, destinationFilePath);
                file.Name = request.NewName;
                file.Path = destinationFilePath;
                file.UpdatedDate = DateTime.UtcNow;

                await _fileRepository.UpdateAsync(file, cancellationToken);
            }

            return _mapper.Map<FileEditResponse>(file);
        }
    }
}