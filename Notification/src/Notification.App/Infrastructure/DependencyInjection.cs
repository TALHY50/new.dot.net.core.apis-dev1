namespace Notification.App.Infrastructure;
using SharedInfrastructureDependencyInjection = SharedKernel.Main.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        SharedInfrastructureDependencyInjection.AddInfrastructure(services);
        return services;
    }
    
    public static IApplicationBuilder AddInfrastructure(this IApplicationBuilder app)
    {
        SharedInfrastructureDependencyInjection.AddInfrastructure(app);

        return app;
    }
}