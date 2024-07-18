using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Ports.Repositories.UserGroup;
using ACL.Application.Domain.UserGroup;

namespace ACL.Application.Domain.Ports.Services.UserGroup
{
    public interface IAclUserGroupService : IAclUserGroupRepository
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
    }
}
