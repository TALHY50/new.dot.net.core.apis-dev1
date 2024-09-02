using Microsoft.Extensions.DependencyInjection;

namespace SharedBusiness.Main.Admin.Infrastructure.Persistence;

public static class SharedBusinessAdminPersistenceDependencyInjection
{
    public static IServiceCollection AddPersistence(IServiceCollection services)
    {
        return services;
    }
    
}