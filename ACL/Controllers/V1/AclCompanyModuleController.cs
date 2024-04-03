using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces.Repositories;
using ACL.Requests.V1;
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

        [HttpGet("module", Name = "module")]
        public async Task<IActionResult> Index()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost("module/add", Name = "module/add")]
        public async Task<IActionResult> Create(AclCompanyModuleRequest request)
        {
            try
            {
                var result = _repository.AddAclCompanyModule(request);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("module/edit/{Id}", Name = "module/edit/{Id}")]
        public async Task<IActionResult> Edit(ulong Id, [FromBody] AclCompanyModuleRequest request)
        {
            try
            {
                var result = _repository.EditAclCompanyModule(Id, request);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("module/view/{Id}", Name = "module/view/{Id}")]
        public async Task<IActionResult> View(ulong Id)
        {
            try
            {
                var result = _repository.FindById(Id);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("module/delete/{Id}", Name = "module/delete/{Id}")]
        public async Task<IActionResult> Destroy(ulong Id)
        {
            try
            {
                var result = _repository.DeleteModule(Id);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
