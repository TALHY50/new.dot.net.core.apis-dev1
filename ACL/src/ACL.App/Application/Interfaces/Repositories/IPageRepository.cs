using ACL.App.Domain.Entities;

namespace ACL.App.Application.Interfaces.Repositories
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
