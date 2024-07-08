using IMT.Application.Domain.Ports.Repositories.ConfirmTransaction;
using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
using IMT.Application.Domain.Ports.Repositories.ImtMoneyTransfer;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Application.Domain.Ports.Services.Transaction;
using IMT.Application.Infrastructure.Persistence.Repositories.ImtCountry;
using IMT.Application.Infrastructure.Persistence.Repositories.ImtCurrency;
using IMT.Application.Infrastructure.Persistence.Services.QuotationService;
using IMT.Application.Infrastructure.Persistence.Services.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Infrastructure.Utility
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
            services.AddScoped<IImtCurrencyRepository, ImtCurrencyRepository>();
            services.AddScoped<IImtCountryRepository, ImtCountryRepository>();
            services.AddScoped<IImtMoneyTransferRepository, IImtMoneyTransferRepository>();
            services.AddScoped<IImtConfirmTransactionRepository, ImtConfirmTransactionRepository>();
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
