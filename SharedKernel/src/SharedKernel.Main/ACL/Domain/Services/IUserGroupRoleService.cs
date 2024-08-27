using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;

namespace SharedKernel.Main.ACL.Domain.Services
{
    public interface IUserGroupRoleService : IUserGroupRoleRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<ScopeResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
