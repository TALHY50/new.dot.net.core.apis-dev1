using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
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
