﻿using Microsoft.AspNetCore.Mvc;
using Thunes;
using Thunes.Exception;
using Thunes.Request.Common;
using Thunes.Request.CreditParties;
using Thunes.Route;

namespace IMT.App.Application.Features
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Tags("Thunes")]
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {
        //  private readonly ThunesClient _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));
        private readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");

        [Tags("Thunes.CreditParties")]
        [HttpPost(ThunesUrl.CreditPartiesInformationUrl)]
        public object GetInformationAdapter(uint id, string transaction_type, InformationRequest request)
        {
            try
            {
                return _thunesClient.GetInformationAdapter().CreditPartyInformation(request, id, transaction_type);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.CreditParties")]
        [HttpPost(ThunesUrl.CreditPartyVerificationUrl)]
        public object CreditPartyVerification(uint id, string transaction_type, InformationRequest request)
        {
            try
            {
                return _thunesClient.VerificationAdapter().CreditPartyVerification(id, transaction_type, request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
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
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        #endregion

        #region Transaction

        //[Tags("Thunes.Transaction")]
        //[HttpPost(ThunesUrl.CreateTransactionUrl)]
        //public Object TransactionPost(uint id, MoneyTransferDTO request)
        //{
        //    try
        //    {
        //        var transactionType = _thunesClient.QuotationAdapter().GetQuotationById(id);
        //        if (request.IsValid(transactionType?.transaction_type?.ToLower()))
        //        {
        //            return _thunesClient.GetTransactionAdapter().CreateTransaction(id, request);
        //        }
        //        return BadRequest("Request not valid");
        //    }
        //    catch (ThunesException e)
        //    {
        //        return StatusCode(e.ErrorCode, e.Errors);
        //    }
        //}
        //[Tags("Thunes.Transaction")]
        //[HttpPost(ThunesUrl.CreateTransactionFromQuotationExternalIdUrl)]
        //public Object CreateTransactionFromQuotationExternalIdPost(int external_id, MoneyTransferDTO request)
        //{
        //    try
        //    {
        //        if (request.IsValid(null))
        //        {
        //            return _thunesClient.GetTransactionAdapter().CreateTransactionFromQuotationExternalId(external_id, request);
        //        }
        //        return BadRequest("Request not valid");
        //    }
        //    catch (ThunesException e)
        //    {
        //        return StatusCode(e.ErrorCode, e.Errors);
        //    }
        //}

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateAttachmentToTransactionByIdUrl)]
        public object AddAttachment(int id, [FromForm] AttachmentRequest attachmentRequest)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().CreateAttachmentToTransactionById(id, attachmentRequest);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateAttachmentToTransactionByExternalIdUrl)]
        public object AddAttachmentToTransactionByExternalId(string invoice_id, [FromForm] AttachmentRequest attachmentRequest)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().CreateAttachmentToTransactionByExternalId(invoice_id, attachmentRequest);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
        /*
        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.ConfirmTransactionByIdUrl)]
        public object ConfirmTransactionById(int id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ConfirmTransactionById(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.ConfirmTransactionByExternalIdUrl)]
        public object ConfirmTransactionByExternalId(int external_id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ConfirmTransactionByExternalId(external_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
        */
        [Tags("Thunes.Transaction")]
        [HttpGet(ThunesUrl.RetrieveTransactionInformationByTransactionIdUrl)]
        public object RetrieveTransactionInformationByTransactionId(int id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().RetrieveTransactionInformationByTransactionId(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpGet(ThunesUrl.RetrieveTransactionInformationByExternalIdUrl)]
        public object RetrieveTransactionInformationByExternalId(string invoice_id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().RetrieveTransactionInformationByExternalId(invoice_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpGet(ThunesUrl.ListAttachmentsOfATransactionByIdUrl)]
        public object ListAttachmentsOfATransactionById(int id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ListAttachmentsOfATransactionById(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpGet(ThunesUrl.ListAttachmentsOfTransactionByExternalIdUrl)]
        public object ListAttachmentsOfTransactionByExternalId(string invoice_id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ListAttachmentsOfTransactionByExternalId(invoice_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CancelTransactionByExternalIdUrl)]
        public object CancelTransactionByExternalId(string external_id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().CancelTransactionByExternalId(external_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CancelTransactionByIdUrl)]
        public object CancelTransactionById(int id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().CancelTransactionById(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
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
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.BalanceMovementUrl)]
        public Object GetBalanceMovement(uint id, DateTime from_date, DateTime to_date)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetBalanceMovement(id, from_date, to_date);
            }
            catch (ThunesException e)
            {
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
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.GetReportDetailUrl)]
        public Object GetReportDetail(uint id)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetReportDetail(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.ListReportFilesAvailableUrl)]
        public Object GetListReportsAvailable(uint id)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().ListReportsAvailable(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Account")]
        [HttpGet(ThunesUrl.ReportFileDetailUrl)]
        public Object GetListReportsAvailable(uint report_id, uint id)
        {
            try
            {
                return _thunesClient.GetAccountAdapter().GetReportFileDetails(report_id, id);
            }
            catch (ThunesException e)
            {
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
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
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
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.GetPayerDetailUrl)]
        public Object PayerResponseDetails(uint id)
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().PayerResponseDetails(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Discovery")]
        [HttpGet(ThunesUrl.RetrieveRatesForAGivenPayerUrl)]
        public Object PayerRateResponse(uint id)
        {
            try
            {
                return _thunesClient.GetDiscoveryAdapter().PayerRateResponse(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
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
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
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
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
    }
}
