using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Core.Models;

namespace ACL.Infrastructure.Services.Permission;

public class PermissionService(IAclUserRepository aclUserRepository) : IPermissionService
{
    public async Task<AclUser?> GetUserAsync(uint userId)
    {
        return await aclUserRepository.GetUserWithPermissionAsync(userId);

    }
}