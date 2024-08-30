using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace ACL.App.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User Group Role")]
    [ApiController]
    public class AclUserGroupRoleController : ControllerBase
    {
        private readonly IUserGroupRoleService _userGroupRoleService;
        /// <inheritdoc/>
        public AclUserGroupRoleController(IUserGroupRoleService userGroupRoleService)
        {
            this._userGroupRoleService = userGroupRoleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public ScopeResponse Index(ulong userGroupId)
        {
            return this._userGroupRoleService.GetRolesByUserGroupId(userGroupId);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<ScopeResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await this._userGroupRoleService.Update(objUserGroupRole);
        }


    }
}
