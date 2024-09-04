using System.Security.Cryptography;
using ACL.Business.Application.Behaviours;
using ACL.Business.Application.Features.Auth;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Infrastructure.Jwt;
using ACL.Business.Infrastructure.Security;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SharedKernel.Main.Application;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Infrastructure.Cryptography;
using SharedKernel.Main.Infrastructure.Services;
using RefreshToken = ACL.Business.Application.Features.Auth.RefreshToken;

namespace ACL.Business.Application;

public static class ACLApplicationDependencyInjection
{
    public static IServiceCollection AddACLBusinessApplication(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => !assembly.IsDynamic && assembly.GetName().Name != null)
            .ToArray();
        
        foreach(var assembly in assemblies)
        {
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(assembly); //typeof(DependencyInjection).Assembly
                options.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            });
        }
      
        services.Configure<ApiBehaviorOptions>(o =>
        {
            o.InvalidModelStateResponseFactory = actionContext =>
                new BadRequestObjectResult(new { errors = new UnprocessableEntityObjectResult(actionContext.ModelState).Value, statusCode = ApplicationStatusCodes.GENERAL_FAILURE });
        });
        var jwtConfig = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(jwtConfig);
        var jwtSettings = jwtConfig.Get<JwtSettings>();
        services.AddSingleton(provider =>
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(source: Convert.FromBase64String(jwtSettings?.AccessTokenSettings.PrivateKey ?? string.Empty), bytesRead: out int _);
            return new RsaSecurityKey(rsa);
        });
        RSA rsa = RSA.Create();
        rsa.ImportRSAPublicKey(
            source: Convert.FromBase64String(jwtSettings?.AccessTokenSettings.PublicKey ?? string.Empty),
            bytesRead: out int _
        );
        var rsaKey = new RsaSecurityKey(rsa);
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                if (environment.IsDevelopment()) options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.AccessTokenSettings.Issuer,
                    ValidAudience = jwtSettings.AccessTokenSettings.Audience,
                    IssuerSigningKey = rsaKey,
                    ClockSkew = TimeSpan.FromMinutes(0)
                };
            });
            

        services.AddAuthorization(options =>
        {
            options.AddPolicy("HasPermission", policy =>
                policy.Requirements.Add(new PermissionAuthorizationRequirement()));
        });
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
        //services.AddAuthorizationBuilder();
        services.AddSingleton<IIdentity, Jwt>();
        services.AddTransient<ICurrentUser, CurrentUser>();
        services.AddTransient<ICryptography, Cryptography>();
        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<Login>();
        services.AddScoped<RefreshToken>();
        services.AddScoped<SignOut>();
        services.AddScoped<Register>();
        services.AddSingleton<ILocalizationService>(new LocalizationService("SharedKernel.Main.Infrastructure.Resources.en-US", typeof(ACLApplicationDependencyInjection).Assembly, "en-US"));


        // For language support 
        services.AddHttpContextAccessor();
        // Configure the Language static class
        var serviceProvider = services.BuildServiceProvider();
        var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
        Language.Configure(httpContextAccessor);


        return services;
    }
}