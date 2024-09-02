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