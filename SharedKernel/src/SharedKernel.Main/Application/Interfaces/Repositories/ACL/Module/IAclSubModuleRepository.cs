using SharedKernel.Main.Domain.ACL.Domain.Module;

namespace SharedKernel.Main.Application.Interfaces.Repositories.ACL.Module
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