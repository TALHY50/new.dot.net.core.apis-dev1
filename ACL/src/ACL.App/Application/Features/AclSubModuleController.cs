using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.Web.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Sub Module")]
    [ApiController]
    public class AclSubModuleController : ControllerBase
    {
        private readonly ISubModuleService _subModuleService;
        /// <inheritdoc/>
        public AclSubModuleController(ISubModuleService subModuleService)
        {
            _subModuleService = subModuleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = AclRoutesName.AclSubmoduleRouteNames.List)]
        public ScopeResponse Index()
        {
            return _subModuleService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = AclRoutesName.AclSubmoduleRouteNames.Add)]
        public ScopeResponse Create(AclSubModuleRequest objSubModule)
        {
            return _subModuleService.Add(objSubModule);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = AclRoutesName.AclSubmoduleRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return _subModuleService.FindById(id);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public ScopeResponse Edit(AclSubModuleRequest objSubModule)
        {
            return _subModuleService.Edit(objSubModule);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return _subModuleService.DeleteById(id);
        }
    }
}
