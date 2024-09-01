using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Notification.App.Presentation.Mapping;

using SharedKernel.Main.Presentation;

namespace Notification.App.Presentation;

public static class NotificationPresentationDependencyInjection
{
    public static IServiceCollection AddNotificationPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddRazorEngine(configuration);
        services.AddEndpointsApiExplorer();
        services.AddCors(options => options.AddDefaultPolicy(
            policy => policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification API", Version = "v1" }));
        services.AddProblemDetails();
        services.AddHealthChecks();
        services.AddHttpContextAccessor();
        services.AddNotificationMappings();
        return services;
    }

}