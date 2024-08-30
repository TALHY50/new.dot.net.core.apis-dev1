using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace ACL.Web.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Company")]
    [ApiController]
    public class AclCompanyController : Controller
    {
        /// <inheritdoc/>
        public  required ICompanyService CompanyService;
        /// <inheritdoc/>
        public AclCompanyController(ICompanyService companyService)
        {
            this.CompanyService = companyService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.List, Name = AclRoutesName.AclCompanyRouteNames.List)]
        public ScopeResponse Index()
        {
            return  this.CompanyService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyRouteUrl.Add, Name = AclRoutesName.AclCompanyRouteNames.Add)]
        public Task<ScopeResponse> Create(AclCompanyCreateRequest request)
        {
            return  this.CompanyService.AddAclCompany(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyRouteUrl.Edit, Name = AclRoutesName.AclCompanyRouteNames.Edit)]
        public ScopeResponse Edit(ulong id, AclCompanyEditRequest request)
        {
            return  this.CompanyService.EditAclCompany(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.View, Name = AclRoutesName.AclCompanyRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return this.CompanyService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyRouteUrl.Destroy, Name = AclRoutesName.AclCompanyRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return  this.CompanyService.DeleteCompany(id);
        }
    }
}
