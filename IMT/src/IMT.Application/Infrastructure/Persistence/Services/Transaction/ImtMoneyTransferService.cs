using IMT.Application.Contracts.Requests.Transfer;
using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Application.Domain.Ports.Services.Transaction;
using IMT.Application.Infrastructure.Persistence.Repositories.ImtMoneyTransfer;
using IMT.Application.Infrastructure.Utility;
using IMT.Thunes;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Thunes.Response.Transfer.Transaction;
using Mysqlx.Crud;
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Infrastructure.Persistence.Services.Transaction
{
    public class ImtMoneyTransferService : ImtMoneyTransferRepository, IImtMoneyTransferService
    {
        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");

        public ImtMoneyTransferService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
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
            var transactionType = _thunesClient.QuotationAdapter().GetQuotationById(quotationId);
            if (request.IsValid(transactionType?.transaction_type?.ToLower()))
            {
                return (CreateTransactionResponse)_thunesClient.GetTransactionAdapter().CreateTransaction(quotationId, request);
            }
            return null;
        }

        public CreateTransactionResponse CreateTransactionByExternalId(int external_id, MoneyTransferDTO request)
        {
            if (request.IsValid(null))
            {
                return (CreateTransactionResponse)_thunesClient.GetTransactionAdapter().CreateTransactionFromQuotationExternalId(external_id, request);
            }
            return null;
        }
    }
}
