using ACL.Database.Models;
using ACL.Domain;
using ACL.Domain.Permissions;

namespace ACL.Application.Ports.Services;

public interface IPermissionService
{
    public Task<AclUser> GetUserWithPermissionAsync(uint userId);
}