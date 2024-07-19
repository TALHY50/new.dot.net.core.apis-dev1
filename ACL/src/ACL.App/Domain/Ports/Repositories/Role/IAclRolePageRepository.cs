using ACL.App.Domain.Module;
using ACL.App.Domain.Role;

namespace ACL.App.Domain.Ports.Repositories.Role
{
    /// <inheritdoc/>
    public interface IAclRolePageRepository
    {
        /// <inheritdoc/>
        List<AclRolePage>? All();
        /// <inheritdoc/>
        AclRolePage? Find(ulong id);
        /// <inheritdoc/>
        AclRolePage? Add(AclRolePage aclRolePage);
        /// <inheritdoc/>
        AclRolePage? Update(AclRolePage aclRolePage);
        /// <inheritdoc/>
        AclRolePage? Delete(AclRolePage aclRolePage);
        /// <inheritdoc/>
        AclPageRoute? Delete(ulong id);
        /// <inheritdoc/>
        AclRolePage[]? AddAll(AclRolePage[] aclRolePages);
        /// <inheritdoc/>
        AclRolePage[]? DeleteAll(AclRolePage[] aclRolePages);
        /// <inheritdoc/>
        AclRolePage[]? DeleteAllByRoleId(ulong roleId);
    }
}
