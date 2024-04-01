using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ACL.Controllers
{
    public class AclModuleController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        } 
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }  
        public IActionResult View(int Id)
        {
            return View();
        }  
        public IActionResult Destroy(int Id)
        {
            return View();
        }


    }
}
