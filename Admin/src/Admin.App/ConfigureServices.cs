// <copyright file="ConfigureServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Security.Cryptography;
using Admin.App.Application.Features.Corridors;
using Admin.App.Application.Features.Currencies;
using Admin.App.Application.Features.Payers;
using Admin.App.Application.Features.Countries;
using Admin.App.Application.Features.Currencies;
using Admin.App.Application.Features.Providers;
using Admin.App.Application.Features.Regions;
using Admin.App.Application.Features.TransactionTypes;
using DotNetEnv;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Main.Application.Common.Behaviours;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Module;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Role;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.UserGroup;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Application.Interfaces.Repositories.Notification;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Cryptography;
using SharedKernel.Main.Infrastructure.Files;
using SharedKernel.Main.Infrastructure.Jwt;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Module;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Role;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.UserGroup;
using SharedKernel.Main.Infrastructure.Persistence.Admin.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.ImtCurrency;
using SharedKernel.Main.Infrastructure.Security;
using SharedKernel.Main.Infrastructure.Services;
using static Admin.App.Application.Features.BusinessHourAndWeekend.CreateBusinessHourAndWeekendController;
using static Admin.App.Application.Features.HolidaySetting.CreateHolidaySettingController;
using static Admin.App.Application.Features.Mtts.MttsCreate;
using static Admin.App.Application.Features.Mtts.MttsCreate;

namespace Admin.App;

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
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ISmsService, SmsService>();
        services.AddTransient<IWebService, WebService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
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

        services.AddDbContext<AclApplicationDbContext>(
            options =>
                options.UseMySQL(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }),
            ServiceLifetime.Transient);


        services.AddDbContext<ImtApplicationDbContext>(
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

        services.AddScoped<IAclPageRepository, AclPageRepository>();
        services.AddScoped<IAclPageRouteRepository, AclPageRouteRepository>();
        services.AddScoped<IAclPasswordRepository, AclPasswordRepository>();
        services.AddScoped<IAclRolePageRepository, AclRolePageRepository>();
        services.AddScoped<IAclRoleRepository, AclRoleRepository>();

        // services.AddScoped<IAclSubModuleRepository, AclSubModuleRepository>();
        services.AddScoped<IAclUserGroupRepository, AclUserGroupRepository>();
        services.AddScoped<IAclUserGroupRoleRepository, AclUserGroupRoleRepository>();
        services.AddScoped<IAclUserUserGroupRepository, AclUserUserGroupRepository>();
        services.AddScoped<IAclUserRepository, AclUserRepository>();
        services.AddScoped<IImtMttsRepository, ImtMttsRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateMttCommand).Assembly));
        services.AddScoped<IAdminCountryRepository, AdminCountryRepository>();
        services.AddScoped<IImtServiceMethodRepository, ImtServiceMethodRepository>();
        services.AddScoped<IImtPayerPaymentSpeedRepository, ImtPayerPaymentSpeed>();
       // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCountryCommand).Assembly));  
        //services.AddScoped<IRequestHandler<CreateCountryCommand, ErrorOr<Country>>, CreateCountryCommandHandler>();

        services.AddScoped<IImtRegionRepository, ImtRegionRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateRegionCommand).Assembly));
        services.AddScoped<IImtProviderRepository, ImtProviderRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProviderCommand).Assembly));
        services.AddScoped<IImtTransactionTypeRepository, ImtTransactionTypeRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTransactionTypeCommand).Assembly));

        services.AddScoped<IImtMttsRepository, ImtMttsRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateMttCommand).Assembly));
        services.AddScoped<IImtCorridorRepository, ImtCorridorRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCorridorCommand).Assembly));
        services.AddScoped<IImtAdminCurrencyRepository, ImtAdminCurrencyRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCurrencyCommand).Assembly));

        services.AddScoped<IImtPayerRepository, ImtPayerRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePayerCommand).Assembly));



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

        services.AddScoped<IAppEventDataRepository, AppEventDataRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IEmailOutgoingRepository, EmailOutgoingRepository>();
        services.AddScoped<ISmsOutgoingRepository, SmsOutgoingRepository>();
        services.AddScoped<IWebOutgoingRepository, WebOutgoingRepository>();
        services.AddScoped<ICredentialRepository, CredentialRepository>();

        return services;
    }
}