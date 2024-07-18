using IMT.Application.Contracts.Requests;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;

namespace IMT.Application.Application.Ports.Services
{
    public interface IImtSendMoneyService
    {
        public object SendMoney(SendMoneyRequest request);

         public QuotationRequest PrepareQuotation(SendMoneyRequest request);

         public MoneyTransferDTO PrepareTransaction(SendMoneyRequest request);
    }
}