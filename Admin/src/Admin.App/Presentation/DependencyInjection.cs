using System.Reflection;
using Mapster;
using MapsterMapper;

namespace Admin.App.Presentation;
using SharedDependencyInjection = SharedKernel.Main.Presentation.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        SharedDependencyInjection.AddPresentation(services);
        services.AddMappings();

        return services;
    }
    
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}