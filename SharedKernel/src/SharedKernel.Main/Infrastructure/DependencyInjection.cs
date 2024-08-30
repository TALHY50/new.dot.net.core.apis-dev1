using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.MiddleWares;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IGuardAgainstNullUpdate, GuardAgainstNullUpdate>();
        return services;
    }
    
    public static IApplicationBuilder AddInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
        return app;
    }
}