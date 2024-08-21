using ACL.App.Application.Interfaces.Repositories.UserGroup;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.UserGroup;

namespace ACL.App.Application.Interfaces.Services.UserGroup
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
