using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Domain.Services
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
