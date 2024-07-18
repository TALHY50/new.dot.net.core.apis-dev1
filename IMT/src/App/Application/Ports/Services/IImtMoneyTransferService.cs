using App.Application.Ports.Repositories;
using SharedKernel.Domain.IMT;
using Thunes.Request.Transaction.Transfer.CommonTransaction;
using Thunes.Response.Transfer.Quotation;
using Thunes.Response.Transfer.Transaction;

namespace App.Application.Ports.Services
{
    public interface IImtMoneyTransferService : IImtMoneyTransferRepository
    {
        public ImtMoneyTransfer PrepareImtMoneyTransfer(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public ImtTransaction PrepareImtTransaction(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public CreateTransactionResponse CreateTransactionByQuotationId(ulong quotationId, MoneyTransferDTO request);
        public CreateTransactionResponse CreateTransactionByExternalId(int external_id, MoneyTransferDTO request);
    }
}
