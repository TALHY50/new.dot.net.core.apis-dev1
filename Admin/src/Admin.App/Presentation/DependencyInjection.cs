namespace Admin.App.Presentation;
using SharedDependencyInjection = SharedKernel.Main.Presentation.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        SharedDependencyInjection.AddPresentation(services);

        return services;
    }
}