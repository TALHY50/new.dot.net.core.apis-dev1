using Microsoft.AspNetCore.Builder;

namespace SharedKernel.Main.Infrastructure.MiddleWares;

public static class SharedKernelAddMiddleWares
{

    public static IApplicationBuilder UseSharedKernelMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<HttpMiddleware>();
        return app;

    }
    
}