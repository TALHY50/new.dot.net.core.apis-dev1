using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Main.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}