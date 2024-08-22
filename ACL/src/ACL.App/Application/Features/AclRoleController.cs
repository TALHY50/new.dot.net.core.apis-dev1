using ACL.App.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Services.Role;

namespace ACL.App.Application.Features
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
            this.AclRoleService = _AclRoleService;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.List, Name = AclRoutesName.AclRoleRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclRoleService.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclRoleRouteUrl.Add, Name = AclRoutesName.AclRoleRouteNames.Add)]
        public AclResponse Create(AclRoleRequest objRole)
        {
            return this.AclRoleService.Add(objRole);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.View, Name = AclRoutesName.AclRoleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return  this.AclRoleService.FindById(id);

        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRoleRouteUrl.Edit, Name = AclRoutesName.AclRoleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclRoleRequest objRole)
        {
            return  this.AclRoleService.Edit(id, objRole);

        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclRoleRouteUrl.Destroy, Name = AclRoutesName.AclRoleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclRoleService.DeleteById(id);
        }

    }
}
