using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ACL.Business.Infrastructure.Persistence;

public class DependencyInjection
{
    public static IServiceCollection AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}