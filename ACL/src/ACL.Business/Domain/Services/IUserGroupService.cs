using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
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
