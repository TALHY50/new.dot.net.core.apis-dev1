using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPageRepository
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
