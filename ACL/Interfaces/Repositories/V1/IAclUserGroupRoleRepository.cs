
using ACL.Database.Models;
using ACL.Repositories;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclUserGroupRoleRepository : IGenericRepository<AclUsergroupRole>
    {
        AclResponse GetRolesByUserGroupId(ulong groupId);
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
    }
}
