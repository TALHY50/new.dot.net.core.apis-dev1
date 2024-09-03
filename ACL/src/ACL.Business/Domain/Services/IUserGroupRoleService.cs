using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IUserGroupRoleService : IUserGroupRoleRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<ScopeResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
