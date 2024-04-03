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

        [HttpGet("modules", Name = "modules")]
        public async Task<IActionResult> Index()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost("modules/add", Name = "modules/add")]
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

        [HttpPut("modules/edit/{Id}", Name = "modules/edit/{Id}")]
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
        [HttpGet("modules/view/{Id}", Name = "modules/view/{Id}")]
        public async Task<IActionResult> View(ulong Id)
        {
            try
            {
                var result = _repository.FindById(Id);
                return Ok((result==null)?"AclCompanyModule with ID {Id} not found":result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("modules/delete/{Id}", Name = "modules/delete/{Id}")]
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
