using IMT.PayAll;
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
            new ThunesClient("api-key", "secret-key", "https://api.limonetikqualif.com");


        [HttpGet(Name = "GetThunes")]
        public CreateQuatationResponse Get()
        {
            CreateQuatationRequest? request = new CreateQuatationRequest();
            return _thunesClient.CreateQuotation().CreateQuatatioin(request);
        }
    }
}
