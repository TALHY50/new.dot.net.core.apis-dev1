using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Common.Behaviours;

namespace SharedBusiness.Main.Common.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(Admin.Application.DependencyInjection).Assembly);

            options.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            options.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
            options.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(Admin.Application.DependencyInjection));
        return services;
    }
}
