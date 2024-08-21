using ACL.App.Application.Interfaces.Repositories.Module;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace ACL.App.Application.Interfaces.Services.Module
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
