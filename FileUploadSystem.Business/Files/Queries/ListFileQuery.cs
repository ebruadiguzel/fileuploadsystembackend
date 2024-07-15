using System.Security.Claims;
using FileUploadSystem.Domain.Repositories.Files;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FileUploadSystem.Business.Files.Queries;

public class ListFileQuery : IRequest<List<ListFileResponse>>
{
    public string? Name { get; set; }
    public DateTime UploadedDate { get; set; }
    
    public class ListFileHandler : IRequestHandler<ListFileQuery, List<ListFileResponse>>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public ListFileHandler(IFileRepository fileRepository, IHttpContextAccessor contextAccessor)
        {
            _fileRepository = fileRepository;
            _contextAccessor = contextAccessor;
        }
        
        public async Task<List<ListFileResponse>> Handle(ListFileQuery request, CancellationToken cancellationToken)
        {
            // var userId = Guid.Parse(_contextAccessor.HttpContext.User.Claims
            //     .FirstOrDefault(a => a.Type.Equals(ClaimTypes.UserData)).Value);

            var filesQuery = _fileRepository.Query()
                .Include(a => a.FileShares)
                .Where(a => true);

            if (request.Name is not null)
                filesQuery = filesQuery.Where(a =>
                    a.Name.Contains(request.Name));
            
            if (request.UploadedDate != default)
                 filesQuery = filesQuery.Where(a => a.UploadDate.Date.Equals(request.UploadedDate));
            
            return await filesQuery.Select(a => new ListFileResponse()
            {
                Id = a.Id,
                Name = a.Name,
                UploadedDate = a.UploadDate,
                Path = a.Path
            }).ToListAsync(cancellationToken);
        }
    }
}