using System.Security.Cryptography;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using ACL.Business.Infrastructure.Security;
using Admin.App.Application.Features.Corridors;
using Admin.App.Application.Features.Currencies;
using Admin.App.Application.Features.Payers;
using Admin.App.Application.Features.Providers;
using Admin.App.Application.Features.Regions;
using Admin.App.Application.Features.TransactionTypes;
using Admin.App.Infrastructure.Persistence;

namespace Admin.App.Infrastructure;

public static class AdminInfrastructureDependencyInjection
{
    public static IServiceCollection AddAdminInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        services.AddAdminPersistence(configuration);
        return services;
    }

}