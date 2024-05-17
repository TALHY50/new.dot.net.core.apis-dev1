using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
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
