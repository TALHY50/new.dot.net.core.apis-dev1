using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Auth;


namespace ACL.Application.Ports.Repositories.Auth
{
    /// <inheritdoc/>
    public interface IAclUserRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddUser(AclUserRequest request);
        /// <inheritdoc/>
        Task<AclResponse> Edit(ulong id, AclUserRequest request);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclUser? FindByIdAsync(ulong id);
        /// <inheritdoc/>
        AclUser? FindByEmail(string email);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
        /// <inheritdoc/>
        uint SetCompanyId(uint companyId);
        /// <inheritdoc/>
        uint SetUserType(bool is_user_type_created_by_company);
        /// <inheritdoc/>
        AclUser? AddAndSaveAsync(AclUser aclUser);
        /// <inheritdoc/>
        AclUser? UpdateAndSaveAsync(AclUser aclUser);
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

        List<ulong>? GetUserIdByChangePermission(ulong? module_id = null, ulong? sub_module_id = null, ulong? page_id = null, ulong? role_id = null, ulong? user_group_id = null);
        void UpdateUserPermissionVersion(List<ulong> user_ids);

    }

}
