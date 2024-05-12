using ACL.Domain.Permissions;

namespace ACL.Application.Ports.Repositories;

public interface IPermissionRepository
{
    public Task<List<PermissionQueryResult>> GetPermissionQueryAsync(uint userId);
}