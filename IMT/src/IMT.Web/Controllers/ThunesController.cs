using IMT.Thunes;
using IMT.Thunes.Request;
using IMT.Thunes.Response;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

        private readonly ThunesClient _thunesClient =
            new ThunesClient("api-key", "secret-key", "https://sandbox-api.craftgate.io");


        [HttpGet(Name = "GetThunes")]
        public BaseCreateQuatationResponse Get()
        {
            CreateQuatationRequest? request = new CreateQuatationRequest();
            return _thunesClient.CreateQuotation(request);

        }
    }
}
