using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IRolePageRepository : IRepository<RolePage>, IExtendedRepositoryBase<RolePage>
    {
        /// <inheritdoc/>
        List<RolePage>? All();
        /// <inheritdoc/>
        RolePage? Find(ulong id);
        /// <inheritdoc/>
        RolePage? Add(RolePage rolePage);
        /// <inheritdoc/>
        RolePage? Update(RolePage rolePage);
        /// <inheritdoc/>
        RolePage? Delete(RolePage rolePage);
        /// <inheritdoc/>
        PageRoute? Delete(ulong id);
        /// <inheritdoc/>
        RolePage[]? AddAll(RolePage[] aclRolePages);
        /// <inheritdoc/>
        RolePage[]? DeleteAll(RolePage[] aclRolePages);
        /// <inheritdoc/>
        RolePage[]? DeleteAllByRoleId(ulong roleId);
    }
}
