using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using View.App.Services;

namespace Notification.Renderer;

public static class DependencyInjection
{
    public static IServiceCollection AddRazorEngine(this IServiceCollection services, IConfiguration configuration)
    {
        var fileProvider = new EmbeddedFileProvider(typeof(View.App.Services.Renderer).Assembly);
        services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
        {
            options.FileProviders.Clear();
            options.FileProviders.Add(fileProvider);
        });
        services.AddMvcCore().AddRazorViewEngine();
        /*services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(o =>
        {
            o.ViewLocationFormats.Add("/Views/{0}" + Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewExtension);

            // o.FileProviders.Add(new Microsoft.Extensions.FileProviders.PhysicalFileProvider(AppContext.BaseDirectory));
        });*/

        // services.AddRazorPages();
        services.AddTransient<IRenderer, View.App.Services.Renderer>();

        return services;
    }
}