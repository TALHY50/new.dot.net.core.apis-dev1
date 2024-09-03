using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPageRepository
    {
        /// <inheritdoc/>
        List<Page>? All();
        /// <inheritdoc/>
        Page? Find(uint id);
        /// <inheritdoc/>
        Page? Add(Page page);
        /// <inheritdoc/>
        Page? Update(Page page);
        /// <inheritdoc/>
        Page? Delete(Page page);
        /// <inheritdoc/>
        Page? Delete(uint id);
        /// <inheritdoc/>
        bool IsExist(uint id);
    }
}
