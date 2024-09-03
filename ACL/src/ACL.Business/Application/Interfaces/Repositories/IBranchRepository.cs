using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IBranchRepository : IRepository<Branch>, IExtendedRepositoryBase<Branch>
    {
        /// <inheritdoc/>
        IEnumerable<Branch>? All();
        /// <inheritdoc/>
        Branch? GetById(uint id);
        /// <inheritdoc/>
        Branch? Add(Branch entity);
        /// <inheritdoc/>
        Branch? Update(Branch entity);
        /// <inheritdoc/>
        bool Delete(Branch entity);
        /// <inheritdoc/>
        Branch? Delete(uint id);
    }
}
