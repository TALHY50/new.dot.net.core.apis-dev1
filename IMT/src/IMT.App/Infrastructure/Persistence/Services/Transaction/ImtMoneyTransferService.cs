using IMT.App.Application.Ports.Services;
using IMT.App.Infrastructure.Persistence.Repositories.ImtMoneyTransfer;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using Thunes;
using Thunes.Exception;
using Thunes.Request.Transaction.Transfer.CommonTransaction;
using Thunes.Response.Common;
using Thunes.Response.Transfer.Quotation;
using Thunes.Response.Transfer.Transaction;

#pragma warning disable CS8629 // Nullable value type may be null.
namespace IMT.App.Infrastructure.Persistence.Services.Transaction
{
    public class ImtMoneyTransferService : ImtMoneyTransferRepository, IImtMoneyTransferService
    {
        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");
        public IImtProviderErrorDetailsRepository _errorRepository;
        public IImtQuotationRepository _quotationRepository;
        public IImtTransactionRepository _transactionRepository;
        public IImtMoneyTransferRepository _moneyTransferRepository;
        public IImtCountryRepository _countryRepository;
        public IImtCurrencyRepository _currencyRepository;
        public SharedKernel.Main.Domain.IMT.Entities.Quotation? _imtQuotation;
        public ImtMoneyTransferService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _quotationRepository = DependencyContainer.GetService<IImtQuotationRepository>();
            _errorRepository = DependencyContainer.GetService<IImtProviderErrorDetailsRepository>();
            _currencyRepository = DependencyContainer.GetService<IImtCurrencyRepository>();
            _countryRepository = DependencyContainer.GetService<IImtCountryRepository>();
            _moneyTransferRepository = DependencyContainer.GetService<IImtMoneyTransferRepository>();
            _transactionRepository = DependencyContainer.GetService<IImtTransactionRepository>();
        }
        public SharedKernel.Main.Domain.IMT.Entities.Transaction PrepareImtTransaction(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction)
        {
            return new SharedKernel.Main.Domain.IMT.Entities.Transaction
            {
                PaymentId = transaction?.id.ToString(),
                TransactionStateId = (transaction?.id != null) ? 2 : 1,
                CustomerId = 1, // hard coded dont know from where it will come
                TransactionType = 1, // hard coded value cause we dont know from where we will get it
                MoneyFlow = 2,
                Amount = (decimal?)(transaction?.sent_amount?.amount), // dont know which amount it will be
                TransactionId = transaction?.id,
                Fee = (decimal?)(quotation?.fee?.amount),
                Gross = (decimal?)(quotation?.fee?.amount), // dont know what is this and from where it will come
                CurrencyId = _currencyRepository.GetCurrencyIdByCode(quotation?.source?.country_iso_code), //Dont know which currency id will hold here sender or destination
                CurrentBalance = 1000, //hard coded need to call the api and hold the data here
                PreviousBalance = 1000, //hard coded need to call the api and hold the data here
                Status = 1, // hard coded need to know from where And when depends what to update and what value to put from where
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
        public MoneyTransfer PrepareImtMoneyTransfer(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction)
        {
            return new MoneyTransfer
            {
                PaymentId = transaction?.id.ToString(),
                TransactionStateId = (transaction?.id != null) ? 2 : 1,
                ReasonId = 1, // hard coded value cause we dont know from where we will get it
                PaymentMethodId = 1, // hard coded value cause we dont know from where we will get it
                TransferType = 1, // hard coded value cause we dont know from where we will get it
                ReasonCode = transaction?.purpose_of_remittance,
                Type = (sbyte?)((quotation?.transaction_type == null) ? 5 : (quotation?.transaction_type == "B2B") ? 1 : (quotation?.transaction_type == "B2C") ? 2 : (quotation?.transaction_type == "C2C") ? 3 : (quotation?.transaction_type == "C2B") ? 4 : 0),

                SenderName = transaction?.sender?.lastname + " " + transaction?.sender?.firstname,
                ReceiverName = transaction?.receiving_business?.representative_lastname + " " + transaction?.receiving_business?.representative_firstname,
                SenderCurrencyId = _currencyRepository.GetCurrencyIdByCode(quotation?.source?.country_iso_code),
                ReceiverCurrencyId = _currencyRepository.GetCurrencyIdByCode(quotation?.destination?.currency),
                ExchangeRate = (decimal?)(quotation?.wholesale_fx_rate),
                SendAmount = (decimal?)(quotation?.sent_amount?.amount),
                ReceiveAmount = (decimal?)(quotation?.destination?.amount),
                ExchangedAmount = (decimal?)(quotation?.destination?.amount), // hardcoded dont know what is it so putting a random
                Fee = (decimal?)(quotation?.fee?.amount),
                Vat = (decimal?)(quotation?.destination?.amount), // hardcoded dont know what is it so putting a random
                CommissionPaidBy = (sbyte?)1, // hard coded dont know where it will come from
                SenderCustomerId = 1, // hard coded dont know where it will come from
                ReceiverCustomerId = 1, // hard coded dont know where it will come from
                Source = (sbyte?)0, // hard coded dont know where it will come from
                OrderId = quotation?.invoice_id, // hard coded dont know where it will come from
                RemoteOrderId = quotation?.invoice_id, // hard coded dont know where it will come from
                InvoiceId = quotation?.invoice_id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
        public CreateTransactionResponse CreateTransactionByQuotationId(ulong quotationId, MoneyTransferDTO request)
        {
            var quotation = _thunesClient.QuotationAdapter().GetQuotationById(quotationId);
            _imtQuotation = _quotationRepository.GetImtQuotationByInvoiceId(quotation.invoice_id);
            if (request.IsValid(quotation?.transaction_type?.ToLower()))
            {
                try
                {
                    var transaction = (CreateTransactionResponse)_thunesClient.GetTransactionAdapter().CreateTransaction(quotationId, request);
                    _moneyTransferRepository.Add(PrepareImtMoneyTransfer(request, quotation, transaction));
                    _transactionRepository.Add(PrepareImtTransaction(request, quotation, transaction));
                    return transaction;
                }
                catch (ThunesException e)
                {
                    ErrorStore(e.Errors);
                    throw e;
                }
            }
            throw new ThunesException(422, "Not a valid request");
        }

        public CreateTransactionResponse CreateTransactionByExternalId(string invoice_id, MoneyTransferDTO request)
        {
            if (request.IsValid(null))
            {
                try
                {
                    return (CreateTransactionResponse)_thunesClient.GetTransactionAdapter().CreateTransactionFromQuotationExternalId(invoice_id, request);
                }
                catch (ThunesException e)
                {
                    ErrorStore(e.Errors);
                    throw e;
                }
            }
            throw new ThunesException(422, "Not a valid request");
        }

        private void ErrorStore(List<ErrorsResponse> Errors)
        {
            foreach (var error in Errors)
            {

                ProviderErrorDetail prepareData = new ProviderErrorDetail
                {
                    ErrorCode = error.code,
                    ErrorMessage = error.message,
                    ImtProviderId = (int)_imtQuotation.ImtProviderId,
                    ReferenceId = _imtQuotation.Id,
                    Type = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _errorRepository.Add(prepareData);
            }
        }
    }
}
