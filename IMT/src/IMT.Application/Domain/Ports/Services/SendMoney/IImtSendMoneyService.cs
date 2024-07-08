using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Contracts.Requests.SendMoiney;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;

namespace IMT.Application.Domain.Ports.Services.SendMoney
{
    public interface IImtSendMoneyService
    {
        public object SendMoney(SendMoneyRequest request);

         public QuotationRequest PrepareQuotation(SendMoneyRequest request);

         public MoneyTransferDTO PrepareTransaction(SendMoneyRequest request);
    }
}