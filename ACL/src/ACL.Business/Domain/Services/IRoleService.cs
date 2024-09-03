using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IRoleService : IRoleRepository
    {
        /// <inheritdoc/>
       ApplicationResponse GetAll();
        /// <inheritdoc/>
        ApplicationResponse Add(AclRoleRequest roleRequest);
        /// <inheritdoc/>
        ApplicationResponse Edit(uint id, AclRoleRequest roleRequest);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse DeleteById(uint id);
    }
}
