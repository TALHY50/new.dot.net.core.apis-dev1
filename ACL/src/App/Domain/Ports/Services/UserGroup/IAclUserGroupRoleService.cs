using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Ports.Repositories.UserGroup;

namespace ACL.Application.Domain.Ports.Services.UserGroup
{
    public interface IAclUserGroupRoleService : IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        AclResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
