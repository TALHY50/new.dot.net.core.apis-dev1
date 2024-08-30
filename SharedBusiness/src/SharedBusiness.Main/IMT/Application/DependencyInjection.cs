using Microsoft.Extensions.DependencyInjection;

namespace SharedBusiness.Main.IMT.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}