﻿using App.Application.Ports.Repositories;
using App.Infrastructure.Persistence.Repositories.ConfirmTransaction;
using App.Infrastructure.Persistence.Repositories.ImtCountry;
using App.Infrastructure.Persistence.Repositories.ImtCurrency;
using App.Infrastructure.Persistence.Repositories.ImtMoneyTransfer;
using App.Infrastructure.Persistence.Repositories.ImtTransaction;
using App.Infrastructure.Persistence.Repositories.Quotation;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence.Configurations;

namespace App.Infrastructure
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
        //  services.AddScoped<IImtQuotationService, ImtQuotationService>(); 
        //  services.AddScoped<IImtMoneyTransferService, ImtMoneyTransferService>(); 

            _serviceProvider = services.BuildServiceProvider();
        }

        public static TService GetService<TService>()
        {
            return _serviceProvider.GetService<TService>();
        }
    }

}
