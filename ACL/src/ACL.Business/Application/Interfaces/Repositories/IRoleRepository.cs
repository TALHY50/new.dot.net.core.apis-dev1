using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories

{
    /// <inheritdoc/>
    public interface IRoleRepository
    {
        /// <inheritdoc/>
        List<Role>? All();
        /// <inheritdoc/>
        Role? Find(uint id);
        /// <inheritdoc/>
        Role? Add(Role role);
        /// <inheritdoc/>
        Role? Update(Role role);
        /// <inheritdoc/>
        Role? Delete(Role role);
        /// <inheritdoc/>
        Role? Delete(uint id);
        /// <inheritdoc/>
        bool IsExist(uint id);
    }
}
