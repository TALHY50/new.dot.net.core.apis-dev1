using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Services.Role;
using Notification.Application.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Role")]
    [ApiController]
    public class AclRoleController : ControllerBase
    {
        private readonly IAclRoleService AclRoleService;
         /// <inheritdoc/>
        public AclRoleController(IAclRoleService _AclRoleService)
        {
            AclRoleService = _AclRoleService;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.List, Name = AclRoutesName.AclRoleRouteNames.List)]
        public AclResponse Index()
        {
            return AclRoleService.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclRoleRouteUrl.Add, Name = AclRoutesName.AclRoleRouteNames.Add)]
        public AclResponse Create(AclRoleRequest objRole)
        {
            return AclRoleService.Add(objRole);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.View, Name = AclRoutesName.AclRoleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return  AclRoleService.FindById(id);

        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRoleRouteUrl.Edit, Name = AclRoutesName.AclRoleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclRoleRequest objRole)
        {
            return  AclRoleService.Edit(id, objRole);

        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclRoleRouteUrl.Destroy, Name = AclRoutesName.AclRoleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return AclRoleService.DeleteById(id);
        }

    }
}
