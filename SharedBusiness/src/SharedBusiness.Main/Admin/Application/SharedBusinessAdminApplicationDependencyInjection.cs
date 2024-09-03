using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SharedBusiness.Main.Admin.Weblication;

public static class SharedBusinessAdminApplicationDependencyInjection
{
    public static IServiceCollection AddSharedBusinessAdminApplication(this IServiceCollection services)
    {
        return services;
    }
}