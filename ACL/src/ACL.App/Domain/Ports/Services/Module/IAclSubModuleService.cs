using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Repositories.Module;

namespace ACL.App.Domain.Ports.Services.Module
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
