﻿using ACL.Application.Domain.Module;

namespace ACL.Application.Domain.Ports.Repositories.Module
{
    /// <inheritdoc/>
    public interface IAclPageRepository
    {
        /// <inheritdoc/>
        List<AclPage>? All();
        /// <inheritdoc/>
        AclPage? Find(ulong id);
        /// <inheritdoc/>
        AclPage? Add(AclPage aclPage);
        /// <inheritdoc/>
        AclPage? Update(AclPage aclPage);
        /// <inheritdoc/>
        AclPage? Delete(AclPage aclPage);
        /// <inheritdoc/>
        AclPage? Delete(ulong id);
        /// <inheritdoc/>
        bool IsExist(ulong id);
    }
}