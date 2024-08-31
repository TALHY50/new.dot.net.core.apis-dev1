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
        Infrastructure.DependencyInjection.AddInfrastructure(services);
        Application.DependencyInjection.AddApplication(services);
        Presentation.DependencyInjection.AddPresentation(services);
        return services;
    }
}