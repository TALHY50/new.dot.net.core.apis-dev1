using IMT.App.Contracts.Requests;
using Thunes.Request.Transaction.Transfer.CommonTransaction;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtSendMoneyService
    {
        public object SendMoney(SendMoneyRequest request);

         public QuotationRequest PrepareQuotation(SendMoneyRequest request);

         public MoneyTransferDTO PrepareTransaction(SendMoneyRequest request);
    }
}