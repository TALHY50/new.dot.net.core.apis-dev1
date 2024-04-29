using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclUserGroupRepository : IGenericRepository<AclUsergroup>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddUserGroup(AclUserGroupRequest usergroup);
        Task<AclResponse> UpdateUserGroup(ulong id, AclUserGroupRequest usergroup);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> Delete(ulong id);
        AclUsergroup PrepareInputData(AclUserGroupRequest request, AclUsergroup aclCompany = null);
        ulong SetCompanyId(ulong companyId);
    }
}
