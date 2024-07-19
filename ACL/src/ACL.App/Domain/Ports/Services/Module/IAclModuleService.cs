using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Repositories.Module;

namespace ACL.App.Domain.Ports.Services.Module
{
    public interface IAclModuleService : IAclModuleRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse AddAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        AclResponse EditAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        AclResponse DeleteModule(ulong id);
    }
}
