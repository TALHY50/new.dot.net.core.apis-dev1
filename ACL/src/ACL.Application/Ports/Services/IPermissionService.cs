using ACL.Core.Entities;
using ACL.Core.Entities.Auth;

namespace ACL.Application.Ports.Services;

public interface IPermissionService
{
    public Task<AclUser> GetUserAsync(uint userId);
}