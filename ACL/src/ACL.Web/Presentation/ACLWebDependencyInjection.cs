using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace ACL.Web.Presentation;

public static class ACLWebDependencyInjection
{
    public static IServiceCollection AddACLWebPresentation(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        services.AddHttpContextAccessor();
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.WriteIndented = false; // Ensure compact JSON
        });
        
        services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                //Type = SecuritySchemeType.ApiKey,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme.",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        services.AddHttpContextAccessor();
        //services.AddIdentityApiEndpoints<IdentityUser>();
        return services;
    }
}