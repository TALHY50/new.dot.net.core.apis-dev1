using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Repositories.Role;

namespace ACL.Application.Domain.Ports.Services.Role
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
