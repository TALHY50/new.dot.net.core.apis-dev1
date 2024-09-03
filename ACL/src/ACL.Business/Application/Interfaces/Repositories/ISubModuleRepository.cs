using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ISubModuleRepository : IRepository<SubModule>, IExtendedRepositoryBase<SubModule>
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
