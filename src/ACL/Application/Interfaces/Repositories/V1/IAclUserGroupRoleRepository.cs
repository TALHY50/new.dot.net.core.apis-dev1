using ACL.Core.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclUserGroupRoleRepository : IGenericRepository<AclUsergroupRole>
    {
        Task<AclResponse> GetRolesByUserGroupId(ulong groupId);
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
