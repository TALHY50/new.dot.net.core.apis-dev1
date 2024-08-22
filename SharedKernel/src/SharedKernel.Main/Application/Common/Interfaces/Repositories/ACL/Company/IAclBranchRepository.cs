using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Company
{
    /// <inheritdoc/>
    public interface IAclBranchRepository
    {
        /// <inheritdoc/>
        IEnumerable<AclBranch>? All();
        /// <inheritdoc/>
        AclBranch? GetById(ulong id);
        /// <inheritdoc/>
        AclBranch? Add(AclBranch entity);
        /// <inheritdoc/>
        AclBranch? Update(AclBranch entity);
        /// <inheritdoc/>
        bool Delete(AclBranch entity);
        /// <inheritdoc/>
        AclBranch? Delete(ulong id);
    }
}
