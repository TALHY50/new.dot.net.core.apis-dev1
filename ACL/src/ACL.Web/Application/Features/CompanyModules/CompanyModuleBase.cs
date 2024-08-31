using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;

namespace ACL.Web.Application.Features.CompanyModules;
[Authorize]
[Tags("Company Module")]
[ApiController]
public class CompanyModuleBase : ApiControllerBase
{
    private readonly ICompanyModuleService _companyModuleService;
    
    public CompanyModuleBase(ICompanyModuleService companyModuleService)
    {
        this._companyModuleService = companyModuleService;
    }
    
}