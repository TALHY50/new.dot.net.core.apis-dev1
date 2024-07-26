using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Repositories.UserGroup;

namespace ACL.App.Domain.Ports.Services.UserGroup
{
    public interface IAclUserGroupRoleService : IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        AclResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
