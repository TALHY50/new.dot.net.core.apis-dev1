using System.Reflection;

using Mapster;

using MapsterMapper;

using Microsoft.Extensions.DependencyInjection;

namespace Notification.App.Presentation.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}