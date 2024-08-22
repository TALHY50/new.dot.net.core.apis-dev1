using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;

namespace ADMIN.App.Features
{
    public class MttsController : ApiControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
