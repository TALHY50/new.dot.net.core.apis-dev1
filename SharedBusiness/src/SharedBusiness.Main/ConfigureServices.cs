using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.IMT.Application;
using SharedKernel.Main.Infrastructure.Services;
using Common = SharedBusiness.Main.Common;
using IMT = SharedBusiness.Main.IMT;
using Admin = SharedBusiness.Main.Admin;

namespace SharedBusiness.Main;

public static class DependencyInjection
{

    public static IServiceCollection AddSharedBusinessApplication(this IServiceCollection services)
    {
        Common.Application.SharedBusinessCommonApplicationDependencyInjection.AddSharedBusinessCommonApplication(services);
        Admin.Application.SharedBusinessAdminApplicationDependencyInjection.AddSharedBusinessAdminApplication(services);
        IMT.Application.SharedBusinessIMTApplicationDependencyInjection.AddSharedBusinessIMTApplication(services);
        return services;
    }


    public static IServiceCollection AddSharedBusinessInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        Common.Infrastructure.SharedBusinessCommonInfrastructureDependencyInjection.AddSharedBusinessCommonInfrastructure(services);
        IMT.Infrastructure.SharedBusinessIMTInfrastructureDependencyInjection.AddSharedBusinessIMTInfrastructure(services);
        Admin.Infrastructure.SharedBusinessAdminInfrastructureDependencyInjection.AddSharedBusinessAdminInfrastructure(services);
        return services;
    }

    public static IServiceCollection AddSharedBusinessPersistence(this IServiceCollection services)
    {
 

        return services;
    }


    public static IServiceCollection AddSharedBusinessPresentation(this IServiceCollection services)
    {
        Common.Presentation.SharedBusinessCommonPresentationDependencyInjection.AddSharedBusinessCommonPresentation(services);
        IMT.Presentation.SharedBusinessIMTPresentationDependencyInjection.AddSharedBusinessIMTPresentation(services);
        Admin.Presentation.SharedBusinessAdminPresentationDependencyInjection.AddSharedBusinessAdminPresentation(services);
        return services;

    }
    
    
}