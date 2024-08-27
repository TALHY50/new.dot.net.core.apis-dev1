using ACL.App.Domain.Entities;

namespace ACL.App.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ISubModuleRepository
    {
        /// <inheritdoc/>
        List<SubModule>? All();
        /// <inheritdoc/>
        SubModule? Find(ulong id);
        /// <inheritdoc/>
        SubModule? Add(SubModule subModule);
        /// <inheritdoc/>
        SubModule? Update(SubModule subModule);
        /// <inheritdoc/>
        SubModule? Delete(SubModule subModule);
        /// <inheritdoc/>
        SubModule? Delete(ulong id);

    }
}
