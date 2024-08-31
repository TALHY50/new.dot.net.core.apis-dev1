using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Common.Behaviours;

namespace SharedBusiness.Main.Admin.Application;

public static class SharedBusinessAdminApplicationDependencyInjection
{
    public static IServiceCollection AddSharedBusinessAdminApplication(this IServiceCollection services)
    {
        return services;
    }
}