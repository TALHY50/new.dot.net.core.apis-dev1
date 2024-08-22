using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Role;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace SharedKernel.Main.Domain.ACL.Services.Role
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
