
using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Services.Module;
using Notification.Application.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Sub Module")]
    [ApiController]
    public class AclSubModuleController : ControllerBase
    {
        private readonly IAclSubModuleService AclSubModuleService;
        /// <inheritdoc/>
        public AclSubModuleController(IAclSubModuleService _AclSubModuleService)
        {
            AclSubModuleService = _AclSubModuleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = AclRoutesName.AclSubmoduleRouteNames.List)]
        public AclResponse Index()
        {
            return AclSubModuleService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = AclRoutesName.AclSubmoduleRouteNames.Add)]
        public AclResponse Create(AclSubModuleRequest objSubModule)
        {
            return AclSubModuleService.Add(objSubModule);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = AclRoutesName.AclSubmoduleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return AclSubModuleService.FindById(id);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public AclResponse Edit( AclSubModuleRequest objSubModule)
        {
            return AclSubModuleService.Edit( objSubModule);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return AclSubModuleService.DeleteById(id);
        }
    }
}
