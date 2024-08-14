﻿using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Infrastructure.Persistence.Repositories.ConfirmTransaction;
using IMT.App.Infrastructure.Persistence.Repositories.ImtCountry;
using IMT.App.Infrastructure.Persistence.Repositories.ImtCurrency;
using IMT.App.Infrastructure.Persistence.Repositories.ImtMoneyTransfer;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProvider;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPayer;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderService;
using IMT.App.Infrastructure.Persistence.Repositories.ImtTransaction;
using IMT.App.Infrastructure.Persistence.Repositories.Quotation;
using IMT.App.Infrastructure.Persistence.Services.ImtProviderService;
using IMT.App.Infrastructure.Persistence.Services.ProviderPayer;
using IMT.App.Infrastructure.Persistence.Services.ProviderService;
using IMT.App.Infrastructure.Persistence.Services.Quotation;
using IMT.App.Infrastructure.Persistence.Services.Transaction;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure
{
    public static class DependencyContainer
    {
        private static ServiceProvider _serviceProvider;

        public static void Initialize()
        {
            var services = new ServiceCollection();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            DotNetEnv.Env.NoClobber().TraversePath().Load();
            string server = DotNetEnv.Env.GetString("DB_HOST");
            string database = DotNetEnv.Env.GetString("DB_DATABASE");
            string userName = DotNetEnv.Env.GetString("DB_USERNAME");
            string password = DotNetEnv.Env.GetString("DB_PASSWORD");
            string port = DotNetEnv.Env.GetString("DB_PORT");

            var connectionString = $"server={server};port={port};database={database};user={userName};password={password};charset=utf8mb4;";

            builder.UseMySQL(connectionString);
            services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySQL(connectionString);
        });

            services.AddScoped<IImtProviderErrorDetailsRepository, ImtProviderErrorDetailsRepository>();
            services.AddScoped<IImtCurrencyRepository, ImtCurrencyRepository>();
            services.AddScoped<IImtCountryRepository, ImtCountryRepository>();
            services.AddScoped<IImtMoneyTransferRepository, ImtMoneyTransferRepository>();
            services.AddScoped<IImtQuotationRepository, ImtQuotationRepository>();
            services.AddScoped<IImtTransactionRepository, ImtTransactionRepository>();
            services.AddScoped<IImtProviderServiceRepository, ImtProviderServiceRepository>();
            services.AddScoped<IImtProviderRepository, ImtProviderRepository>();
            services.AddScoped<IImtProviderPayerRepository, ImtProviderPayerRepository>();


            services.AddScoped<IImtQuotationService, ImtQuotationService>();
            services.AddScoped<IImtMoneyTransferService, ImtMoneyTransferService>();
            services.AddScoped<IImtProviderServiceService, ImtProviderServiceService>();
            services.AddScoped<IImtProviderService, ImtProviderService>();
            services.AddScoped<IImtProviderPayerService, ImtProviderPayerService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public static TService GetService<TService>()
        {
            return _serviceProvider.GetService<TService>();
        }
    }

}
