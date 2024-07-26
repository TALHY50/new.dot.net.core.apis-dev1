using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Domain.IMT;
using Thunes.Request.Transaction.Transfer.CommonTransaction;
using Thunes.Response.Transfer.Quotation;
using Thunes.Response.Transfer.Transaction;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtMoneyTransferService : IImtMoneyTransferRepository
    {
        public ImtMoneyTransfer PrepareImtMoneyTransfer(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public ImtTransaction PrepareImtTransaction(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public CreateTransactionResponse CreateTransactionByQuotationId(ulong quotationId, MoneyTransferDTO request);
        public CreateTransactionResponse CreateTransactionByExternalId(int external_id, MoneyTransferDTO request);
    }
}
