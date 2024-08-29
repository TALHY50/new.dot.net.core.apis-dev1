using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;

namespace ACL.App.Domain.Services
{
    public interface IUserGroupService : IUserGroupRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse AddUserGroup(AclUserGroupRequest userGroupRequest);
        /// <inheritdoc/>
        ScopeResponse UpdateUserGroup(ulong id, AclUserGroupRequest userGroup);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse Delete(ulong id);
        /// <inheritdoc/>
        Usergroup PrepareInputData(AclUserGroupRequest userGroupRequest, Usergroup? aclUserGroup = null);
    }
}
