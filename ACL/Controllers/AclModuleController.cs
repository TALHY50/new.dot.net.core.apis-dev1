using ACL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ACL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AclModuleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AclModuleController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "AclModule")]
        public async Task<IActionResult> Get()
        {
            var _AclCompanyModules = await _context.AclCompanyModules.ToListAsync();

            return Ok(_AclCompanyModules);
        }

    }
}
