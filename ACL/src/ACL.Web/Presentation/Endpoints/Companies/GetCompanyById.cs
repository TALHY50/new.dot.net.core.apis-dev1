using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Companies;

public class GetCompanyById : CompanyBase
{
    public GetCompanyById(ICompanyService companyService) : base(companyService)
    {
    }
    

    
    [Authorize(Policy = "HasPermission")]
    [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.View, Name = AclRoutesName.AclCompanyRouteNames.View)]
    public ScopeResponse View(ulong id)
    {
        return this.CompanyService.FindById(id);
    }
}