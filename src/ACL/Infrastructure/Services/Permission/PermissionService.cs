using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Database.Models;

namespace ACL.Infrastructure.Services.Permission;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        this._permissionRepository = permissionRepository;
    }
    public async Task<AclUser> GetUserWithPermissionAsync(uint userId)
    {
        var queryResult = await this._permissionRepository.GetPermissionQueryAsync(userId);

        {
            HashSet<string> permittedRoutes = new HashSet<string>(queryResult.Select(q => q.PageRouteName));
            var permission = new Domain.Permissions.Permission(permittedRoutes);
            var permissionVersion = queryResult.FirstOrDefault().PermissionVersion;
            var user = new AclUser(userId, permissionVersion, permission);
            
            return user;
        }
        
    }
}