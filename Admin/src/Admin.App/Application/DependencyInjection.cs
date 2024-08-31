using FluentValidation;
using SharedKernel.Main.Application.Common.Behaviours;

namespace Admin.App.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        SharedKernel.Main.Application.DependencyInjection.AddApplication(services);

        SharedBusiness.Main.DependencyInjection.AddApplication(services);

        services.AddValidatorsFromAssembly(typeof(App.DependencyInjection).Assembly);

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(App.DependencyInjection).Assembly);

            options.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            options.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
            options.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
        });

        return services;
    }
}