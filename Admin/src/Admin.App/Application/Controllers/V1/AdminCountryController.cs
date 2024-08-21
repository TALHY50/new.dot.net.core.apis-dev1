using ADMIN.App.Application.Ports.Services.Interfaces.Country;
using Microsoft.AspNetCore.Mvc;

namespace ADMIN.App.Application.Controllers.V1
{

    [Tags("Admin Country")]
    [ApiController]
    public class AdminCountryController (ICountryService countryService)
        : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(countryService.GetAll());
        }
    }
}
