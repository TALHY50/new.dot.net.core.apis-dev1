using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.Submodules
{
    /// <inheritdoc/>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[Tags("Sub Module")]
    [ApiController]
    public class SubModuleController : ControllerBase
    {
        //private readonly ISubModuleService _subModuleService;
        ///// <inheritdoc/>
        //public SubModuleController(ISubModuleService subModuleService)
        //{
        //    this._subModuleService = subModuleService;
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = AclRoutesName.AclSubmoduleRouteNames.List)]
        //public ScopeResponse Index()
        //{
        //    return this._subModuleService.GetAll();
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpPost(AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = AclRoutesName.AclSubmoduleRouteNames.Add)]
        //public ScopeResponse Create(AclSubModuleRequest objSubModule)
        //{
        //    return this._subModuleService.Add(objSubModule);
        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpGet(AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = AclRoutesName.AclSubmoduleRouteNames.View)]
        //public ScopeResponse View(uint id)
        //{
        //    return this._subModuleService.FindById(id);

        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpPut(AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = AclRoutesName.AclSubmoduleRouteNames.Edit)]
        //public ScopeResponse Edit( AclSubModuleRequest objSubModule)
        //{
        //    return this._subModuleService.Edit( objSubModule);

        //}
        ///// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpDelete(AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        //public ScopeResponse Destroy(uint id)
        //{
        //    return this._subModuleService.DeleteById(id);
        //}
    }
}
