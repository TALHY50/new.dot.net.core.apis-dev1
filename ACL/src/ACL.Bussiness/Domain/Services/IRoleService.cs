using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
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
