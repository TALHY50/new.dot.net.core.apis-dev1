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
    [Tags("Module")]
    [ApiController]
    public class AclModuleController : ControllerBase
    {
        IModuleService _moduleService;
        /// <inheritdoc/>
        public AclModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.List, Name = AclRoutesName.AclModuleRouteNames.List)]
        public ScopeResponse Index()
        {
            return _moduleService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclModuleRouteUrl.Add, Name = AclRoutesName.AclModuleRouteNames.Add)]
        public ScopeResponse Create(AclModuleRequest moduleRequest)
        {
            return _moduleService.AddAclModule(moduleRequest);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclModuleRouteUrl.Edit, Name = AclRoutesName.AclModuleRouteNames.Edit)]
        public ScopeResponse Edit(AclModuleRequest moduleRequest)
        {
            return _moduleService.EditAclModule(moduleRequest);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.View, Name = AclRoutesName.AclModuleRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return _moduleService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclModuleRouteUrl.Destroy, Name = AclRoutesName.AclModuleRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return _moduleService.DeleteModule(id);
        }
    }
}
