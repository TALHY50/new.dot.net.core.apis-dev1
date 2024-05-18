using ACL.Core.Models;
using ACL.UseCases.Ports.Repositories;
using ACL.UseCases.Ports.Services;

namespace ACL.Infrastructure.Services.Permission;

public class PermissionService(IAclUserRepository aclUserRepository) : IPermissionService
{
    public async Task<AclUser?> GetUserAsync(uint userId)
    {
        return await aclUserRepository.GetUserWithPermissionAsync(userId);

    }
}