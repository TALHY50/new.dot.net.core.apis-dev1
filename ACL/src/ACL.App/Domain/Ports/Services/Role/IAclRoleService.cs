using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Repositories.Role;

namespace ACL.App.Domain.Ports.Services.Role
{
    public interface IAclRoleService : IAclRoleRepository
    {
        /// <inheritdoc/>
       AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclRoleRequest roleRequest);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclRoleRequest roleRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
    }
}
