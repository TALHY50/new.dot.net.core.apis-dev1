using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IBranchRepository
    {
        /// <inheritdoc/>
        IEnumerable<Branch>? All();
        /// <inheritdoc/>
        Branch? GetById(ulong id);
        /// <inheritdoc/>
        Branch? Add(Branch entity);
        /// <inheritdoc/>
        Branch? Update(Branch entity);
        /// <inheritdoc/>
        bool Delete(Branch entity);
        /// <inheritdoc/>
        Branch? Delete(ulong id);
    }
}
