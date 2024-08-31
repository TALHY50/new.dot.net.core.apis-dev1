using ACL.Business.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure;
using SharedKernel.Main.Infrastructure.Services;

namespace ACL.Business.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder host)
    {
        services.AddInfrastructure();
        services.AddLogging(configuration, environment, host);
        services.AddPersistence(configuration, environment);
        return services;
    }

    public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder host)
    {
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddSerilog(dispose: true);
        });
        services.AddSingleton<Serilog.ILogger>(_ => Log.Logger);
        services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(_ => (Microsoft.Extensions.Logging.ILogger)Log.Logger);
        services.AddScoped<ILogService, LogService>();
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day, buffered: false)
            .WriteTo.Logger(lc => lc
                .Filter.ByExcluding(e => e.Properties.ContainsKey("RequestPath") || e.Properties.ContainsKey("RequestBody") || e.Properties.ContainsKey("ResponseBody"))
                .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Information))
            .WriteTo.File(GetLogFilePath("querylog.txt"), restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day, buffered: false)
            .CreateLogger();

        host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration)
                .WriteTo.Console();
        });

        services.AddSerilog();

        return services;
    }
    
    static string GetLogFilePath(string fileName)
    {
        var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        Directory.CreateDirectory(logDirectory);
        var datePrefix = DateTime.Now.ToString("yyyy-MM-dd");
        return Path.Combine(logDirectory, $"{datePrefix}_{fileName}");
    }
}