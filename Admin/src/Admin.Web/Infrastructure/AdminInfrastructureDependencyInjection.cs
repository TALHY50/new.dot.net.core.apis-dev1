using System.Security.Cryptography;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using ACL.Business.Infrastructure.Security;
using Admin.Web.Application.Features.Payers;
using Admin.Web.Infrastructure.Persistence;

namespace Admin.Web.Infrastructure;

public static class AdminInfrastructureDependencyInjection
{
    public static IServiceCollection AddAdminInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        services.AddAdminPersistence(configuration);
        return services;
    }

}