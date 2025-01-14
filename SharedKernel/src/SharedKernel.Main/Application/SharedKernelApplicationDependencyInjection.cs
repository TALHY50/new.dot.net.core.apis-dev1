using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Behaviours;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Application;

public static class SharedKernelApplicationDependencyInjection
{
    public static IServiceCollection AddSharedKernelApplication(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => !assembly.IsDynamic && assembly.GetName().Name != null)
            .ToArray();
        
        foreach(var assembly in assemblies)
        {
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(assembly); //typeof(DependencyInjection).Assembly
                //options.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
                //options.AddOpenBehavior(typeof(LoggingBehaviour<>));
                options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                options.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
                options.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
            });
            //container.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
        }
        //services.AddSingleton<IIdentity, Jwt>();
        services.AddScoped<ICurrentUser, CurrentUser>();
        return services;
    }
}