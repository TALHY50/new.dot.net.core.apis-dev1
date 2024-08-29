using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Presentation.Error;

namespace SharedKernel.Main.Presentation;


public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, OrgProblemDetailsFactory>();

        return services;
    }
}