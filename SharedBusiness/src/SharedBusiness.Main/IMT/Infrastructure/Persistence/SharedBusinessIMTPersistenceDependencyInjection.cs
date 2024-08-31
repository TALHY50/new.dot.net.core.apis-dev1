using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence;

public static class SharedBusinessIMTPersistenceDependencyInjection
{
    public static IServiceCollection AddSharedBusinessIMTPersistence(this IServiceCollection services)
    {
        services.AddScoped<IMoneyTransferRepository, MoneyTransferRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        return services;
    }
    
}