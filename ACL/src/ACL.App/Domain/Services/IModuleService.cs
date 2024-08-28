using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;

namespace ACL.App.Domain.Services
{
    public interface IModuleService : IModuleRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse AddAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        ScopeResponse EditAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        ScopeResponse DeleteModule(ulong id);
    }
}
