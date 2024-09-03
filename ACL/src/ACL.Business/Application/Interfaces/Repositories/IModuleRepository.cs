using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IModuleRepository : IRepository<Module>, IExtendedRepositoryBase<Module>
    {
        /// <inheritdoc/>
        List<Module>? All();
        /// <inheritdoc/>
        Module? Find(ulong id);
        /// <inheritdoc/>
        Module? Add(Module aclModule);
        /// <inheritdoc/>
        Module? Update(Module aclModule);
        /// <inheritdoc/>
        Module? Delete(Module aclModule);
        /// <inheritdoc/>
        Module? Delete(ulong id);
        /// <inheritdoc/>
        bool ExistByName(ulong id, string name);
        /// <inheritdoc/>
        bool ExistById(ulong? id, ulong value);

        bool IsModuleNameAlreadyExist(string name, ulong? requestId = null);
        bool IsModuleIdAlreadyExist(ulong id, ulong? requestId = null);
    }
}
