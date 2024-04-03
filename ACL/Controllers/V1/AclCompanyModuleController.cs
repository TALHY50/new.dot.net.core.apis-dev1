using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces.Repositories;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
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
    public class AclCompanyModuleController : ControllerBase
    {
        private readonly IAclCompanyModuleRepository _repository;

        public AclCompanyModuleController(IAclCompanyModuleRepository aclModuleRepository)
        {
            _repository = aclModuleRepository;
        }

        [HttpGet("modules", Name = "modules")]
        public async Task<AclResponse> Index()
        {
            return _repository.GetAll();
        }

        [HttpPost("modules/add", Name = "modules/add")]
        public async Task<AclResponse> Create(AclCompanyModuleRequest objSubModule)
        {
            return _repository.AddAclCompanyModule(objSubModule);
        }

        [HttpPut("modules/edit/{Id}", Name = "modules/edit/{Id}")]
        public async Task<AclResponse> Edit(ulong id, AclCompanyModuleRequest objSubModule)
        {
            return _repository.EditAclCompanyModule(id, objSubModule);
        }
        [HttpGet("modules/view/{Id}", Name = "modules/view/{Id}")]
        public async Task<AclResponse> View(ulong id)
        {
            return _repository.FindById(id);
        }

        [HttpDelete("modules/delete/{Id}", Name = "modules/delete/{Id}")]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _repository.DeleteModule(id);
        }
    }
}
