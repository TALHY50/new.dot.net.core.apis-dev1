using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using Thunes.Request.Transaction.Transfer.CommonTransaction;
using Thunes.Response.Transfer.Quotation;
using Thunes.Response.Transfer.Transaction;

namespace IMT.App.Application.Interfaces.Services
{
    public interface IImtMoneyTransferService : IImtMoneyTransferRepository
    {
        public MoneyTransfer PrepareImtMoneyTransfer(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public Transaction PrepareImtTransaction(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public CreateTransactionResponse CreateTransactionByQuotationId(ulong quotationId, MoneyTransferDTO request);
        public CreateTransactionResponse CreateTransactionByExternalId(string invoice_id, MoneyTransferDTO request);
    }
}
