using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Database.Models;

namespace ACL.Infrastructure.Services.Permission;

public class PermissionService(IAclUserRepository aclUserRepository) : IPermissionService
{
    public async Task<AclUser?> GetUserAsync(uint userId, uint userPermissionVersion)
    {
        return await aclUserRepository.GetUserWithPermissionAsync(userId, userPermissionVersion);

    }
}