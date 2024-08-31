using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Presentation.Error;

namespace SharedKernel.Main.Presentation;


public static class DependencyInjection
{
    public static IServiceCollection AddSharedKernelPresentation(this IServiceCollection services)
    {
        services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
            options => options.SerializerOptions.Converters.Insert( 0, new ErrorObjectConverter() ) );
        services.AddSingleton<ProblemDetailsFactory, OrgProblemDetailsFactory>();

        return services;
    }
}