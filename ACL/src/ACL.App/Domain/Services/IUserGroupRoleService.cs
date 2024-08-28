using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;

namespace ACL.App.Domain.Services
{
    public interface IUserGroupRoleService : IUserGroupRoleRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<ScopeResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
