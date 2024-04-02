using ACL.Database;
using ACL.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet(Name = "acl.company.list")]
        [Route("pages")]
        public async Task<IActionResult> Index()
        {
            var AclPage = await _context.AclPages.ToListAsync();
            return Ok(AclPage);
        }

        [HttpGet(Name = "acl.page.add")]
        [Route("pages/add")]
        public IActionResult Create(AclPage AclPage)
        {
            _context.AclPages.Add(AclPage);
            _context.SaveChanges();
            return Ok(AclPage);
        }

        [HttpGet(Name = "acl.page.edit")]
        [Route("pages/edit/{id}")]
        public IActionResult Edit(AclPage AclPage)
        {
            var _AclPage = _context.AclPages.FirstOrDefault(p => p.Id == AclPage.Id);
            if (_AclPage == null)
            {
                return Ok("Not found");
            }
            _AclPage = AclPage;
            _context.AclPages.Update(AclPage);
            var _acl_page = _context.SaveChanges();
            return Ok(_AclPage);
        }

        [HttpGet(Name = "acl.page.destroy")]
        [Route("pages/delete/{id}")]
        public IActionResult Destroy(AclPage AclPage)
        {
            var _AclPage = _context.AclPages.FirstOrDefault(p => p.Id == AclPage.Id);
            if (_AclPage == null)
            {
                return Ok("Not found");
            }
            _context.AclPages.Remove(AclPage);
            var _acl_page = _context.SaveChanges();
            return Ok("Remove page");
        }       
        
        //[HttpGet(Name = "acl.page.view")]
        //[Route("pages/view/{id}")]
        //public IActionResult Show(AclPage AclPage)
        //{
        //    var _AclPage = _context.AclPages.FirstOrDefault(p => p.Id == AclPage.Id);
        //    if (_AclPage == null)
        //    {
        //        return Ok("Not found");
        //    }
        //    return Ok(_AclPage);
        //}

    }


}
