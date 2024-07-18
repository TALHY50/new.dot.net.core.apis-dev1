using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Module;

namespace App.Domain.Ports.Services.Module
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
