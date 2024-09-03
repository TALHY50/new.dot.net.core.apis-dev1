using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Companies;

public class UpdateCompanyById : CompanyBase
{
    public UpdateCompanyById(ICompanyService companyService) : base(companyService)
    {
    }
    [Authorize(Policy = "HasPermission")]
    [HttpPut(AclRoutesUrl.AclCompanyRouteUrl.Edit, Name = AclRoutesName.AclCompanyRouteNames.Edit)]
    public ApplicationResponse Edit(uint id, AclCompanyEditRequest request)
    {
        return  this.CompanyService.EditAclCompany(id, request);
    }
}