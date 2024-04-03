using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces.Repositories;
using ACL.Requests;
using ACL.Services;
using Craftgate.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ACL.Controllers.V1
{
    [ApiController]
    [Route("api/v1/company/")]
    public class AclModuleController : ControllerBase
    {
        private readonly IAclModuleRepository _repository;

        public AclModuleController(IAclModuleRepository aclModuleRepository)
        {
            _repository = aclModuleRepository;
        }

         [HttpGet("module", Name = "module")]
        public async Task<IActionResult> Index()
        {
            return Ok( _repository.GetAll());
        }
        
        [HttpPost("module/add", Name = "module/add")]
        public async Task<IActionResult> Create(AclCompanyModuleRequest request)
        {
            bool valid = _repository.IsValidForCreateOrUpdate(request.CompanyId,request.ModuleId);
            var result = new AclCompanyModule();
            if (valid)
            {
                AclCompanyModule aclCompany = new AclCompanyModule(){ 
                    CompanyId = request.CompanyId,
                    ModuleId = request.ModuleId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    };
               result = _repository.Add(aclCompany) ;
            }
            return Ok(result);
        }

    }
}
