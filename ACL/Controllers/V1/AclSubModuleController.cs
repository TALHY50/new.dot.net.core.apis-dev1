using ACL.Database;
using ACL.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACL.Controllers.V1
{
    [ApiController]
    [Route("api/v1")]
    public class AclSubModuleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AclSubModuleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("submodules", Name = "acl.submodule.list")]
        public async Task<IActionResult> Index()
        {
            var _AclSubModules = await _context.AclSubModules.ToListAsync();
            return Ok(_AclSubModules);
        }


        [HttpPost("submodules/add",Name = "acl.submodule.add")]
        public async Task<IActionResult> Create(AclSubModule objSubModule)
        {
            if (ModelState.IsValid)
            {
                _context.AclSubModules.Add(objSubModule);
                await _context.SaveChangesAsync();
                return Ok(objSubModule);
            }
            return BadRequest(ModelState);

        }

        [HttpGet("submodules/view/{id}", Name = "acl.submodule.view")]
        public async Task<IActionResult> View(ulong id)
        {
            var objSubModule = await _context.AclSubModules.FindAsync(id);
            return Ok(objSubModule);

        }


        [HttpPut("submodules/edit/{id}", Name = "acl.submodule.edit")]
        public async Task<IActionResult> Edit(ulong id, AclSubModule objSubModule)
        {
            if (ModelState.IsValid && id == objSubModule.Id)
            {
                _context.Entry(objSubModule).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(objSubModule);
            }
            return BadRequest("Id is not valid.");

        }


        [HttpDelete("submodules/delete/{id}", Name = "acl.submodule.destroy")]
        public async Task<IActionResult> Destroy(ulong ID)
        {
            var subModule = _context.AclSubModules.Find(ID);
            if (subModule != null)
            {
                _context.Entry(subModule).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return  Ok("Sub Module Successfully Deleted.");
            }

            return BadRequest("Sub Module not found.");
        }




    }
}
