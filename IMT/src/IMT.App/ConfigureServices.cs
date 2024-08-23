﻿using DotNetEnv;
using IMT.App.Infrastructure.Persistence.Services.Quotation;
using IMT.App.Infrastructure.Persistence.Services.SendMoney;
using IMT.App.Infrastructure.Persistence.Services.Transaction;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Services;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories.ConfirmTransaction;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.ImtCountry;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.ImtCurrency;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.ImtMoneyTransfer;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.ImtTransaction;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.Quotation;
using SharedKernel.Main.Infrastructure.Persistence.Services.ConfirmTransactionService;

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

        services.AddScoped<IImtProviderErrorDetailsRepository, ImtProviderErrorDetailsRepository>();
        services.AddScoped<IImtCurrencyRepository, ImtCurrencyRepository>();
        services.AddScoped<IImtCountryRepository, ImtCountryRepository>();
        services.AddScoped<IImtMoneyTransferRepository, ImtMoneyTransferRepository>();
        services.AddScoped<IImtQuotationRepository, ImtQuotationRepository>();
        services.AddScoped<IImtTransactionRepository, ImtTransactionRepository>();

        services.AddTransient<IImtConfirmTransactionService, ImtConfirmTransactionService>();
        services.AddTransient<IImtQuotationService, ImtQuotationService>();
        services.AddTransient<IImtMoneyTransferService, ImtMoneyTransferService>();
        services.AddTransient<IImtSendMoneyService, ImtSendMoneyService>();


        return services;
    }
}