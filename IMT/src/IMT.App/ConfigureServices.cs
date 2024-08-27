using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Configurations;


namespace IMT.App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
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

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(connectionString, options =>
            {
                options.EnableRetryOnFailure();
            }));

        /*services.AddScoped<IImtProviderErrorDetailsRepository, ImtProviderErrorDetailsRepository>();
        services.AddScoped<IImtCurrencyRepository, ImtCurrencyRepository>();
        services.AddScoped<IImtCountryRepository, ImtCountryRepository>();
        services.AddScoped<IImtMoneyTransferRepository, ImtMoneyTransferRepository>();
        services.AddScoped<IQuotationRepository, QuotationRepository>();
        services.AddScoped<IImtTransactionRepository, ImtTransactionRepository>();

        services.AddTransient<IImtConfirmTransactionService, ImtConfirmTransactionService>();
        services.AddTransient<IQuotationService, ImtQuotationService>();
        services.AddTransient<IImtMoneyTransferService, ImtMoneyTransferService>();
        services.AddTransient<IImtSendMoneyService, ImtSendMoneyService>();*/


        return services;
    }
}