using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserRepository
    {
        User? FindByIdAsync(ulong id);
        /// <inheritdoc/>
        User? FindByEmail(string email);
        /// <inheritdoc/>
        uint SetCompanyId(uint companyId);
        /// <inheritdoc/>
        uint SetUserType(bool is_user_type_created_by_company);
        /// <inheritdoc/>
        User? AddAndSaveAsync(User user);
        /// <inheritdoc/>
        User? UpdateAndSaveAsync(User user);
        /// <inheritdoc/>
        public Task<User?> GetUserWithPermissionAsync(uint userId);
        /// <inheritdoc/>
        List<User>? All();
        /// <inheritdoc/>
        User? Find(ulong id);
        /// <inheritdoc/>
        User? Add(User user);
        /// <inheritdoc/>
        User? Update(User user);
        /// <inheritdoc/>
        User? Delete(User user);
        /// <inheritdoc/>
        User? Delete(ulong id);

        List<ulong>? GetUserIdByChangePermission(ulong? module_id = null, ulong? sub_module_id = null, ulong? page_id = null, ulong? role_id = null, ulong? user_group_id = null);
        void UpdateUserPermissionVersion(List<ulong> userIds);

        bool IsExist(ulong id);

    }

}
