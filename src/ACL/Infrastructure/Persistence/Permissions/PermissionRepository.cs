using ACL.Application.Ports.Repositories;
using ACL.Database;
using ACL.Domain;
using ACL.Domain.Permissions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ACL.Infrastructure.Persistence.Permissions;

public class PermissionRepository(ApplicationDbContext applicationDbContext, IDistributedCache distributedCache = null) : IPermissionRepository
{

    private readonly ApplicationDbContext dbContext = applicationDbContext;
    private readonly IDistributedCache _distributedCache = distributedCache;

    public async Task<Permission> GetPermissionAsync(uint userId, uint userPermissionVersion)
    {
        HashSet<string>? permittedRoutes = null;
        
        var key = $"userId_PermissionVersion-{userId}_{userPermissionVersion}";

        if (this._distributedCache is IDistributedCache)
        {

            string? cachedPermittedRoutes = await this._distributedCache.GetStringAsync(key);

            if (cachedPermittedRoutes != null)
            {
                permittedRoutes =
                    JsonConvert.DeserializeObject<HashSet<string>>(cachedPermittedRoutes) ?? null;
            }
        }

        if (permittedRoutes == null)
        {
            var result = (from user in dbContext.AclUsers
                join userUsergroup in dbContext.AclUserUsergroups on user.Id equals userUsergroup.UserId
                join usergroup in dbContext.AclUsergroups on userUsergroup.UsergroupId equals usergroup.Id
                join usergroupRole in dbContext.AclUsergroupRoles on usergroup.Id equals usergroupRole.UsergroupId
                join role in dbContext.AclRoles on usergroupRole.RoleId equals role.Id
                join rolePage in dbContext.AclRolePages on role.Id equals rolePage.RoleId
                join page in dbContext.AclPages on rolePage.PageId equals page.Id
                join pageRoute in dbContext.AclPageRoutes on page.Id equals pageRoute.PageId
                join subModule in dbContext.AclSubModules on page.SubModuleId equals subModule.Id
                join module in dbContext.AclModules on subModule.ModuleId equals module.Id
                where user.Id == userId
                select new PermissionQueryResult()
                {
                    UserId = user.Id,
                    PermissionVersion = user.PermissionVersion,
                    PageId = page.Id,
                    PageName = page.Name,
                    PageRouteName = pageRoute.RouteName,
                    UsergroupId = usergroup.Id,
                    DefaultUrl = usergroup.DashboardUrl,
                    UsergroupCategory = usergroup.Category,
                    ModuleId = module.Id,
                    ControllerName = subModule.ControllerName,
                    SubmoduleName = subModule.Name,
                    SubmoduleId = subModule.Id,
                    MethodName = page.MethodName,
                    MethodType = page.MethodType,
                    DefaultMethod = subModule.DefaultMethod
                }).ToList();

            if (result != null)
            {
                permittedRoutes = new HashSet<string>(result.Select(q => q.PageRouteName)!);
            }

            if (this._distributedCache is IDistributedCache)
            {
                await this._distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(permittedRoutes));
            }
        }
        
        var permission = new Permission(userPermissionVersion, permittedRoutes);
        return permission;
    }
}