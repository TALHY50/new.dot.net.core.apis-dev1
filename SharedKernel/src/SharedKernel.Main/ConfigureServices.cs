using Microsoft.Extensions.DependencyInjection;
using Infrastructure = SharedKernel.Main.Infrastructure;
using Application = SharedKernel.Main.Application;
using Presentation = SharedKernel.Main.Presentation;
namespace SharedKernel.Main;

public static class ConfigureServices
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services)
    {
        DotNetEnv.Env.Load();
        SharedKernel.Main.Presentation.DependencyInjection.AddPresentation(services);
        SharedKernel.Main.Application.DependencyInjection.AddApplication(services);
        SharedKernel.Main.Infrastructure.DependencyInjection.AddInfrastructure(services);
        return services;
    }
}