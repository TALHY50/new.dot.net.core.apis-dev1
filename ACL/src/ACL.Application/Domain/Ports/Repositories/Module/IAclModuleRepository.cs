using Notification.Application.Domain.Module;

namespace ACL.Application.Domain.Ports.Repositories.Module
{
    /// <inheritdoc/>
    public interface IAclModuleRepository
    {
        /// <inheritdoc/>
        List<AclModule>? All();
        /// <inheritdoc/>
        AclModule? Find(ulong id);
        /// <inheritdoc/>
        AclModule? Add(AclModule aclModule);
        /// <inheritdoc/>
        AclModule? Update(AclModule aclModule);
        /// <inheritdoc/>
        AclModule? Delete(AclModule aclModule);
        /// <inheritdoc/>
        AclModule? Delete(ulong id);
        /// <inheritdoc/>
        bool ExistByName(ulong id, string name);
        /// <inheritdoc/>
        bool ExistById(ulong? id, ulong value);

        bool IsModuleNameAlreadyExist(string name, ulong? requestId = null);
        bool IsModuleIdAlreadyExist(ulong id, ulong? requestId = null);
    }
}
