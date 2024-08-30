using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
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
