using DotNetEnv;
using IMT.PayAll;
using IMT.Thunes;
using IMT.Thunes.Exception;
using IMT.Thunes.Request;
using IMT.Thunes.Response;
using IMT.Thunes.Response.CreditParties;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

        private readonly ThunesClient _thunesClient = new ThunesClient(Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_BASE_URL"));
        [HttpGet("CreateQuatatioin")]
        public CreateQuatationResponse Get()
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

            int id = 1;
            return _thunesClient.QuotationAdapter().GetQuotationById(id);
        }

        [HttpGet("GetRetrieveQuotationByExternalId")]
        public CreateQuatationResponse GetByExternalId()
        {
            ulong id = 1481184321405;
            return _thunesClient.QuotationAdapter().GetRetrieveQuotationByExternalId(id);
        }


        [HttpPost(ThunesUrl.CreditPartiesInformationUrl)]
        public object GetInformationAdapter(ulong id, string transaction_type, InformationRequest request)
        {
            try
            {
                return _thunesClient.GetInformationAdapter().CreditPartyInformation(request, id, transaction_type);
            }
            catch (System.Exception e)
            {
                if (e.Message == "Unauthorized")
                {
                    return Unauthorized();
                }
                else
                {
                    return NotFound();
                }
            }

        }
    }
}
