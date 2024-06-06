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

        [Tags("Thunes")]
        [HttpPost(ThunesUrl.CreateQuatationUrl)]
        public object CreateQuatatioin(CreateQuatationRequest request)
        {
            try
            {
                return _thunesClient.QuotationAdapter().CreateQuatatioin(request);
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

        [HttpGet(ThunesUrl.RetrieveAQuotationByIdUrl)]
        public object RetrieveAQuotationByIdUrl(int id)
        {
            try
            {
                return _thunesClient.QuotationAdapter().GetQuotationById(id);
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

        [HttpGet(ThunesUrl.RetrieveQuotationByExternalIdUrl)]
        public object GetByExternalId(ulong external_id)
        {
            try
            {
                return _thunesClient.QuotationAdapter().GetRetrieveQuotationByExternalId(external_id);
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


        [HttpPost(ThunesUrl.CreditPartyVerificationUrl)]
        public Object CreditPartyVerification(ulong id, string transaction_type, InformationRequest request)
        {
            try
            {
                return _thunesClient.VerificationAdapter().CreditPartyVerification(id, transaction_type, request);
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

        [HttpPost(ThunesUrl.BalancesUrl)]
        public Object GetAccountAdapter()
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetBalanceResponse();
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
