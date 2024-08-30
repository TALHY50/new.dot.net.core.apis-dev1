using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserGroupRoleRepository
    {
        /// <inheritdoc/>
        List<UsergroupRole>? All();
        /// <inheritdoc/>
        UsergroupRole? Find(ulong id);
        /// <inheritdoc/>
        UsergroupRole? Add(UsergroupRole userGroupRole);
        /// <inheritdoc/>
        UsergroupRole? Update(UsergroupRole userGroupRole);
        /// <inheritdoc/>
        UsergroupRole? Delete(UsergroupRole userGroupRole);
        /// <inheritdoc/>
        UsergroupRole? Delete(ulong id);
    }
}
