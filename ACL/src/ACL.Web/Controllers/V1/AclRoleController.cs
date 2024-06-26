using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Repositories.Role;
using ACL.Application.Ports.Services.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
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
