using Microsoft.Extensions.DependencyInjection;

namespace ACL.Bussiness.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}