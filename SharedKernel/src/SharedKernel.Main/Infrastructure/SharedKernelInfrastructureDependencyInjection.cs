using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.BuildingBlocks.Logging;
using SharedKernel.Main.Infrastructure.MiddleWares;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Infrastructure.Services;
using DateTime = SharedKernel.Main.Infrastructure.Services.DateTime;

namespace SharedKernel.Main.Infrastructure;

public static class SharedKernelInfrastructureDependencyInjection
{
    public static IServiceCollection AddSharedKernelInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder host)
    {
        host.UseSerilog(SeriLogger.Configure);
        services.AddSharedKernelPersistence();
        services.AddSingleton<IDateTime, DateTime>();
        services.AddTransient<IGuardAgainstNullUpdate, GuardAgainstNullUpdate>();
        return services;
    }
    
}