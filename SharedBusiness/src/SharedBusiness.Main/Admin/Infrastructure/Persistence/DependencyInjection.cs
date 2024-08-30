using Microsoft.Extensions.DependencyInjection;

namespace SharedBusiness.Main.Admin.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(IServiceCollection services)
    {
        return services;
    }
    
}