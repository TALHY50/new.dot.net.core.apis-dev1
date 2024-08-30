using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.IMT.Infrastructure.Persistence;

namespace SharedBusiness.Main.IMT.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();
        return services;
    }
    
}