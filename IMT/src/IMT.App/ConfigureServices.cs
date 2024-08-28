// <copyright file="ConfigureServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Security.Cryptography;
using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Application.Interfaces.Services;
using ACL.App.Infrastructure.Jwt;
using ACL.App.Infrastructure.Persistence.Repositories;
using ACL.App.Infrastructure.Security;
using DotNetEnv;
using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Infrastructure.Persistence.Context;
using IMT.App.Infrastructure.Persistence.Repositories;
using MediatR;
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
using ACLApplicationDbContext = ACL.App.Infrastructure.Persistence.Context.ApplicationDbContext;
using CountryRepository = IMT.App.Infrastructure.Persistence.Repositories.CountryRepository;

namespace IMT.App;

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

        services.AddDbContext<ACLApplicationDbContext>(
            options =>
                options.UseMySQL(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }),
            ServiceLifetime.Transient);

        services.AddDbContext<IMT.App.Infrastructure.Persistence.Context.Old.ApplicationDbContext>(
            options =>
                options.UseMySQL(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }),
            ServiceLifetime.Transient);
        
        
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
        services.AddScoped<IImtMttsRepository, MttRepository>();
        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateMttCommand).Assembly));
        services.AddScoped<IImtRegionRepository, RegionRepository>();
      //  services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateRegionCommand).Assembly));
        services.AddScoped<IImtProviderRepository, ProviderRepository>();
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProviderCommand).Assembly));
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTransactionTypeCommand).Assembly));
        services.AddScoped<IImtCorridorRepository, CorridorRepository>();
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCorridorCommand).Assembly));
        services.AddScoped<IImtAdminCurrencyRepository, AdminCurrencyRepository>();
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCurrencyCommand).Assembly));

        services.AddScoped<IImtPayerRepository, PayerRepository>();
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePayerCommand).Assembly));

        services.AddScoped<IAdminCountryRepository, CountryRepository>();
        services.AddScoped<IImtServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IImtPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<IImtTaxRateRepository, TaxRateRepository>();
        services.AddScoped<IImtInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
       // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCountryCommand).Assembly));  
        // services.AddScoped<IRequestHandler<CreateCountryCommand, ErrorOr<Country>>, CreateCountryCommandHandler>();

        services.AddScoped<IImtMttsRepository, MttRepository>();

       // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateMttCommand).Assembly));

        // BusinessHourAndWeekendRepository
        services.AddScoped<IBusinessHourAndWeekendRepository, BusinessHourAndWeekendRepository>();

        // HolidaySetting
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>();

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("VerticalSliceDb"));
        }
        else
        {
            var c = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }



        return services;
    }
}