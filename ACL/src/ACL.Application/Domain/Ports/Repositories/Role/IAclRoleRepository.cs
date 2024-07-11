using Notification.Application.Domain.Role;

namespace ACL.Application.Domain.Ports.Repositories.Role

{
    /// <inheritdoc/>
    public interface IAclRoleRepository
    {
        /// <inheritdoc/>
        List<AclRole>? All();
        /// <inheritdoc/>
        AclRole? Find(ulong id);
        /// <inheritdoc/>
        AclRole? Add(AclRole aclRole);
        /// <inheritdoc/>
        AclRole? Update(AclRole aclRole);
        /// <inheritdoc/>
        AclRole? Delete(AclRole aclRole);
        /// <inheritdoc/>
        AclRole? Delete(ulong id);
        /// <inheritdoc/>
        bool IsExist(ulong id);
    }
}
