﻿using ACL.Application.Domain.UserGroup;

namespace ACL.Application.Domain.Ports.Repositories.UserGroup
{
    /// <inheritdoc/>
    public interface IAclUserGroupRepository
    {
        /// <inheritdoc/>
        ulong SetCompanyId(ulong companyId);
        /// <inheritdoc/>
        List<AclUsergroup>? All();
        /// <inheritdoc/>
        AclUsergroup? Find(ulong id);
        /// <inheritdoc/>
        AclUsergroup? Add(AclUsergroup aclUserGroup);
        /// <inheritdoc/>
        AclUsergroup? Update(AclUsergroup aclUserGroup);
        /// <inheritdoc/>
        AclUsergroup? Delete(AclUsergroup aclUserGroup);
        /// <inheritdoc/>
        AclUsergroup? Deleted(ulong id);
        /// <inheritdoc/>
        bool IsExist(ulong id);
    }
}