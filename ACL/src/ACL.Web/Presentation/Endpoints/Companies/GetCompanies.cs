using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Companies;

public class GetCompanies : CompanyBase
{
    public GetCompanies(ICompanyService companyService) : base(companyService)
    {
    }
    
    [Authorize(Policy = "HasPermission")]
    [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.List, Name = AclRoutesName.AclCompanyRouteNames.List)]
    public ApplicationResponse Index()
    {
        return  this.CompanyService.GetAll();
    }
}