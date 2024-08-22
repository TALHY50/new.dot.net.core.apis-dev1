using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.UserGroup;
using SharedKernel.Main.Contracts.ACL.Requests;
using SharedKernel.Main.Contracts.ACL.Response;

namespace SharedKernel.Main.Domain.ACL.Services.UserGroup
{
    public interface IAclUserGroupRoleService : IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        AclResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
