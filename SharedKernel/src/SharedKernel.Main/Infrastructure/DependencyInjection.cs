using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.MiddleWares;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedKernelInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder host)
    {
        services.AddTransient<IGuardAgainstNullUpdate, GuardAgainstNullUpdate>();
        return services;
    }
    
}