using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.UserGroup;

namespace ACL.Application.Ports.Repositories
{
    /// <inheritdoc/>
    public interface IAclUserGroupRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse AddUserGroup(AclUserGroupRequest userGroupRequest);
        /// <inheritdoc/>
        AclResponse UpdateUserGroup(ulong id, AclUserGroupRequest userGroupRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse Delete(ulong id);
        /// <inheritdoc/>
        AclUsergroup PrepareInputData(AclUserGroupRequest userGroupRequest, AclUsergroup aclCompany = null);
        /// <inheritdoc/>
        ulong SetCompanyId(ulong companyId);
        /// <inheritdoc/>
        List<AclUsergroup>? All();
        /// <inheritdoc/>
        AclUsergroup? Find(ulong id);
        /// <inheritdoc/>
        AclUsergroup? Add(AclUsergroup aclUsergroup);
        /// <inheritdoc/>
        AclUsergroup? Update(AclUsergroup aclUsergroup);
        /// <inheritdoc/>
        AclUsergroup? Delete(AclUsergroup aclUsergroup);
        /// <inheritdoc/>
        AclUsergroup? Deleted(ulong id);
    }
}
