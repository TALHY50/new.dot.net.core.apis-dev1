using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
{
    public interface IUserGroupRoleService : IUserGroupRoleRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<ScopeResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
