using Notification.App.Presentation.Mapping;
using SharedDependencyInjection = SharedKernel.Main.Presentation.DependencyInjection;

namespace Notification.App.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        SharedDependencyInjection.AddSharedKernelPresentation(services);
        services.AddControllers();
        services.AddMappings();
        return services;
    }

}