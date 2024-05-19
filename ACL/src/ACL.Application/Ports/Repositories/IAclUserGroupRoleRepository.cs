using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.UserGroup;

namespace ACL.Application.Ports.Repositories
{
    /// <inheritdoc/>
    public interface IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        AclResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
        /// <inheritdoc/>
        List<AclUsergroupRole>? All();
        /// <inheritdoc/>
        AclUsergroupRole? Find(ulong id);
        /// <inheritdoc/>
        AclUsergroupRole? Add(AclUsergroupRole aclUsergroupRole);
        /// <inheritdoc/>
        AclUsergroupRole? Update(AclUsergroupRole aclUsergroupRole);
        /// <inheritdoc/>
        AclUsergroupRole? Delete(AclUsergroupRole aclUsergroupRole);
        /// <inheritdoc/>
        AclUsergroupRole? Delete(ulong id);
    }
}
