using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Application.Interfaces.Repositories

{
    /// <inheritdoc/>
    public interface IRoleRepository
    {
        /// <inheritdoc/>
        List<Role>? All();
        /// <inheritdoc/>
        Role? Find(ulong id);
        /// <inheritdoc/>
        Role? Add(Role role);
        /// <inheritdoc/>
        Role? Update(Role role);
        /// <inheritdoc/>
        Role? Delete(Role role);
        /// <inheritdoc/>
        Role? Delete(ulong id);
        /// <inheritdoc/>
        bool IsExist(ulong id);
    }
}
