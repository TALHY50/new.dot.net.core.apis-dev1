using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.Common.Infrastructure.Persistence;

namespace SharedBusiness.Main.Common.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();
        return services;
    }
}