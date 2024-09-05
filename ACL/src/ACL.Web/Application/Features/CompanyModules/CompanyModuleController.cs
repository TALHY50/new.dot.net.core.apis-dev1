using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.CompanyModules
{
    /// <inheritdoc/>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Tags("Company Module")]
    [ApiController]
    public class CompanyModuleController : ControllerBase
    {

      private readonly ICompanyModuleService _companyModuleService;
        /// <inheritdoc/>
        public CompanyModuleController(ICompanyModuleService companyModuleService)
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
        public ScopeResponse Edit(uint id, AclCompanyModuleRequest request)
        {
            return this._companyModuleService.EditAclCompanyModule(id, request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public ScopeResponse View(uint id)
        {
            return this._companyModuleService.FindById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public ScopeResponse Destroy(uint id)
        {
            return this._companyModuleService.DeleteCompanyModule(id);
        }
    }
}
