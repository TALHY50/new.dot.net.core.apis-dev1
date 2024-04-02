using ACL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACL.Database.Models;

namespace ACL.Controllers.V1
{

    [ApiController]
    [Route("api/v1/")]
    public class AclPageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AclPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("pages", Name = "acl.company.list")]
        public async Task<IActionResult> Index()
        {
            var AclPage = await _context.AclPages.ToListAsync();
            return Ok(AclPage);
        }

        [HttpPost("pages/add", Name = "acl.page.add")]
        public IActionResult Create(AclPage AclPage)
        {
            _context.AclPages.Add(AclPage);
            _context.SaveChanges();
            return Ok(AclPage);
        }
        [HttpPut("pages/edit/{id}", Name = "acl.page.edit")]
        public async Task<IActionResult> Edit(ulong id, AclPage AclPage)
        {

            if (ModelState.IsValid && id == AclPage.Id)
            {
                _context.Entry(AclPage).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(AclPage);
            }
            return BadRequest("Id is not valid.");

        }

        [HttpDelete("pages/delete/{id}", Name = "acl.page.destroy")]
        public IActionResult Destroy(ulong id)
        {
            var _AclPage = _context.AclPages.FirstOrDefault(p => p.Id == id);
            if (_AclPage == null)
            {
                return Ok("Not found");
            }
            _context.AclPages.Remove(_AclPage);
            var _acl_page = _context.SaveChanges();
            return Ok("Remove page");
        }

        [HttpDelete("pages/view/{id}", Name = "acl.page.view")]
        public IActionResult Show(ulong id)
        {
            var _AclPage = _context.AclPages.FirstOrDefault(p => p.Id == id);
            if (_AclPage == null)
            {
                return Ok("Not found");
            }
            return Ok(_AclPage);
        }
    }
}
