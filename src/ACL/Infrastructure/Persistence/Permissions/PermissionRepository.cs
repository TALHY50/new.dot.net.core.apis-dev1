using ACL.Application.Ports.Repositories;
using ACL.Database;
using ACL.Domain;
using ACL.Domain.Permissions;

namespace ACL.Infrastructure.Persistence.Permissions;

public class PermissionRepository(ApplicationDbContext applicationDbContext) : IPermissionRepository
{

    private readonly ApplicationDbContext dbContext = applicationDbContext;

    public async Task<List<PermissionQueryResult>> GetPermissionQueryAsync(uint userId)
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
        return result;
    }
}