using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Infrastructure.MiddleWares;

namespace SharedKernel.Main.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
    
    public static IApplicationBuilder AddInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
        return app;
    }
}