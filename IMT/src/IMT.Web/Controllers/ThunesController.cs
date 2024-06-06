using DotNetEnv;
using IMT.Thunes;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Request.Transaction;
using IMT.Thunes.Response;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    [Tags("Thunes")]
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

        private readonly ThunesClient _thunesClient = new ThunesClient(Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_BASE_URL"));

        [Tags("Thunes.Quatation")]
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

        [Tags("Thunes.Quatation")]
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
        [Tags("Thunes.Quatation")]
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
        [Tags("Thunes.CreditParties")]
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

        #region Transaction

        [Tags("Thunes.Transaction")]
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
        [Tags("Thunes.Transaction")]
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

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateAttachmentToTransactionByIdUrl)]
        public object AddAttachment(int id, [FromForm] AttachmentRequest attachmentRequest)
        {
            try
            {
                if (id == 1) attachmentRequest = null;
                var response = _thunesClient.CreateAttachmentToTransactionById(id, attachmentRequest);
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

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.BalancesUrl)]
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

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.BalanceMovementUrl)]
        public Object GetBalanceMovement(ulong id, DateTime from_date, DateTime to_date)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetBalanceMovement(id, from_date, to_date);
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

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.ListReportsAvailableUrl)]
        public Object ListReportsAvailable(string queryParams = null)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().ListReportsAvailable(queryParams);
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

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.GetReportDetailUrl)]
        public Object GetReportDetail(ulong id)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetReportDetail(id);
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

    #endregion

}
