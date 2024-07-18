using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Module;

namespace App.Domain.Ports.Services.Module
{
    public interface IAclSubModuleService : IAclSubModuleRepository
    {
         /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        AclResponse Edit(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
    }
}
