using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedKernel.Main.Infrastructure.Persistence;

public static class SharedKernelPersistenceDependencyInjection
{
    public static IServiceCollection AddSharedKernelPersistence(this IServiceCollection services)
    {
        services.AddSingleton<ITransactionHandler, TransactionHandler>();
        return services;
    }
    
}