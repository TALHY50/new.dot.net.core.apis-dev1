using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.IMT.Application;
using SbCommon = SharedBusiness.Main.Common;
using SbImt = SharedBusiness.Main.IMT;
using SbAdmin = SharedBusiness.Main.Admin;

namespace SharedBusiness.Main;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(IServiceCollection services)
    {
        SbCommon.Application.DependencyInjection.AddApplication(services);
        SbAdmin.Application.DependencyInjection.AddApplication(services);
        SbImt.Application.DependencyInjection.AddApplication(services);
        return services;
    }


    public static IServiceCollection AddInfrastructure(IServiceCollection services)
    {
        SbCommon.Infrastructure.DependencyInjection.AddInfrastructure(services);
        SbImt.Infrastructure.DependencyInjection.AddInfrastructure(services);
        SbAdmin.Infrastructure.DependencyInjection.AddInfrastructure(services);
        return services;
    }


    public static IServiceCollection AddPresentation(IServiceCollection services)
    {
        SbCommon.Presentation.DependencyInjection.AddPresentation(services);
        SbImt.Presentation.DependencyInjection.AddPresentation(services);
        SbAdmin.Presentation.DependencyInjection.AddPresentation(services);
        return services;

    }

    public static IServiceCollection AddSharedBusinessApp(this IServiceCollection services)
    {
        SharedBusiness.Main.DependencyInjection.AddApplication(services);
        SharedBusiness.Main.DependencyInjection.AddInfrastructure(services);
        SharedBusiness.Main.DependencyInjection.AddPresentation(services);

        return services;
    }
    
}