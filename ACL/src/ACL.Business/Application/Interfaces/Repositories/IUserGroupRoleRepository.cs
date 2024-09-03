using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserGroupRoleRepository : IRepository<UsergroupRole>, IExtendedRepositoryBase<UsergroupRole>
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
