using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclUserRepository : IGenericRepository<AclUser>
    {
        AclResponse GetAll();
        Task<AclResponse> AddUser(AclUserRequest request);
        AclResponse Edit(ulong id, AclUserRequest request);
        AclResponse findById(ulong id);
        AclResponse deleteById(ulong id);
        uint SetCompanyId(uint companyId);
        uint SetUserType(bool is_user_type_created_by_company);
    }
}
