using System.Security.Cryptography;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Infrastructure.Jwt;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using ACL.Business.Infrastructure.Security;
using Admin.App.Application.Features.Corridors;
using Admin.App.Application.Features.Currencies;
using Admin.App.Application.Features.Payers;
using Admin.App.Application.Features.Providers;
using Admin.App.Application.Features.Regions;
using Admin.App.Application.Features.TransactionTypes;
using Admin.App.Infrastructure.Persistence;
using Admin.App.Presentation;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Cryptography;
using SharedKernel.Main.Infrastructure.Services;
using CountryRepository = SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories.CountryRepository;
using ICountryRepository = SharedBusiness.Main.IMT.Application.Interfaces.Repositories.ICountryRepository;

namespace Admin.App.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        SharedKernel.Main.Infrastructure.DependencyInjection.AddInfrastructure(services);

        SharedBusiness.Main.DependencyInjection.AddInfrastructure(services);

        services.AddSecurity(configuration);

        services.AddPersistence(configuration);

        services.AddRazorEngine(configuration);

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

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
            $"server={server};database={database};port={port};User ID={userName};Password={password};CharSet=utf8mb4;" ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseMySQL(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }),
            ServiceLifetime.Transient);

        services.AddDbContext<SharedBusiness.Main.Common.Infrastructure.Persistence.Context.ApplicationDbContext>(
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
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateRegionCommand).Assembly));
        services.AddScoped<IImtProviderRepository, ProviderRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProviderCommand).Assembly));
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTransactionTypeCommand).Assembly));
        services.AddScoped<IImtCorridorRepository, CorridorRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCorridorCommand).Assembly));
        services.AddScoped<IImtAdminCurrencyRepository, AdminCurrencyRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCurrencyCommand).Assembly));

        services.AddScoped<IImtPayerRepository, PayerRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePayerCommand).Assembly));

        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IImtServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IImtPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<IImtTaxRateRepository, TaxRateRepository>();
        services.AddScoped<IImtInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IImtInstitutionMttRepository, InstitutionMttRepository>();
        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCountryCommand).Assembly));  
        // services.AddScoped<IRequestHandler<CreateCountryCommand, ErrorOr<Country>>, CreateCountryCommandHandler>();

        services.AddScoped<IImtMttsRepository, MttRepository>();
        services.AddScoped<IImtMttPaymentSpeedRepository, ImtMttPaymentSpeedRepository>();

        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateMttCommand).Assembly));

        // BusinessHourAndWeekendRepository
        services.AddScoped<IBusinessHourAndWeekendRepository, BusinessHourAndWeekendRepository>();

        // HolidaySetting
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>();
        services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        services.AddScoped<IInstitutionSettingRepository, InstitutionSettingRepository>();

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
}