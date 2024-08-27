using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;

namespace SharedKernel.Main.ACL.Domain.Services
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
