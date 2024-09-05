using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Companies;

public class CreateCompany : CompanyBase
{
    public CreateCompany(ICompanyService companyService) : base(companyService)
    {
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize(Policy = "HasPermission")]
    [HttpPost(AclRoutesUrl.AclCompanyRouteUrl.Add, Name = AclRoutesName.AclCompanyRouteNames.Add)]
    public Task<ScopeResponse> Create(AclCompanyCreateRequest request)
    {
        return  this.CompanyService.AddAclCompany(request);
    }
}