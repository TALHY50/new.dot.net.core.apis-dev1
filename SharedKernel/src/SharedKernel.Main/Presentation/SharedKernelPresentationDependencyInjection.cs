using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Presentation.Error;

namespace SharedKernel.Main.Presentation;


public static class SharedKernelPresentationDependencyInjection
{
    public static IServiceCollection AddSharedKernelPresentation(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
            options => options.SerializerOptions.Converters.Insert( 0, new ErrorObjectConverter() ) );
        services.AddSingleton<ProblemDetailsFactory, OrgProblemDetailsFactory>();

        return services;
    }
    
    public static IServiceCollection AddRazorEngine(this IServiceCollection services, IConfiguration configuration)
    {
        var fileProvider = new EmbeddedFileProvider(typeof(Renderer).Assembly);
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
        services.AddTransient<IRenderer, Renderer>();

        return services;
    }
}