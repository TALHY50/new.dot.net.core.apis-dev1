using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
{
    public interface IUserGroupService : IUserGroupRepository
    {
        /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        ApplicationResponse AddUserGroup(AclUserGroupRequest userGroupRequest);
        /// <inheritdoc/>
        ApplicationResponse UpdateUserGroup(uint id, AclUserGroupRequest userGroup);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse Delete(uint id);
        /// <inheritdoc/>
        Usergroup PrepareInputData(AclUserGroupRequest userGroupRequest, Usergroup? aclUserGroup = null);
    }
}
