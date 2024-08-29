using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.App.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Company Module")]
    [ApiController]
    public class AclCompanyModuleController : ControllerBase
    {

      private readonly ICompanyModuleService _companyModuleService;
        /// <inheritdoc/>
        public AclCompanyModuleController(ICompanyModuleService companyModuleService)
        {
            this._companyModuleService = companyModuleService;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Name = AclRoutesName.AclCompanyModuleRouteNames.List)]
        public ScopeResponse Index()
        {
            return  this._companyModuleService.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public ScopeResponse Create(AclCompanyModuleRequest request)
        {
            return this._companyModuleService.AddAclCompanyModule(request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyModuleRouteUrl.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public ScopeResponse Edit(ulong id, AclCompanyModuleRequest request)
        {
            return this._companyModuleService.EditAclCompanyModule(id, request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return this._companyModuleService.FindById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return this._companyModuleService.DeleteCompanyModule(id);
        }
    }
}
