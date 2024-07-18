using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.UserGroup;

namespace App.Domain.Ports.Services.UserGroup
{
    public interface IAclUserGroupRoleService : IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        AclResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
