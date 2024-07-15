using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Notification.RazorTemplateEngine.Services;

namespace Notification.RazorTemplateEngine;

public static class DependencyInjection
{
    public static IServiceCollection AddRazorEngine(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMvcCore().AddRazorViewEngine();
        services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(o =>
        {
            o.ViewLocationFormats.Add("/Views/{0}" + Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewExtension);

            // o.FileProviders.Add(new Microsoft.Extensions.FileProviders.PhysicalFileProvider(AppContext.BaseDirectory));
        });

        // services.AddRazorPages();
        services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
        services.AddTransient<ITemplateExecutionEngine, RazorTemplateExecutionEngine>();

        return services;
    }
}