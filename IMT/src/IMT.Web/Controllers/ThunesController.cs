using DotNetEnv;
using IMT.Thunes;
using IMT.Thunes.Exception;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Request.Transaction.Quoatation;
using IMT.Thunes.Request.Transaction.Transfer;
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
        private readonly ThunesClient _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));

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

        [Tags("Thunes.CreditParties")]
        [HttpPost(ThunesUrl.CreditPartyVerificationUrl)]
        public object CreditPartyVerification(ulong id, string transaction_type, InformationRequest request)
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


        #region Connectivity

        [Tags("Thunes.Connectivity")]
        [HttpGet(ThunesUrl.ConnectivityUrl)]
        public object Connectivity()
        {
            try
            {
                return _thunesClient.GetConnectivityAdapter().Ping();
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

        #endregion

        #region Transaction

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateTransactionUrl)]
        public Object TransactionPost(int id, CreateNewTransactionRequest request)
        {
            try
            {
                if (id == 1) request = null;
                var response = _thunesClient.GetTransactionAdapter().CreateTransaction(id, request);
                return response;
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
                //return BadRequest(e.Errors);
                //if (e.Message == "Unauthorized")
                //{
                //    return Unauthorized();
                //}
                //else
                //{
                //    return NotFound();
                //}
            }
        }
        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateTransactionFromQuotationExternalIdUrl)]
        public Object CreateTransactionFromQuotationExternalIdPost(int external_id, CreateNewTransactionRequest request)
        {
            try
            {
                if (external_id == 1) request = null;
                var response = _thunesClient.GetTransactionAdapter().CreateTransactionFromQuotationExternalId(external_id, request);
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
                var response = _thunesClient.GetTransactionAdapter().CreateAttachmentToTransactionById(id, attachmentRequest);
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
        [HttpPost(ThunesUrl.CreateAttachmentToTransactionByExternalIdUrl)]
        public object AddAttachmentToTransactionByExternalId(int external_id, [FromForm] AttachmentRequest attachmentRequest)
        {
            try
            {
                if (external_id == 1) attachmentRequest = null;
                var response = _thunesClient.GetTransactionAdapter().CreateAttachmentToTransactionByExternalId(external_id, attachmentRequest);
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
        [HttpPost(ThunesUrl.ConfirmTransactionByIdUrl)]
        public object ConfirmTransactionById(int id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().ConfirmTransactionById(id);
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
        [HttpPost(ThunesUrl.ConfirmTransactionByExternalIdUrl)]
        public object ConfirmTransactionByExternalId(int external_id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().ConfirmTransactionByExternalId(external_id);
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
        [HttpGet(ThunesUrl.RetrieveTransactionInformationByTransactionIdUrl)]
        public object RetrieveTransactionInformationByTransactionId(int id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().RetrieveTransactionInformationByTransactionId(id);
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
        [HttpGet(ThunesUrl.RetrieveTransactionInformationByExternalIdUrl)]
        public object RetrieveTransactionInformationByExternalId(int external_id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().RetrieveTransactionInformationByExternalId(external_id);
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
        [HttpGet(ThunesUrl.ListAttachmentsOfATransactionByIdUrl)]
        public object ListAttachmentsOfATransactionById(int id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().ListAttachmentsOfATransactionById(id);
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
        [HttpGet(ThunesUrl.ListAttachmentsOfTransactionByExternalIdUrl)]
        public object ListAttachmentsOfTransactionByExternalId(int external_id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().ListAttachmentsOfTransactionByExternalId(external_id);
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
        [HttpGet(ThunesUrl.CancelTransactionByExternalIdUrl)]
        public object CancelTransactionByExternalId(int external_id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().CancelTransactionByExternalId(external_id);
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
        [HttpPost(ThunesUrl.CancelTransactionByIdUrl)]
        public object CancelTransactionById(int id)
        {
            try
            {
                var response = _thunesClient.GetTransactionAdapter().CancelTransactionById(id);
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

        #endregion

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.BalancesUrl)]
        public Object GetAccountAdapter()
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetBalanceResponse();
            }
            catch (ThunesException e)
            {
                if (e.ErrorCode == Unauthorized().StatusCode)
                {
                    return StatusCode(e.ErrorCode, e.ErrorDescription);
                }
                return StatusCode(e.ErrorCode, e.Errors);
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
            catch (ThunesException e)
            {
                if (e.ErrorCode == Unauthorized().StatusCode)
                {
                    return StatusCode(e.ErrorCode, e.ErrorDescription);
                }
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.ListReportsAvailableUrl)]
        public Object ListReportsAvailable(string? queryParams = null)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().ListReportsAvailable(queryParams);
            }
            catch (ThunesException e)
            {
                if(e.ErrorCode == Unauthorized().StatusCode)
                {
                    return StatusCode(e.ErrorCode, e.ErrorDescription);
                }
                return StatusCode(e.ErrorCode, e.Errors);
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
            catch (ThunesException e)
            {
                if (e.ErrorCode == Unauthorized().StatusCode)
                {
                    return StatusCode(e.ErrorCode, e.ErrorDescription);
                }
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.ListReportFilesAvailableUrl)]
        public Object GetListReportsAvailable(ulong id)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().ListReportsAvailable(id);
            }
            catch (ThunesException e)
            {
                if (e.ErrorCode == Unauthorized().StatusCode)
                {
                    return StatusCode(e.ErrorCode, e.ErrorDescription);
                }
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.ReportFileDetailUrl)]
        public Object GetListReportsAvailable(ulong report_id, ulong id)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetReportFileDetails(report_id, id);
            }
            catch (ThunesException e)
            {
                if (e.ErrorCode == Unauthorized().StatusCode)
                {
                    return StatusCode(e.ErrorCode, e.ErrorDescription);
                }
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.ListServicesAvailableUrl)]
        public Object ServiceResponse()
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().ServiceResponse();
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

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.ListPayersAvailableUrl)]
        public Object PayerResponse()
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().PayerResponse();
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

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.GetPayerDetailUrl)]
        public Object PayerResponseDetails(ulong id)
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().PayerResponseDetails(id);
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

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.RetrieveRatesForAGivenPayerUrl)]
        public Object PayerRateResponse(ulong id)
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().PayerRateResponse(id);
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

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.ListCountriesAvailableUrl)]
        public Object CountryResponse()
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().CountryResponse();
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

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.BicCodeLookupUrl)]
        public Object LookupResponse(string swift_bic_code)
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().LookupResponse(swift_bic_code);
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
