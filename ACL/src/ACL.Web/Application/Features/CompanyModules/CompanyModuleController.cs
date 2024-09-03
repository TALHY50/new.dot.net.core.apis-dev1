using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.CompanyModules
{
    /// <inheritdoc/>
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
        public ApplicationResponse Index()
        {
            return  this._companyModuleService.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public ApplicationResponse Create(AclCompanyModuleRequest request)
        {
            return this._companyModuleService.AddAclCompanyModule(request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyModuleRouteUrl.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public ApplicationResponse Edit(uint id, AclCompanyModuleRequest request)
        {
            return this._companyModuleService.EditAclCompanyModule(id, request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public ApplicationResponse View(uint id)
        {
            return this._companyModuleService.FindById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public ApplicationResponse Destroy(uint id)
        {
            return this._companyModuleService.DeleteCompanyModule(id);
        }
    }
}
