using ACL.Business.Application.Features.UserSettings;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using DotNetEnv;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Infrastructure.Utilities;
using System.Reflection;
using ACL.Business.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ACL.Business.Infrastructure.Persistence;

public static class ACLPersistenceDependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(ConnectionManager.GetDbConnectionString(), options =>
            {
                options.MigrationsAssembly("ACL.Web");
                options.EnableRetryOnFailure();
            }));

       // services.AddIdentity<User, Role>();
        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<ApplicationDbContext>().AddApiEndpoints();
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
        services.AddScoped<IUserGroupRoleService, UserGroupRoleService>();
        services.AddScoped<IUserGroupService, UserGroupService>();
        services.AddScoped<ISubModuleService, SubModuleService>();
        services.AddScoped<ISubModuleService, SubModuleService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
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
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        // Register IUserSettingRepository with its concrete implementation UserSettingRepository
        services.AddScoped<IUserSettingRepository, UserSettingRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}