using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IModuleService : IModuleRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse AddAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        ScopeResponse EditAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        ScopeResponse DeleteModule(uint id);
    }
}
