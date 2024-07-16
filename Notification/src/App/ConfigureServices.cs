using ACL.Application.Infrastructure.Services;

using FluentValidation;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Notification.App.Application.Common.Behaviours;
using Notification.App.Application.Common.Interfaces;
using Notification.App.Application.Common.Interfaces.Repositories;
using Notification.Main.Infrastructure.Files;
using Notification.Main.Infrastructure.Persistence;
using Notification.Main.Infrastructure.Persistence.Repositories;
using Notification.Main.Infrastructure.Services;
using Notification.Renderer;

namespace Notification.Main;

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

        services.AddRazorEngine(configuration);

        services.AddScoped<IDomainEventService, DomainEventService>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ISmsService, SmsService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();

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
        services.AddScoped<ICredentialRepository, CredentialRepository>();

        return services;
    }
}