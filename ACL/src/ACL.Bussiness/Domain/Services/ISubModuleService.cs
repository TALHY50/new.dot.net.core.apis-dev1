using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
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
