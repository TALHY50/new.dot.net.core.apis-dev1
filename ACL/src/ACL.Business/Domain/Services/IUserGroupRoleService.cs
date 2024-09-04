using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
{
    public interface IUserGroupRoleService : IUserGroupRoleRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetRolesByUserGroupId(uint groupId);
        /// <inheritdoc/>
        Task<ScopeResponse> Update(AclUserGroupRoleRequest userGroupRole);

        List<UsergroupRole>? FindByUserGroupId(uint userGroupId);

    }
}
