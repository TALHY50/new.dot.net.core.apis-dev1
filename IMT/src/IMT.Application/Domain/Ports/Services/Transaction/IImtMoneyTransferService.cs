using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Contracts.Requests.Transfer;
using IMT.Application.Domain.Ports.Repositories.ImtMoneyTransfer;
using IMT.Thunes.Request.Transaction.Quotation;
using SharedLibrary.Models.IMT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Domain.Ports.Services.Transaction
{
    public interface IImtMoneyTransferService : IImtMoneyTransferRepository
    {
        public bool IsValid(MoneyTransferRequest request);
        public IMT.Thunes.Request.Transaction.Transfer.CommonTransaction.MoneyTransferDTO PrepareThunesCreateTransactionRequest(MoneyTransferRequest request);
        public ImtMoneyTransfer PrepareImtQuotation(MoneyTransferRequest request);
        public object CreateTransaction(MoneyTransferRequest request);
    }
}
