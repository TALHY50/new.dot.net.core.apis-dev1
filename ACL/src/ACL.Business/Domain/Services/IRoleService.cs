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
        ScopeResponse Edit(uint id, AclRoleRequest roleRequest);
        /// <inheritdoc/>
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(uint id);
    }
}
