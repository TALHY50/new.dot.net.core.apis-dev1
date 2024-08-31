using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Common.Behaviours;

namespace SharedBusiness.Main.Common.Application;

public static class SharedBusinessCommonApplicationDependencyInjection
{
    public static IServiceCollection AddSharedBusinessCommonApplication(this IServiceCollection services)
    { 
        return services;
    }
}
