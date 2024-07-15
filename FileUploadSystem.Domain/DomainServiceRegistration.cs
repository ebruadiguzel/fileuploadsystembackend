using FileUploadSystem.Domain.Contexts;
using FileUploadSystem.Domain.Repositories.Files;
using FileUploadSystem.Domain.Repositories.FileShares;
using FileUploadSystem.Domain.Repositories.Generic;
using FileUploadSystem.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploadSystem.Domain;

public static class DomainServiceRegistration
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IFileRepository, FileRepository>();
        services.AddTransient<IFileShareRepository, FileShareRepository>();

        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("BaseDb")));
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}