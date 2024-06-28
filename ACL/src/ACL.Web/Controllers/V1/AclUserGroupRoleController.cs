using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Ports.Services.UserGroup;
using ACL.Application.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
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
            AclUserGroupRoleService = _AclUserGroupRoleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public AclResponse Index(ulong userGroupId)
        {
            return AclUserGroupRoleService.GetRolesByUserGroupId(userGroupId);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await AclUserGroupRoleService.Update(objUserGroupRole);
        }


    }
}
