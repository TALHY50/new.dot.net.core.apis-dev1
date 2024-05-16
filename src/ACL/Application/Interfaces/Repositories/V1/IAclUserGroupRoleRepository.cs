using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclUserGroupRoleRepository 
    {
        Task<AclResponse> GetRolesByUserGroupId(ulong groupId);
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
