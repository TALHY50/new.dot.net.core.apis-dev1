using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IModuleRepository
    {
        /// <inheritdoc/>
        List<Module>? All();
        /// <inheritdoc/>
        Module? Find(uint id);
        /// <inheritdoc/>
        Module? Add(Module aclModule);
        /// <inheritdoc/>
        Module? Update(Module aclModule);
        /// <inheritdoc/>
        Module? Delete(Module aclModule);
        /// <inheritdoc/>
        Module? Delete(uint id);
        /// <inheritdoc/>
        bool ExistByName(uint id, string name);
        /// <inheritdoc/>
        bool ExistById(uint? id, uint value);

        bool IsModuleNameAlreadyExist(string name, uint? requestId = null);
        bool IsModuleIdAlreadyExist(uint id, uint? requestId = null);
    }
}
