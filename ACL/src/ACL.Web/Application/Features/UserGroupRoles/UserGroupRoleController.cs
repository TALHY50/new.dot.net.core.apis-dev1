using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.UserGroupRoles
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User Group Role")]
    [ApiController]
    public class UserGroupRoleController : ControllerBase
    {
        private readonly IUserGroupRoleService _userGroupRoleService;
        /// <inheritdoc/>
        public UserGroupRoleController(IUserGroupRoleService userGroupRoleService)
        {
            this._userGroupRoleService = userGroupRoleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public ApplicationResponse Index(uint userGroupId)
        {
            return this._userGroupRoleService.GetRolesByUserGroupId(userGroupId);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<ApplicationResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await this._userGroupRoleService.Update(objUserGroupRole);
        }


    }
}
