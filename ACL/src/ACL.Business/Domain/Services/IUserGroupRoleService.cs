using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IUserGroupRoleService : IUserGroupRoleRepository
    {
        /// <inheritdoc/>
        ApplicationResponse GetRolesByUserGroupId(uint groupId);
        /// <inheritdoc/>
        Task<ApplicationResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
