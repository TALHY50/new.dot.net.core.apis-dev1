using ACL.App.Application.Interfaces.Services.Module;
using ACL.App.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace ACL.App.Application.Features
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
            this.AclSubModuleService = _AclSubModuleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = AclRoutesName.AclSubmoduleRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclSubModuleService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = AclRoutesName.AclSubmoduleRouteNames.Add)]
        public AclResponse Create(AclSubModuleRequest objSubModule)
        {
            return this.AclSubModuleService.Add(objSubModule);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = AclRoutesName.AclSubmoduleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclSubModuleService.FindById(id);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public AclResponse Edit( AclSubModuleRequest objSubModule)
        {
            return this.AclSubModuleService.Edit( objSubModule);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclSubModuleService.DeleteById(id);
        }
    }
}
