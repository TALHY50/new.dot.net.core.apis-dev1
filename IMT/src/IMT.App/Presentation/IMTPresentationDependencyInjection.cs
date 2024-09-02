using Microsoft.OpenApi.Models;

namespace IMT.App.Presentation;

public static class IMTPresentationDependencyInjection
{
    public static IServiceCollection AddIMTPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddCors(options => options.AddDefaultPolicy(
            policy => policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
        
        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Admin API", Version = "v1" }));
        services.AddProblemDetails();
        services.AddHealthChecks();
        services.AddHttpContextAccessor();
        return services;
    }
    
}