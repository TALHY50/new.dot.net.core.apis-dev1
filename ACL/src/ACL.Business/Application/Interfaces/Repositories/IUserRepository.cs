using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserRepository : IRepository<User>, IExtendedRepositoryBase<User>
    {
        User? FindByIdAsync(uint id);
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
        User? Find(uint id);
        /// <inheritdoc/>
        User? Add(User user);
        /// <inheritdoc/>
        User? Update(User user);
        /// <inheritdoc/>
        User? Delete(User user);
        /// <inheritdoc/>
        User? Delete(uint id);

        List<uint>? GetUserIdByChangePermission(uint? module_id = null, uint? sub_module_id = null, uint? page_id = null, uint? role_id = null, uint? user_group_id = null);
        void UpdateUserPermissionVersion(List<uint> userIds);

        bool IsExist(uint id);

    }

}
