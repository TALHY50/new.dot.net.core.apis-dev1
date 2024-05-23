using ACL.Core.Entities.Auth;

namespace ACL.Application.Ports.Repositories.Auth
{
    /// <inheritdoc/>
    public interface IAclUserUserGroupRepository
    {
        /// <inheritdoc/>
        List<AclUserUsergroup>? All();
        /// <inheritdoc/>
        AclUserUsergroup? Find(ulong id);
        /// <inheritdoc/>
        AclUserUsergroup? Add(AclUserUsergroup acluseruserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Update(AclUserUsergroup aclUserUserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(AclUserUsergroup aclUserUserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(ulong id);
        /// <inheritdoc/>
        AclUserUsergroup[]? AddRange( AclUserUsergroup[]? userUserGroups);
        /// <inheritdoc/>
        AclUserUsergroup[]? RemoveRange( AclUserUsergroup[] userUserGroups);
        /// <inheritdoc/>
        AclUserUsergroup[]? Where(ulong userid);
    }
}
