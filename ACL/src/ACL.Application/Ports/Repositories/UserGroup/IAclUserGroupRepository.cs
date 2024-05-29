using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.UserGroup;

namespace ACL.Application.Ports.Repositories.UserGroup
{
    /// <inheritdoc/>
    public interface IAclUserGroupRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse AddUserGroup(AclUserGroupRequest userGroupRequest);
        /// <inheritdoc/>
        AclResponse UpdateUserGroup(ulong id, AclUserGroupRequest userGroup);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse Delete(ulong id);
        /// <inheritdoc/>
        AclUsergroup PrepareInputData(AclUserGroupRequest userGroupRequest, AclUsergroup? aclUserGroup = null);
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
    }
}
