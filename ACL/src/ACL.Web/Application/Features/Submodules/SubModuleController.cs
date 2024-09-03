using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.Submodules
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Sub Module")]
    [ApiController]
    public class SubModuleController : ControllerBase
    {
        private readonly ISubModuleService _subModuleService;
        /// <inheritdoc/>
        public SubModuleController(ISubModuleService subModuleService)
        {
            this._subModuleService = subModuleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = AclRoutesName.AclSubmoduleRouteNames.List)]
        public ApplicationResponse Index()
        {
            return this._subModuleService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = AclRoutesName.AclSubmoduleRouteNames.Add)]
        public ApplicationResponse Create(AclSubModuleRequest objSubModule)
        {
            return this._subModuleService.Add(objSubModule);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = AclRoutesName.AclSubmoduleRouteNames.View)]
        public ApplicationResponse View(uint id)
        {
            return this._subModuleService.FindById(id);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public ApplicationResponse Edit( AclSubModuleRequest objSubModule)
        {
            return this._subModuleService.Edit( objSubModule);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public ApplicationResponse Destroy(uint id)
        {
            return this._subModuleService.DeleteById(id);
        }
    }
}
