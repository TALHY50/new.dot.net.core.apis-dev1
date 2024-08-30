using Microsoft.Extensions.DependencyInjection;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services;
    }
    
}