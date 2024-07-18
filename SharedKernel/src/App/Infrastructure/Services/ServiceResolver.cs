using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.Services;

public class ServiceResolver
{
#pragma warning disable CS8714 // Possible null reference argument.
    public static T Get<T>(WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        
        var services = serviceScope.ServiceProvider;

        return services.GetRequiredService<T>();
            
        
    }
}