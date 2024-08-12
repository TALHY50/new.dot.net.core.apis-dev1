﻿using ACL.App.Domain.Company;

namespace ACL.App.Domain.Ports.Repositories.Company
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