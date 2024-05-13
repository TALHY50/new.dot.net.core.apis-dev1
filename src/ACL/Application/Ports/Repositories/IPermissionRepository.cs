using ACL.Domain.Permissions;

namespace ACL.Application.Ports.Repositories;

public interface IPermissionRepository
{
    public Task<Permission> GetPermissionAsync(uint userId, uint userPermissionVersion);
}