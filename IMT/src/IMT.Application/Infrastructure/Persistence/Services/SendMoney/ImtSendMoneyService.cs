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
using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
using Microsoft.EntityFrameworkCore;
using IMT.Application.Infrastructure.Utility;

namespace IMT.Application.Infrastructure.Persistence.Services.SendMoney
{
    public class ImtSendMoneyService : IImtSendMoneyService
    {

        private readonly IImtQuotationService _quotationService;
        private readonly IImtMoneyTransferService _moneyTransferService;
        private readonly IImtConfirmTransactionService _imtConfirmTransactionService;
        private readonly IImtCountryRepository _countryRepository;
        private readonly IImtCurrencyRepository _currencyRepository;
        public ImtSendMoneyService(IImtQuotationService quotationService, IImtMoneyTransferService imtMoneyTransferService, IImtConfirmTransactionService imtConfirmTransactionService)
        {
            _quotationService = quotationService;
            _moneyTransferService = imtMoneyTransferService;
            _imtConfirmTransactionService = imtConfirmTransactionService;
          _currencyRepository = DependencyContainer.GetService<IImtCurrencyRepository>();
            _countryRepository = DependencyContainer.GetService<IImtCountryRepository>();
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
                throw new ThunesException(e.ErrorCode, e.Errors);
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
                invoice_id = request.invoice_id,
                payer_id = request.payer_id,
                mode = request.mode,
                transaction_type = request.transaction_type,
                source_amount = request.source_amount,
                source_currency_code =  request.source_currency_code,
                source_country_iso_code = request.source_currency_code,
                destination_amount = request.destination_amount,
                destination_currency_code = request.destination_currency_code

            };
        }

        public MoneyTransferDTO PrepareTransaction(SendMoneyRequest request)
        {
            return new MoneyTransferDTO
            {
                external_id = request.invoice_id,
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