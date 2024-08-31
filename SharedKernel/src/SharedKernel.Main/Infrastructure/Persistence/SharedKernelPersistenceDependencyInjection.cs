using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Main.Infrastructure.Persistence;

public static class SharedKernelPersistenceDependencyInjection
{
    public static IServiceCollection AddSharedKernelPersistence(this IServiceCollection services)
    {
        return services;
    }
    
}