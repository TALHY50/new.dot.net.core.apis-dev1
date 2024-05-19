using ACL.Core.Entities;

namespace ACL.Application.Ports.Services;

public interface IPermissionService
{
    public Task<AclUser> GetUserAsync(uint userId);
}