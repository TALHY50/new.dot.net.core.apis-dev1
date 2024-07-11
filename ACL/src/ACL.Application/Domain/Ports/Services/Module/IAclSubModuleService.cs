using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Repositories.Module;

namespace ACL.Application.Domain.Ports.Services.Module
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
