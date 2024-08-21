using ACL.App.Application.Interfaces.Repositories.Module;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace ACL.App.Application.Interfaces.Services.Module
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
