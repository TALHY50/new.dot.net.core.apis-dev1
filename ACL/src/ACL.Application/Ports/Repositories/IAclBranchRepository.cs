using ACL.Core.Entities.Company;

namespace ACL.Application.Ports.Repositories
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
