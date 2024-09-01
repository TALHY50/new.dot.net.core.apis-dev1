using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Notification.App.Application.Interfaces.Services;
using Notification.App.Infrastructure.Email;
using Notification.App.Infrastructure.Persistence;
using Notification.App.Infrastructure.Sms;
using Notification.App.Infrastructure.Web;

using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Services;

namespace Notification.App.Infrastructure;

public static class NotificationInfrastructureDependencyInjection
{
    public static IServiceCollection AddNotificationInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment, ConfigureHostBuilder hostBuilder)
    { 
        services.AddNotificationPersistence(configuration);
        services.AddScoped<IDomainEventService, DomainEvent>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ISmsService, SmsService>();
        services.AddTransient<IWebService, WebService>();
        return services;
    }
}