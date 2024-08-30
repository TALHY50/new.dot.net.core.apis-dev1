using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.IMT.Application;
using Common = SharedBusiness.Main.Common;
using IMT = SharedBusiness.Main.IMT;
using Admin = SharedBusiness.Main.Admin;

namespace SharedBusiness.Main;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(IServiceCollection services)
    {
        Common.Application.DependencyInjection.AddApplication(services);
        Admin.Application.DependencyInjection.AddApplication(services);
        IMT.Application.DependencyInjection.AddApplication(services);
        return services;
    }


    public static IServiceCollection AddInfrastructure(IServiceCollection services)
    {
        Common.Infrastructure.DependencyInjection.AddInfrastructure(services);
        IMT.Infrastructure.DependencyInjection.AddInfrastructure(services);
        Admin.Infrastructure.DependencyInjection.AddInfrastructure(services);
        return services;
    }


    public static IServiceCollection AddPresentation(IServiceCollection services)
    {
        Common.Presentation.DependencyInjection.AddPresentation(services);
        IMT.Presentation.DependencyInjection.AddPresentation(services);
        Admin.Presentation.DependencyInjection.AddPresentation(services);
        return services;

    }

    public static IServiceCollection AddSharedBusiness(this IServiceCollection services)
    {
        SharedBusiness.Main.DependencyInjection.AddApplication(services);
        SharedBusiness.Main.DependencyInjection.AddInfrastructure(services);
        SharedBusiness.Main.DependencyInjection.AddPresentation(services);

        return services;
    }
    
}