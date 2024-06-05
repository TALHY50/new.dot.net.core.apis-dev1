using DotNetEnv;
using IMT.Thunes;
using IMT.Thunes.Request;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Response;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

        private readonly ThunesClient _thunesClient = new ThunesClient(Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_BASE_URL"));
        [HttpGet("CreateQuatatioin")]
        public object Get()
        {
            CreateQuatationRequest? request = new CreateQuatationRequest();
            return _thunesClient.QuotationAdapter().CreateQuatatioin(request);
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

        [Tags("Transaction From Quotation Id")]
        [HttpPost(ThunesUrl.CreateTransactionUrl)]
        public Object TransactionPost(int id, CreateNewTransactionRequest request)
        {
            try
            {
                if (id == 1) request = null;
                var response = _thunesClient.CreateTransaction(id, request);
                return response;
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
        
        [Tags("Transaction From Quotation External Id")]
        [HttpPost(ThunesUrl.CreateTransactionFromQuotationExternalIdUrl)]
        public Object CreateTransactionFromQuotationExternalIdPost(int external_id, CreateNewTransactionRequest request)
        {
            try
            {
                if (external_id == 1) request = null;
                var response = _thunesClient.CreateTransactionFromQuotationExternalId(external_id, request);
                return response;
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
