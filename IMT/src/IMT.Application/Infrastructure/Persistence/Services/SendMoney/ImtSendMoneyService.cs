using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Application.Contracts.Requests.SendMoiney;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Application.Domain.Ports.Services.SendMoney;
using IMT.Application.Domain.Ports.Services.Transaction;
using IMT.Application.Infrastructure.Persistence.Services.ConfirmTransactionService;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Thunes.Response.Transfer.Quotation;
using IMT.Thunes.Response.Transfer.Transaction;
using IMT.Application.Contracts.Requests.Quotation;
using Microsoft.AspNetCore.Http.HttpResults;
using IMT.Application.Domain.Ports.Services.ConfirmTransaction;

namespace IMT.Application.Infrastructure.Persistence.Services.SendMoney
{
    public class ImtSendMoneyService : IImtSendMoneyService
    {

        private readonly IImtQuotationService _quotationService;
        private readonly IImtMoneyTransferService _moneyTransferService;
        private readonly ImtConfirmTransactionService _imtConfirmTransactionService;
        public ImtSendMoneyService(IImtQuotationService quotationService, IImtMoneyTransferService imtMoneyTransferService, ImtConfirmTransactionService imtConfirmTransactionService)
        {
            _quotationService = quotationService;
            _moneyTransferService = imtMoneyTransferService;
            _imtConfirmTransactionService = confirmTransactionService;
        }

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

           return _imtConfirmTransactionService.ConfirmTrasaction(transactionResponse.id);

        }
    }
}