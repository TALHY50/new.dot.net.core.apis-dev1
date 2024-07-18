using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Services.Module;
using App.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Application.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Module")]
    [ApiController]
    public class AclModuleController : ControllerBase
    {
        IAclModuleService AclModuleService;
        /// <inheritdoc/>
        public AclModuleController(IAclModuleService aclModuleService)
        {
            this.AclModuleService = aclModuleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.List, Name = AclRoutesName.AclModuleRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclModuleService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclModuleRouteUrl.Add, Name = AclRoutesName.AclModuleRouteNames.Add)]
        public AclResponse Create(AclModuleRequest moduleRequest)
        {
            return this.AclModuleService.AddAclModule(moduleRequest);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclModuleRouteUrl.Edit, Name = AclRoutesName.AclModuleRouteNames.Edit)]
        public AclResponse Edit(AclModuleRequest moduleRequest)
        {
            return this.AclModuleService.EditAclModule(moduleRequest);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.View, Name = AclRoutesName.AclModuleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclModuleService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclModuleRouteUrl.Destroy, Name = AclRoutesName.AclModuleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclModuleService.DeleteModule(id);
        }
    }
}
