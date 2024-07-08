
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
using IMT.Thunes.Response.Transfer.Quotation;
using IMT.Thunes.Response.Transfer.Transaction;
using IMT.Web.Controllers.Transaction;
using IMT.Application.Infrastructure.Persistence.Services.ConfirmTransactionService;

namespace IMT.Web.Controllers.SendMoney
{

    [ApiController]
    [Tags("Quotation")]
    [Route("[controller]")]
    public class SendMoneyController : BaseController
    {

        private readonly IImtQuotationService _quotationService;
        private readonly IImtMoneyTransferService _moneyTransferService;
        private readonly ImtConfirmTransactionService _imtConfirmTransactionService;
        public SendMoneyController(IImtQuotationService quotationService, IImtMoneyTransferService imtMoneyTransferService, ImtConfirmTransactionService imtConfirmTransactionService)
        {
            _quotationService = quotationService;
            _moneyTransferService = imtMoneyTransferService;
            _imtConfirmTransactionService = imtConfirmTransactionService;
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

            CreateContentQuotationResponse? quoatation = _quotationService.CreateQuotationCombined(QuotationRequest);

            if (quoatation == null)
            {
                return null;
            }

            MoneyTransferDTO money_transfer_dto = new MoneyTransferDTO
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
            CreateTransactionResponse? transactionResponse = _moneyTransferService.CreateTransactionByQuotationId(quoatation.id, money_transfer_dto);
            if (transactionResponse == null)
            {
                return null;
            }

            _imtConfirmTransactionService.ConfirmTrasaction(transactionResponse.id);

            return null;
        }

    }
}