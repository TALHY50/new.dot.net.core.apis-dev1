using ACL.App.Domain.UserGroup;

namespace ACL.App.Domain.Ports.Repositories.UserGroup
{
    /// <inheritdoc/>
    public interface IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        List<AclUsergroupRole>? All();
        /// <inheritdoc/>
        AclUsergroupRole? Find(ulong id);
        /// <inheritdoc/>
        AclUsergroupRole? Add(AclUsergroupRole aclUserGroupRole);
        /// <inheritdoc/>
        AclUsergroupRole? Update(AclUsergroupRole aclUserGroupRole);
        /// <inheritdoc/>
        AclUsergroupRole? Delete(AclUsergroupRole aclUserGroupRole);
        /// <inheritdoc/>
        AclUsergroupRole? Delete(ulong id);
    }
}
