using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.IMT.Infrastructure.Persistence;

namespace SharedBusiness.Main.IMT.Infrastructure;

public static class SharedBusinessIMTInfrastructureDependencyInjection
{
    public static IServiceCollection AddSharedBusinessIMTInfrastructure(this IServiceCollection services)
    {
        services.AddSharedBusinessIMTPersistence();
        return services;
    }
    
}