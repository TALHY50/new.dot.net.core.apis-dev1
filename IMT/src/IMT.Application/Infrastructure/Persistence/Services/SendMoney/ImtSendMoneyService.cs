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
using IMT.Thunes.Request.ConfirmTrasaction;
using IMT.Thunes.Exception;

namespace IMT.Application.Infrastructure.Persistence.Services.SendMoney
{
    public class ImtSendMoneyService : IImtSendMoneyService
    {

        private readonly IImtQuotationService _quotationService;
        private readonly IImtMoneyTransferService _moneyTransferService;
        private readonly IImtConfirmTransactionService _imtConfirmTransactionService;
        private readonly ConfirmTrasactionDTO _trasactionDTO;
        public ImtSendMoneyService(IImtQuotationService quotationService, IImtMoneyTransferService imtMoneyTransferService, IImtConfirmTransactionService imtConfirmTransactionService)
        {
            _quotationService = quotationService;
            _moneyTransferService = imtMoneyTransferService;
            _imtConfirmTransactionService = imtConfirmTransactionService;
        }

        public object SendMoney(SendMoneyRequest request)
        {
            try
            {
                CreateContentQuotationResponse? quoatation = _quotationService.CreateQuotationCombined(PrepareQuotation(request));
                CreateTransactionResponse? transactionResponse = _moneyTransferService.CreateTransactionByQuotationId(quoatation.id, PrepareTransaction(request));
                return _imtConfirmTransactionService.ConfirmTrasaction(PrepareConfirmTransaction(transactionResponse));
            }
            catch (ThunesException e)
            {
                throw new ThunesException(e.ErrorCode,e.Errors);
            }



        }

        public ConfirmTrasactionDTO PrepareConfirmTransaction(CreateTransactionResponse? transactionResponse)
        {
            return new ConfirmTrasactionDTO
            {
                TrasactionId = transactionResponse.id,
                Type = 2,
                ProviderId = 1 // for thunes hard coded
            };
        }

        public QuotationRequest PrepareQuotation(SendMoneyRequest request)
        {
            return new QuotationRequest
            {
                OrderId = request.InvoiceId,
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
        }

        public MoneyTransferDTO PrepareTransaction(SendMoneyRequest request)
        {
            return new MoneyTransferDTO
            {
                external_id = request.InvoiceId,
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
        }
    }
}