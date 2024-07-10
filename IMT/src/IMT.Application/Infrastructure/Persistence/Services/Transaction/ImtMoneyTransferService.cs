using IMT.Application.Contracts.Requests.Transfer;
using IMT.Application.Domain.Ports.Repositories.ConfirmTransaction;
using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
using IMT.Application.Domain.Ports.Repositories.Quotation;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Application.Domain.Ports.Services.Transaction;
using IMT.Application.Infrastructure.Persistence.Repositories.ImtMoneyTransfer;
using IMT.Application.Infrastructure.Utility;
using IMT.Thunes;
using IMT.Thunes.Exception;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Thunes.Response.Common;
using IMT.Thunes.Response.Transfer.Transaction;
using Mysqlx.Crud;
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8629 // Nullable value type may be null.
namespace IMT.Application.Infrastructure.Persistence.Services.Transaction
{
    public class ImtMoneyTransferService : ImtMoneyTransferRepository, IImtMoneyTransferService
    {
        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");
        public IImtProviderErrorDetailsRepository _errorRepository;
        public IImtQuotationRepository _quotationRepository;
        public ImtQuotation? _imtQuotation;
        public ImtMoneyTransferService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _quotationRepository = DependencyContainer.GetService<IImtQuotationRepository>();
            _errorRepository = DependencyContainer.GetService<IImtProviderErrorDetailsRepository>();
        }
        public ImtMoneyTransfer PrepareImtTransaction(MoneyTransferDTO request)
        {
            return new ImtMoneyTransfer
            {
                //PaymentId = request.PaymentId,
                //TransactionStateId = request.TransactionStateId,
                //ReasonId = request.ReasonId,
                //PaymentMethodId = request.PaymentMethodId,
                //TransferType = request.TransferType,
                //ReasonCode = request.ReasonCode,
                //Type = request.Type,
                //SenderName = request.SenderName,
                //ReceiverName = request.ReceiverName,
                //SenderCurrencyId = request.SenderCurrencyId,
                //ReceiverCurrencyId = request.ReceiverCurrencyId,
                //ExchangeRate = request.ExchangeRate,
                //SendAmount = request.SendAmount,
                //ReceiveAmount = request.ReceiveAmount,
                //ExchangedAmount = request.ExchangedAmount,
                //Fee = request.Fee,
                //Vat = request.Vat,
                //CommissionPaidBy = request.CommissionPaidBy,
                //SenderCustomerId = request.SenderCustomerId,
                //ReceiverCustomerId = request.ReceiverCustomerId,
                //Source = request.Source,
                //OrderId = request.OrderId,
                //RemoteOrderId = request.RemoteOrderId,
                //InvoiceId = request.InvoiceId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
        public CreateTransactionResponse CreateTransactionByQuotationId(ulong quotationId, MoneyTransferDTO request)
        {
            var transaction = _thunesClient.QuotationAdapter().GetQuotationById(quotationId);
            _imtQuotation = _quotationRepository.Where(c=>c.OrderId == request.external_id).ToList()?.OrderBy(c=>c.Id)?.Last();
            if (request.IsValid(transaction?.transaction_type?.ToLower()))
            {
                try
                {
                    return (CreateTransactionResponse)_thunesClient.GetTransactionAdapter().CreateTransaction(quotationId, request);
                }
                catch (ThunesException e)
                {
                    ErrorStore(e.Errors);
                    throw e;
                }
            }
          throw new ThunesException(422,"Not a valid request");
        }

        public CreateTransactionResponse CreateTransactionByExternalId(int external_id, MoneyTransferDTO request)
        {
            if (request.IsValid(null))
            {
                try
                {
                    return (CreateTransactionResponse)_thunesClient.GetTransactionAdapter().CreateTransactionFromQuotationExternalId(external_id, request);
                }
                catch (ThunesException e)
                {
                    ErrorStore(e.Errors);
                    throw e;
                }
            }
           throw new ThunesException(422,"Not a valid request");
        }

        private void ErrorStore(List<ErrorsResponse> Errors)
        {
            foreach (var error in Errors)
            {

                ImtProviderErrorDetail prepareData = new ImtProviderErrorDetail
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
