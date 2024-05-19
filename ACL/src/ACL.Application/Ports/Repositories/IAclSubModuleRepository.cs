using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;

namespace ACL.Application.Ports.Repositories
{
    /// <inheritdoc/>
    public interface IAclSubModuleRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
        /// <inheritdoc/>
        List<AclSubModule>? All();
        /// <inheritdoc/>
        AclSubModule? Find(ulong id);
        /// <inheritdoc/>
        AclSubModule? Add(AclSubModule aclSubModule);
        /// <inheritdoc/>
        AclSubModule? Update(AclSubModule aclSubModule);
        /// <inheritdoc/>
        AclSubModule? Delete(AclSubModule aclSubModule);
        /// <inheritdoc/>
        AclSubModule? Delete(ulong id);
        /// <inheritdoc/>
        bool ExistByName(ulong id, string name);
        /// <inheritdoc/>
        bool ExistById(ulong? id, ulong value);
    }
}
