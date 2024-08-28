using System.Security.Cryptography;

using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Application.Interfaces.Services;
using ACL.App.Infrastructure.Jwt;
using ACL.App.Infrastructure.Persistence.Repositories;
using ACL.App.Infrastructure.Security;

using DotNetEnv;

using FluentValidation;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;



using SharedKernel.Main.Application.Common.Behaviours;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Cryptography;
using SharedKernel.Main.Infrastructure.Security;
using SharedKernel.Main.Infrastructure.Services;

using ApplicationDbContext = ACL.App.Infrastructure.Persistence.Context.ApplicationDbContext;

namespace ACL.App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            options.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            options.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
            options.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
        });

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSecurity(configuration);

        services.AddPersistence(configuration);

        services.AddRazorEngine(configuration);

        services.AddScoped<IDomainEventService, DomainEventService>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IWebService, WebService>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        return services;
    }

    public static IServiceCollection AddRazorEngine(this IServiceCollection services, IConfiguration configuration)
    {
        var fileProvider = new EmbeddedFileProvider(typeof(Renderer).Assembly);
        services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
        {
            options.FileProviders.Clear();
            options.FileProviders.Add(fileProvider);
        });
        services.AddMvcCore().AddRazorViewEngine();
        /*services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(o =>
        {
            o.ViewLocationFormats.Add("/Views/{0}" + Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewExtension);

            // o.FileProviders.Add(new Microsoft.Extensions.FileProviders.PhysicalFileProvider(AppContext.BaseDirectory));
        });*/

        // services.AddRazorPages();
        services.AddTransient<IRenderer, Renderer>();

        return services;
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        var jwtSettingsConfiguration = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(jwtSettingsConfiguration);
        var jwtSettings = jwtSettingsConfiguration.Get<JwtSettings>();

        services.AddSingleton<IAuthTokenService, JwtService>();
        services.AddTransient<ICryptographyService, CryptographyService>();

        Env.NoClobber().TraversePath().Load();

        var server = Env.GetString("DB_HOST");
        var database = Env.GetString("DB_DATABASE");
        var userName = Env.GetString("DB_USERNAME");
        var password = Env.GetString("DB_PASSWORD");
        var port = Env.GetString("DB_PORT");

        var connectionString =
            $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseMySQL(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }),
            ServiceLifetime.Transient);

        var cacheDriver = Env.GetString("CACHE_DRIVER");

        if (cacheDriver == "redis")
        {
            var redisHost = Env.GetString("REDIS_HOST");
            var redistPort = Env.GetString("REDIS_PORT");
            var redisPassword = Env.GetString("REDIS_PASSWORD");
            var redistConnectionString = $"{redisHost}:{redistPort},password={redisPassword}";

            services.AddStackExchangeRedisCache(
                redisOptions => { redisOptions.Configuration = redistConnectionString; });
        }

        services.AddScoped<IPageRepository, PageRepository>();
        services.AddScoped<IPageRouteRepository, PageRouteRepository>();
        services.AddScoped<IPasswordRepository, PasswordRepository>();
        services.AddScoped<IRolePageRepository, RolePageRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

// services.AddScoped<ISubModuleRepository, SubModuleRepository>();
        services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        services.AddScoped<IUserGroupRoleRepository, UserGroupRoleRepository>();
        services.AddScoped<IUserUserGroupRepository, UserUserGroupRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddSingleton(provider =>
        {
            var rsa = RSA.Create();

            // rsa.ImportRSAPrivateKey(source: Convert.FromBase64String(jwtSettings?.AccessTokenSettings.PrivateKey), bytesRead: out int _);
            return new RsaSecurityKey(rsa);
        });

        RSA rsa = RSA.Create();
        if (jwtSettings?.AccessTokenSettings.PublicKey != null)
        {
            if (jwtSettings?.AccessTokenSettings.PublicKey != null)
            {
                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(jwtSettings?.AccessTokenSettings.PublicKey!),
                    bytesRead: out int _);
            }
        }

        var rsaKey = new RsaSecurityKey(rsa);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                if (isDevelopment)
                {
                    options.RequireHttpsMetadata = false;
                }

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings!.AccessTokenSettings.Issuer,
                    ValidAudience = jwtSettings.AccessTokenSettings.Audience,
                    IssuerSigningKey = rsaKey,
                    ClockSkew = TimeSpan.FromMinutes(0),
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("HasPermission", policy =>
                policy.Requirements.Add(new PermissionAuthorizationRequirement()));
        });

        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<Infrastructure.Persistence.Context.ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("VerticalSliceDb"));
        }
        else
        {
            var c = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Infrastructure.Persistence.Context.ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                    b => b.MigrationsAssembly(typeof(Infrastructure.Persistence.Context.ApplicationDbContext).Assembly.FullName)));
        }
        
        return services;
    }
}