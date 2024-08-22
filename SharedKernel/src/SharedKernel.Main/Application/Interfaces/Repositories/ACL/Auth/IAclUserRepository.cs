using SharedKernel.Main.Domain.ACL.Domain.Auth;

namespace SharedKernel.Main.Application.Interfaces.Repositories.ACL.Auth
{
    /// <inheritdoc/>
    public interface IAclUserRepository
    {
        AclUser? FindByIdAsync(ulong id);
        /// <inheritdoc/>
        AclUser? FindByEmail(string email);
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
        void UpdateUserPermissionVersion(List<ulong> userIds);

        bool IsExist(ulong id);

    }

}
