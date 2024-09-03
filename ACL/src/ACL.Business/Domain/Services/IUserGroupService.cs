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
        ScopeResponse UpdateUserGroup(uint id, AclUserGroupRequest userGroup);
        /// <inheritdoc/>
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse Delete(uint id);
        /// <inheritdoc/>
        Usergroup PrepareInputData(AclUserGroupRequest userGroupRequest, Usergroup? aclUserGroup = null);
    }
}
