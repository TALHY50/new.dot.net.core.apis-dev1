using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ITransactionLimitRepository, TransactionLimitRepository>();
        services.AddScoped<IImtCurrencyConversionRateRepository, CurrencyConversionRateRepository>();
        return services;
    }
    
}