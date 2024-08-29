using Notification.App.Presentation.Mapping;

namespace Notification.App.Presentation;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        return services;
    }

}