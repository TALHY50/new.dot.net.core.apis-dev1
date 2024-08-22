using ACL.App.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts.ACL.Requests;
using SharedKernel.Main.Contracts.ACL.Response;
using SharedKernel.Main.Domain.ACL.Services.UserGroup;

namespace ACL.App.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User Group")]
    [ApiController]
    public class AclUserGroupController : Controller
    {
        private readonly IAclUserGroupService AclUserGroupService;
        /// <inheritdoc/>
        public AclUserGroupController(IAclUserGroupService _AclUserGroupService)
        {
            this.AclUserGroupService = _AclUserGroupService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.List, Name = AclRoutesName.AclUserGroupRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclUserGroupService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRouteUrl.Add, Name = AclRoutesName.AclUserGroupRouteNames.Add)]
        public AclResponse AclResponseCreate(AclUserGroupRequest request)
        {
            return this.AclUserGroupService.AddUserGroup(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserGroupRouteUrl.Edit, Name = AclRoutesName.AclUserGroupRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclUserGroupRequest request)
        {
            return this.AclUserGroupService.UpdateUserGroup(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.View, Name = AclRoutesName.AclUserGroupRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return  this.AclUserGroupService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserGroupRouteUrl.Destroy, Name = AclRoutesName.AclUserGroupRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclUserGroupService.Delete(id);
        }
    }
}
