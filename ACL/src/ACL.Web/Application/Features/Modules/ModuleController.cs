using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.Modules
{
    /// <inheritdoc/>
    [Authorize]
    //[Tags("Module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        //IModuleService _moduleService;
        ///// <inheritdoc/>
        //public ModuleController(IModuleService moduleService)
        //{
        //    this._moduleService = moduleService;
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpGet(AclRoutesUrl.AclModuleRouteUrl.List, Name = AclRoutesName.AclModuleRouteNames.List)]
        //public ScopeResponse Index()
        //{
        //    return this._moduleService.GetAll();
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpPost(AclRoutesUrl.AclModuleRouteUrl.Add, Name = AclRoutesName.AclModuleRouteNames.Add)]
        //public ScopeResponse Create(AclModuleRequest moduleRequest)
        //{
        //    return this._moduleService.AddAclModule(moduleRequest);
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpPut(AclRoutesUrl.AclModuleRouteUrl.Edit, Name = AclRoutesName.AclModuleRouteNames.Edit)]
        //public ScopeResponse Edit(AclModuleRequest moduleRequest)
        //{
        //    return this._moduleService.EditAclModule(moduleRequest);
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpGet(AclRoutesUrl.AclModuleRouteUrl.View, Name = AclRoutesName.AclModuleRouteNames.View)]
        //public ScopeResponse View(uint id)
        //{
        //    return this._moduleService.FindById(id);
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpDelete(AclRoutesUrl.AclModuleRouteUrl.Destroy, Name = AclRoutesName.AclModuleRouteNames.Destroy)]
        //public ScopeResponse Destroy(uint id)
        //{
        //    return this._moduleService.DeleteModule(id);
        //}
    }
}
