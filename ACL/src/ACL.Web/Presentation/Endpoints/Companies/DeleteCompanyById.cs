using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Companies;

public class DeleteCompanyById: CompanyBase
{
    public DeleteCompanyById(ICompanyService companyService) : base(companyService)
    {
    }
    
    [Authorize(Policy = "HasPermission")]
    [HttpDelete(AclRoutesUrl.AclCompanyRouteUrl.Destroy, Name = AclRoutesName.AclCompanyRouteNames.Destroy)]
    public ScopeResponse Destroy(ulong id)
    {
        return  this.CompanyService.DeleteCompany(id);
    }
}