using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclUserGroupRepository : IGenericRepository<AclUsergroup>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddUserGroup(UserGroupRequest usergroup);
        Task<AclResponse> UpdateUserGroup(ulong id, UserGroupRequest usergroup);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> Delete(ulong id);
        AclUsergroup PrepareInputData(UserGroupRequest request, AclUsergroup aclCompany = null);
    }
}
