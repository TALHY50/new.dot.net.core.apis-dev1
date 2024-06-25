using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;

namespace ACL.Application.Ports.Repositories.Module
{
    /// <inheritdoc/>
    public interface IAclSubModuleRepository
    {
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

    }
}
