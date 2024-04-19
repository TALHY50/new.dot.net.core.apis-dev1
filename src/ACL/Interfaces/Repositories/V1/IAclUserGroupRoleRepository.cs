
using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclUserGroupRoleRepository : IGenericRepository<AclUsergroupRole>
    {
        Task<AclResponse> GetRolesByUserGroupId(ulong groupId);
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
