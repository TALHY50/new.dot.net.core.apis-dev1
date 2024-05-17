using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Ports.Repositories
{
    /// <inheritdoc/>
    public interface IAclUserRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddUser(AclUserRequest request);
        /// <inheritdoc/>
        Task<AclResponse> Edit(ulong id, AclUserRequest request);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclUser> FindByIdAsync(ulong id);
        /// <inheritdoc/>
        Task<AclUser> FindByEmail(string email);
        /// <inheritdoc/>
        Task<AclResponse> DeleteById(ulong id);
        /// <inheritdoc/>
        uint SetCompanyId(uint companyId);
        /// <inheritdoc/>
        uint SetUserType(bool is_user_type_created_by_company);
        /// <inheritdoc/>
        public Task<AclUser> AddAndSaveAsync(AclUser aclUser);
        /// <inheritdoc/>
        public Task<AclUser> UpdateAndSaveAsync(AclUser aclUser);
        /// <inheritdoc/>
        public Task<AclUser?> GetUserWithPermissionAsync(uint userId);
        /// <inheritdoc/>
        List<AclUser>? All();
        /// <inheritdoc/>
        AclUser? Find(ulong id);
        /// <inheritdoc/>
        AclUser? Add(AclUser aclUser);
        /// <inheritdoc/>
        AclUser? Update(AclUser aclUser);
        /// <inheritdoc/>
        AclUser? Delete(AclUser aclUser);
        /// <inheritdoc/>
        AclUser? Delete(ulong id);
    }
}
