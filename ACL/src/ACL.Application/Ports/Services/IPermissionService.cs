using ACL.Core.Models;

namespace ACL.Application.Ports.Services;

public interface IPermissionService
{
    public Task<AclUser> GetUserAsync(uint userId);
}