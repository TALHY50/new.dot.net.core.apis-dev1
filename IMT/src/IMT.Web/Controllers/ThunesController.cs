using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {
        [HttpGet(Name = "GetThunes")]
        public IEnumerable<WeatherForecast> Get()
        {
            return null;
        }
    }
}
