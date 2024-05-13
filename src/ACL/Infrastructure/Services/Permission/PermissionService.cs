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
    public async Task<AclUser> GetUserAsync(uint userId, uint userPermissionVersion)
    {
        var permissions = await this._permissionRepository.GetPermissionAsync(userId, userPermissionVersion);

        {
            var user = new AclUser(userId, permissions.Version, permissions);
            
            return user;
        }
        
    }
}