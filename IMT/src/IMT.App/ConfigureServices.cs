using DotNetEnv;
using IMT.App.Application.Ports.Services;
using IMT.App.Infrastructure.Persistence.Services.ConfirmTransactionService;
using IMT.App.Infrastructure.Persistence.Services.ProviderService;
using IMT.App.Infrastructure.Persistence.Services.Quotation;
using IMT.App.Infrastructure.Persistence.Services.SendMoney;
using IMT.App.Infrastructure.Persistence.Services.Transaction;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

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

        var connectionString = $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(connectionString, options =>
            {
                options.EnableRetryOnFailure();
            })); 
        
        //builder.Services.AddScoped<IImtCurrencyRepository, ImtCurrencyRepository>();
        ////builder.Services.AddScoped<IImtCountryRepository, ImtCountryRepository>();
        /// 
        services.AddTransient<IImtConfirmTransactionService, ImtConfirmTransactionService>();
        services.AddTransient<IImtQuotationService, ImtQuotationService>();
        services.AddTransient<IImtMoneyTransferService, ImtMoneyTransferService>();
        services.AddTransient<IImtSendMoneyService, ImtSendMoneyService>();
        services.AddTransient<IImtProviderServiceService, ImtProviderServiceService>();
        
        return services;
    }
}