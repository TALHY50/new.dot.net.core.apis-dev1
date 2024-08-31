using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.CompanyModules;

public class CreateCompanyModule : CompanyModuleBase
{
    public CreateCompanyModule(ICompanyModuleService companyModuleService) : base(companyModuleService)
    {
    }
}