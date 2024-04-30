using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclUserRepository : IGenericRepository<AclUser>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddUser(AclUserRequest request);
        Task<AclResponse> Edit(ulong id, AclUserRequest request);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);
        uint SetCompanyId(uint companyId);
        uint SetUserType(bool is_user_type_created_by_company);
    }
}
