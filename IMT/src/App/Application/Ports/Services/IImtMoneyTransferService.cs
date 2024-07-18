using IMT.Application.Application.Ports.Repositories;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Thunes.Response.Transfer.Quotation;
using IMT.Thunes.Response.Transfer.Transaction;
using SharedKernel.Domain.IMT;

namespace IMT.Application.Application.Ports.Services
{
    public interface IImtMoneyTransferService : IImtMoneyTransferRepository
    {
        public ImtMoneyTransfer PrepareImtMoneyTransfer(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public ImtTransaction PrepareImtTransaction(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public CreateTransactionResponse CreateTransactionByQuotationId(ulong quotationId, MoneyTransferDTO request);
        public CreateTransactionResponse CreateTransactionByExternalId(int external_id, MoneyTransferDTO request);
    }
}
