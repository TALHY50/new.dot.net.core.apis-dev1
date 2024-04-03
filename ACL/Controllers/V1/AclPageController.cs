using ACL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Interfaces.Repositories.V1;

namespace ACL.Controllers.V1
{

    [ApiController]
    [Route("api/v1/")]
    public class AclPageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IAclPageRepository _pageRepository;

        public AclPageController(ApplicationDbContext context, IAclPageRepository AclPageRepository)
        {
            _context = context;
            _pageRepository = AclPageRepository;
        }

        [HttpGet("pages", Name = "acl.company.list")]
        public async Task<IActionResult> Index()
        {
            return Ok(_pageRepository.GetAll());
        }

        [HttpPost("pages/add", Name = "acl.page.add")]
        public IActionResult Create(AclPageRequest request)
        {

            //_pageRepository.Add(request);
            //_context.SaveChanges();
            //return Ok(AclPage);
            return Ok('bad');
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
