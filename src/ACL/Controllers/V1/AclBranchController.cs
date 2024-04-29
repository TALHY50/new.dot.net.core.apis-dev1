using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    public class AclBranchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
