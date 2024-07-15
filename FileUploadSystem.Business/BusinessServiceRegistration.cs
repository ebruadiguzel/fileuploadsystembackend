using System.Reflection;
using FileUploadSystem.Business.Auths.Services;
using FileUploadSystem.Business.FileShares.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploadSystem.Business;

/// <summary>
/// BusinessServiceRegistration
/// </summary>
public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());        
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IFileShareService, FileShareService>();
        

        return services;

    }
}