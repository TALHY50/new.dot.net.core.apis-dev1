using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;

namespace SharedKernel.Main.ACL.Domain.Services
{
    public interface IRoleService : IRoleRepository
    {
        /// <inheritdoc/>
       ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse Add(AclRoleRequest roleRequest);
        /// <inheritdoc/>
        ScopeResponse Edit(ulong id, AclRoleRequest roleRequest);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(ulong id);
    }
}
