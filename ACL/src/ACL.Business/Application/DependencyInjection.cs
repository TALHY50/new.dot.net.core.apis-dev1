using Microsoft.Extensions.DependencyInjection;

namespace ACL.Business.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}