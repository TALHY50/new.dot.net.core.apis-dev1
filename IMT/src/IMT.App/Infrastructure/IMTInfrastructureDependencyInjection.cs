using IMT.App.Infrastructure.Persistence;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure;

public static class IMTInfrastructureDependencyInjection
{
    public static IServiceCollection AddIMTInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIMTPersistence(configuration);
        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        return services;
    }
}