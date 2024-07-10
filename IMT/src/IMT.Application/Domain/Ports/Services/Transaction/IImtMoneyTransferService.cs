using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Contracts.Requests.Transfer;
using IMT.Application.Domain.Ports.Repositories.ImtMoneyTransfer;
using IMT.Thunes.Request.Transaction.Quotation;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Thunes.Response.Transfer.Quotation;
using IMT.Thunes.Response.Transfer.Transaction;
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
        public ImtMoneyTransfer PrepareImtMoneyTransfer(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public ImtTransaction PrepareImtTransaction(MoneyTransferDTO request, CreateContentQuotationResponse quotation, CreateTransactionResponse transaction);
        public CreateTransactionResponse CreateTransactionByQuotationId(ulong quotationId, MoneyTransferDTO request);
        public CreateTransactionResponse CreateTransactionByExternalId(int external_id, MoneyTransferDTO request);
    }
}
