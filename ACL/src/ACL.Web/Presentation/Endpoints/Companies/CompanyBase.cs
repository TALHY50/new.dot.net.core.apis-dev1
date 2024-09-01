using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Companies;

[Authorize]
[Tags("Company")]
[ApiController]
public class CompanyBase : ApiControllerBase
{
    public required ICompanyService CompanyService;
    
    public CompanyBase(ICompanyService companyService)
    {
        this.CompanyService = companyService;
    }

}