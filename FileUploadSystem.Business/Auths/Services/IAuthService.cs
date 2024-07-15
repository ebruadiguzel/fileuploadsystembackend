namespace FileUploadSystem.Business.Auths.Services;

public interface IAuthService
{
    string GenerateToken(string email, Guid userId);
}