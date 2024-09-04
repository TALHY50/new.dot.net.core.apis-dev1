using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories

{
    /// <inheritdoc/>
    public interface IRoleRepository : IRepository<Role>, IExtendedRepositoryBase<Role>
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
        public string ExistByTitle(uint? id, string title);
        public string ExistByName(uint? id, string name);
    }
}
