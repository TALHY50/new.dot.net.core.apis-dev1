using Notification.App.Application.Interfaces.Services;
using Notification.App.Infrastructure.Email;
using Notification.App.Infrastructure.Files;
using Notification.App.Infrastructure.Persistence;
using Notification.App.Infrastructure.Sms;

using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Services;

namespace Notification.App.Infrastructure;

public static class NotificationInfrastructureDependencyInjection
{
    public static IServiceCollection AddNotificationInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment, ConfigureHostBuilder hostBuilder)
    { 
        services.AddNotificationPersistence(configuration);
        services.AddScoped<IDomainEventService, DomainEventService>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ISmsService, SmsService>();
        services.AddTransient<IWebService, WebService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        return services;
    }
}