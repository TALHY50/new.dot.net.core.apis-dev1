using Microsoft.AspNetCore.Builder;
using SharedKernel.Main.Infrastructure.MiddleWares;

namespace SharedKernel.Main.Infrastructure;

public static class SharedKernelInfrastructureApplicationBuilder
{
    public static IApplicationBuilder UseSharedKernelInfrastructure(this IApplicationBuilder app)
    {
        app.UseSharedKernelMiddlewares();

        return app;
    }
}