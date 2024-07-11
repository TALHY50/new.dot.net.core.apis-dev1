using FluentValidation;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Notification.Application.Common.Behaviours;
using Notification.Application.Common.Interfaces;
using Notification.Application.Infrastructure.Files;
using Notification.Application.Infrastructure.Persistence;
using Notification.Application.Infrastructure.Services;

namespace Notification.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Console.WriteLine("rifat");
        Console.WriteLine(Path.GetFullPath("wwwroot"));

        var webRoot = Path.GetFullPath("wwwroot");
        webRoot = "/var/www/html/new.dot.net.core.apis/Notification/src/Application/wwwroot";

        var pathToFile = webRoot
                         + Path.DirectorySeparatorChar.ToString()
                         + "Templates"
                         + Path.DirectorySeparatorChar.ToString()
                         + "Email"
                         + Path.DirectorySeparatorChar.ToString()
                         + "Welcome.html";
        Console.WriteLine(pathToFile);
        using (StreamReader sourceReader = System.IO.File.OpenText(pathToFile))
        {
            string body = sourceReader.ReadToEnd();
            Console.WriteLine(body);
        }

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

        services.AddScoped<IDomainEventService, DomainEventService>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        return services;
    }
}