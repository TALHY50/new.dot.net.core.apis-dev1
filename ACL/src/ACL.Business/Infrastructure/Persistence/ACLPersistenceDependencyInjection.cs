using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using DotNetEnv;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Infrastructure.Utilities;

namespace ACL.Business.Infrastructure.Persistence;

public static class ACLPersistenceDependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    { 
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(ConnectionManager.GetDbConnectionString(), options =>
            {
                options.EnableRetryOnFailure();
            }));
        
        var cacheDriver = Env.GetString("CACHE_DRIVER");
        if (cacheDriver == "redis")
        {
            services.AddStackExchangeRedisCache(
                redisOptions => { redisOptions.Configuration = ConnectionManager.GetRedisConnectionString(); }
            );
        }
        services.AddMemoryCache();
        services.AddDistributedMemoryCache();
        services.AddScoped<ICacheService, Cache>();
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<ICompanyModuleService, CompanyModuleService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<ISubModuleService, SubModuleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserGroupRoleService, UserGroupRoleService>();
        services.AddScoped<IUserGroupService, UserGroupService>();
        services.AddScoped<ISubModuleService, SubModuleService>();
        services.AddScoped<ISubModuleService, SubModuleService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IPageService, PageService>();
        services.AddScoped<IPageRepository, PageRepository>();
        services.AddScoped<IPageRouteRepository, PageRouteRepository>();
        services.AddScoped<IPasswordRepository, PasswordRepository>();
        services.AddScoped<IRolePageRepository, RolePageRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        services.AddScoped<IUserGroupRoleRepository, UserGroupRoleRepository>();
        services.AddScoped<IUserUserGroupRepository, UserUserGroupRepository>();
        services.AddSingleton<IUserSettingRepository, IUserSettingRepository>();
        return services;
    }
}