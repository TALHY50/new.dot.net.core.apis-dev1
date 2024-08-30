using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
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
