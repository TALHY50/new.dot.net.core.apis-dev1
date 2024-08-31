using FluentValidation;
using SharedKernel.Main.Application.Common.Behaviours;

namespace Admin.App.Application;

public static class AdminApplicationDependencyInjection
{
    public static IServiceCollection AddAdminApplication(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        return services;
    }
}