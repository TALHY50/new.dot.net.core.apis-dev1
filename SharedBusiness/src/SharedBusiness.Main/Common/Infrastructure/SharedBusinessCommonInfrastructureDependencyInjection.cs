using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.Common.Infrastructure.Persistence;

namespace SharedBusiness.Main.Common.Infrastructure;

public static class SharedBusinessCommonInfrastructureDependencyInjection
{
    public static IServiceCollection AddSharedBusinessCommonInfrastructure(this IServiceCollection services)
    {
        services.AddSharedBusinessCommonPersistence();
        return services;
    }
}