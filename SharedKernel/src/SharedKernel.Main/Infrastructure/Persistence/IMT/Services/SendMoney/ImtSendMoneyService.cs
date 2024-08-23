using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Services;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Contracts.Requests;
using Thunes.Exception;
using Thunes.Request.ConfirmTrasaction;
using Thunes.Request.Transaction.Transfer.CommonTransaction;
using Thunes.Response.Transfer.Quotation;
using Thunes.Response.Transfer.Transaction;

namespace IMT.App.Infrastructure.Persistence.Services.SendMoney
{
    public class ImtSendMoneyService : IImtSendMoneyService
    {

        private readonly IImtQuotationService _quotationService;
        private readonly IImtMoneyTransferService _moneyTransferService;
        private readonly IImtConfirmTransactionService _imtConfirmTransactionService;
        private readonly IImtCountryRepository _countryRepository;
        private readonly IImtCurrencyRepository _currencyRepository;
        public ImtSendMoneyService(IImtQuotationService quotationService, IImtMoneyTransferService imtMoneyTransferService, IImtConfirmTransactionService imtConfirmTransactionService,IImtCurrencyRepository currencyRepository,IImtCountryRepository countryRepository)
        {
            _quotationService = quotationService;
            _moneyTransferService = imtMoneyTransferService;
            _imtConfirmTransactionService = imtConfirmTransactionService;
            _currencyRepository = currencyRepository;
            _countryRepository = countryRepository;
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
                InvoiceId = transactionResponse.external_id,
                RemoteTrasactionId = transactionResponse.id,
                Type = 2,
                ProviderId = 1 // for thunes hard coded
            };
        }

        public QuotationRequest PrepareQuotation(SendMoneyRequest request)
        {
            return new QuotationRequest
            {
                external_id = request.quotation.invoice_id,
                customer_id = request.quotation.customer_id,
                payer_id = request.quotation.payer_id,
                mode = request.quotation.mode,
                transaction_type = request.quotation.transaction_type,
                source_amount = request.quotation.source_amount,
                source_currency_code = request.quotation.source_currency_code,
                source_country_iso_code = request.quotation.source_country_iso_code,
                destination_amount = request.quotation.destination_amount,
                destination_currency_code = request.quotation.destination_currency_code

            };
        }

        public MoneyTransferDTO PrepareTransaction(SendMoneyRequest request)
        {
            return new MoneyTransferDTO
            {
                invoice_id = request.quotation.invoice_id,
                credit_party_identifier = request.money_transfer.credit_party_identifier,
                beneficiary = request.money_transfer.beneficiary,
                sending_business = request.money_transfer.sending_business,
                sender = request.money_transfer.sender,
                receiving_business = request.money_transfer.receiving_business,
                document_reference_number = request.money_transfer.document_reference_number,
                purpose_of_remittance = request.money_transfer.purpose_of_remittance,
                callback_url = request.money_transfer.callback_url,
                retail_fee_currency = request.money_transfer.retail_fee_currency,
                retail_fee = request.money_transfer.retail_fee,
            };
        }
    }
}