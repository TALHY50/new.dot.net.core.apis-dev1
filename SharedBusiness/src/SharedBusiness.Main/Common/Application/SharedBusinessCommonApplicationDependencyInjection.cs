using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SharedBusiness.Main.Common.Application;

public static class SharedBusinessCommonApplicationDependencyInjection
{
    public static IServiceCollection AddSharedBusinessCommonApplication(this IServiceCollection services)
    { 
        return services;
    }
}
