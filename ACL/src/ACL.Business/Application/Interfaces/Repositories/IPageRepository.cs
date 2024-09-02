using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPageRepository : IRepository<Page>, IExtendedRepositoryBase<Page>
    {
        /// <inheritdoc/>
        List<Page>? All();
        /// <inheritdoc/>
        Page? Find(ulong id);
        /// <inheritdoc/>
        Page? Add(Page page);
        /// <inheritdoc/>
        Page? Update(Page page);
        /// <inheritdoc/>
        Page? Delete(Page page);
        /// <inheritdoc/>
        Page? Delete(ulong id);
        /// <inheritdoc/>
        bool IsExist(ulong id);
    }
}
