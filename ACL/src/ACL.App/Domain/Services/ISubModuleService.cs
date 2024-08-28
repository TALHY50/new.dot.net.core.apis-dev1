using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;

namespace ACL.App.Domain.Services
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
