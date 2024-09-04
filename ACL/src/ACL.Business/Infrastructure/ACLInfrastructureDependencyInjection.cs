using ACL.Business.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using SharedKernel.Main.Infrastructure.Services;

namespace ACL.Business.Infrastructure;

// ReSharper disable once InconsistentNaming
public static class ACLInfrastructureDependencyInjection
{
    public static IServiceCollection AddACLBusinessInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder host)
    {
        //services.AddLogging(configuration, environment, host);
        services.AddPersistence(configuration, environment);
        return services;
    }
    
}