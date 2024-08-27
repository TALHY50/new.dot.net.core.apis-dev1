using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;

namespace SharedKernel.Main.ACL.Domain.Services
{
    public interface ISubModuleService : ISubModuleRepository
    {
         /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse Add(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        ScopeResponse Edit(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(ulong id);
    }
}
