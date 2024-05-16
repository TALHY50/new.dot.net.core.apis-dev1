using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Ports.Repositories
{
    public interface IAclUserRepository 
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddUser(AclUserRequest request);
        Task<AclResponse> Edit(ulong id, AclUserRequest request);
        Task<AclResponse> FindById(ulong id);
        
        Task<AclUser> FindByIdAsync(ulong id);
        
        Task<AclUser> FindByEmail(string email);
        
        Task<AclResponse> DeleteById(ulong id);
        uint SetCompanyId(uint companyId);
        uint SetUserType(bool is_user_type_created_by_company);

        public Task<AclUser> AddAndSaveAsync(AclUser entity);
        
        public Task<AclUser> UpdateAndSaveAsync(AclUser entity);

        public Task<AclUser?> GetUserWithPermissionAsync(uint userId);


    }
}
