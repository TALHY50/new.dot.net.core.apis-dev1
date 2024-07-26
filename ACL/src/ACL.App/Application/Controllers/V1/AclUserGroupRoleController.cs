using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Services.UserGroup;
using ACL.App.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.App.Application.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User Group Role")]
    [ApiController]
    public class AclUserGroupRoleController : ControllerBase
    {
        private readonly IAclUserGroupRoleService AclUserGroupRoleService;
        /// <inheritdoc/>
        public AclUserGroupRoleController(IAclUserGroupRoleService _AclUserGroupRoleService)
        {
            this.AclUserGroupRoleService = _AclUserGroupRoleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public AclResponse Index(ulong userGroupId)
        {
            return this.AclUserGroupRoleService.GetRolesByUserGroupId(userGroupId);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await this.AclUserGroupRoleService.Update(objUserGroupRole);
        }


    }
}
