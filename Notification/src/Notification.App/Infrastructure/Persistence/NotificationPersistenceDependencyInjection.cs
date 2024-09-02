using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Notification.App.Application.Interfaces.Repositories;
using Notification.App.Infrastructure.Persistence.Repositories;

using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Infrastructure.Utilities;

namespace Notification.App.Infrastructure.Persistence;

public static class NotificationPersistenceDependencyInjection
{
    public static IServiceCollection AddNotificationPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Context.ApplicationDbContext>(options =>
            options.UseMySql(
                ConnectionManager.GetDbConnectionString(),
                ServerVersion.AutoDetect(ConnectionManager.GetDbConnectionString()),
                b => b.MigrationsAssembly(typeof(Context.ApplicationDbContext).Assembly.FullName)));
        services.AddScoped<IAppEventDataRepository, AppEventDataRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IEmailOutgoingRepository, EmailOutgoingRepository>();
        services.AddScoped<ISmsOutgoingRepository, SmsOutgoingRepository>();
        services.AddScoped<IWebOutgoingRepository, WebOutgoingRepository>();
        services.AddScoped<ICredentialRepository, CredentialRepository>();
        return services;
    }
}