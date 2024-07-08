
using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Contracts.Requests.SendMoiney;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.PayAll.Response.Common;
using IMT.Thunes.Response.Discovery.Common;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.IMT;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Application.Domain.Ports.Services.Transaction;

namespace IMT.Web.Controllers.SendMoney
{

    [ApiController]
    [Tags("Quotation")]
    [Route("[controller]")]
    public class SendMoneyController : BaseController
    {

        private readonly IImtQuotationService _quotationService;
        private readonly IImtMoneyTransferService _moneyTransferService;
        public SendMoneyController(IImtQuotationService quotationService, IImtMoneyTransferService imtMoneyTransferService)
        {
            _quotationService = quotationService;
            _moneyTransferService = imtMoneyTransferService;
        }

        [Tags("Thunes.SendMoney")]
        [HttpPost(ThunesUrl.SendMoney)]
        public object SendMoney(SendMoneyRequest request)
        {

            // prepare create quotation
            QuotationRequest QuotationRequest = new QuotationRequest
            {
                OrderId = request.OrderId,
                PayerId = request.PayerId,
                Mode = request.Mode,
                TransactionType = request.TransactionType,
                SourceAmount = request.SourceAmount,
                ImtSourceCurrencyId = request.ImtSourceCurrencyId,
                ImtProviderId = request.ImtProviderId,
                ImtProviderServiceId = request.ImtProviderServiceId,
                ImtSourceCountryId = request.ImtSourceCountryId,
                DestinationAmount = request.DestinationAmount,
                ImtDestinationCurrencyId = request.ImtDestinationCurrencyId
            };

            var quoatation = _quotationService.CreateQuotationCombined(QuotationRequest);

            MoneyTransferDTO MoneyTransferDTO = new MoneyTransferDTO
            {
                external_id = request.OrderId,
                credit_party_identifier = request.credit_party_identifier,
                beneficiary = request.beneficiary,
                sending_business = request.sending_business,
                sender = request.sender,
                receiving_business = request.receiving_business,
                document_reference_number = request.document_reference_number,
                purpose_of_remittance = request.purpose_of_remittance,
                callback_url = request.callback_url,
                retail_fee_currency = request.retail_fee_currency,
                retail_fee = request.retail_fee,
            };
            // _moneyTransferService.CreateTransactionByQuotationId(quoatation.id, )



            return null;
        }

    }
}