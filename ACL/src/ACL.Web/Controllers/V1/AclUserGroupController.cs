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
    [Tags("User Group")]
    [ApiController]
    public class AclUserGroupController : Controller
    {
        private readonly IAclUserGroupService AclUserGroupService;
        /// <inheritdoc/>
        public AclUserGroupController(IAclUserGroupService _AclUserGroupService)
        {
            AclUserGroupService = _AclUserGroupService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.List, Name = AclRoutesName.AclUserGroupRouteNames.List)]
        public AclResponse Index()
        {
            return AclUserGroupService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRouteUrl.Add, Name = AclRoutesName.AclUserGroupRouteNames.Add)]
        public AclResponse AclResponseCreate(AclUserGroupRequest request)
        {
            return AclUserGroupService.AddUserGroup(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserGroupRouteUrl.Edit, Name = AclRoutesName.AclUserGroupRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclUserGroupRequest request)
        {
            return AclUserGroupService.UpdateUserGroup(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.View, Name = AclRoutesName.AclUserGroupRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return  AclUserGroupService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserGroupRouteUrl.Destroy, Name = AclRoutesName.AclUserGroupRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return AclUserGroupService.Delete(id);
        }
    }
}
