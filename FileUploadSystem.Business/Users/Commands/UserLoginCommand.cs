using FileUploadSystem.Business.Auths.Services;
using FileUploadSystem.Domain.Repositories.Users;
using FileUploadSystem.Infrastructure.Helpers;
using MediatR;

namespace FileUploadSystem.Business.Users.Commands;

public class UserLoginCommand : IRequest<UserLoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public UserLoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

   public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand,UserLoginResponse>
   {
       private readonly IUserRepository _userRepository;
       private readonly IAuthService _authService;
       public UserLoginCommandHandler(IUserRepository userRepository, IAuthService authService)
       {
           _userRepository = userRepository;
           _authService = authService;
       }
       
       public async Task<UserLoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
       {
           var user = await _userRepository.GetAsync(x => x.Email.Equals(request.Email) && x.Password.Equals(request.Password), cancellationToken:cancellationToken);
           if (user is null)
           {
               throw new Exception("User information invalid.");
           }

           var token = _authService.GenerateToken(request.Email, user.Id);

           return new UserLoginResponse()
           {
               Token = token
           };
       }
   }
}