using DotNetEnv;
using FluentValidation;

using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common.Behaviours;
using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Application.Interfaces.Repositories.Notification;
using SharedKernel.Main.Infrastructure.Files;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Infrastructure.Persistence.Admin.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Repositories;
using SharedKernel.Main.Infrastructure.Services;

namespace ADMIN.App;

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
        services.AddPersistence(configuration);

        services.AddScoped<IDomainEventService, DomainEventService>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ISmsService, SmsService>();
        services.AddTransient<IWebService, WebService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseInMemoryDatabase("VerticalSliceDb"));
        //}
        //else
        //{
        //    var c = configuration.GetConnectionString("DefaultConnection");
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseMySql(
        //            configuration.GetConnectionString("DefaultConnection"),
        //            ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
        //            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        //}

        Env.NoClobber().TraversePath().Load();

        var server = Env.GetString("DB_HOST");
        var database = Env.GetString("DB_DATABASE");
        var userName = Env.GetString("DB_USERNAME");
        var password = Env.GetString("DB_PASSWORD");
        var port = Env.GetString("DB_PORT");

        var connectionString = $"server={server};port={port};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ImtApplicationDbContext>(options =>
            options.UseMySQL(connectionString, options =>
            {
                options.EnableRetryOnFailure();
            }));


        services.AddScoped<IImtMttsRepository,ImtMttsRepository>();
        return services;
    }
}