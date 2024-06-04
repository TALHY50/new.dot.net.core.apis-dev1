using IMT.PayAll;
using IMT.Thunes;
using IMT.Thunes.Request;
using IMT.Thunes.Response;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

       // private readonly ThunesClient _thunesClient = new ThunesClient("api-key", "secret-key", "https://api.limonetikqualif.com");
        private readonly ThunesClient _thunesClient = new ThunesClient("api-key", "secret-key", "http://localhost:3000"); // with mock url


        [HttpPost(ThunesUrl.CreateQuatationUrl)]
        public Object QuotationPost()
        {
            CreateQuatationRequest? request = new CreateQuatationRequest();
            var response = _thunesClient.CreateQuotation(request);
            return response;
        }

        [Tags("Transaction From Quotation Id")]
        [HttpPost(ThunesUrl.CreateTransactionUrl)]
        public Object TransactionPost(CreateNewTransactionRequest request)
        {
            var response = _thunesClient.CreateTransaction(request);
            return response;
        }
    }
}
