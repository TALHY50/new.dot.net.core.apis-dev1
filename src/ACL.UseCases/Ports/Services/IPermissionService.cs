using ACL.Core.Models;

namespace ACL.UseCases.Ports.Services;

public interface IPermissionService
{
    public Task<AclUser> GetUserAsync(uint userId);
}