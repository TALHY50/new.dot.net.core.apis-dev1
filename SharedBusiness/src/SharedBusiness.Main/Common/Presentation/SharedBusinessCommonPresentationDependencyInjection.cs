using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SharedBusiness.Main.Common.Presentation;

public static class SharedBusinessCommonPresentationDependencyInjection
{
    public static IServiceCollection AddSharedBusinessCommonPresentation(IServiceCollection services)
    {
        services.AddMappings();
        return services;
    }
    
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}