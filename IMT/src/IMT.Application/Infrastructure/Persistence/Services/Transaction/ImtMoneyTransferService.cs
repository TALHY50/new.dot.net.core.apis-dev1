//using IMT.Application.Contracts.Requests.Transfer;
//using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
//using IMT.Application.Domain.Ports.Services.Quotation;
//using IMT.Application.Domain.Ports.Services.Transaction;
//using IMT.Application.Infrastructure.Persistence.Repositories.ImtMoneyTransfer;
//using IMT.Application.Infrastructure.Utility;
//using IMT.Thunes;
//using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
//using SharedLibrary.Models.IMT;
//using SharedLibrary.Persistence.Configurations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IMT.Application.Infrastructure.Persistence.Services.Transaction
//{
//    public class ImtMoneyTransferService : ImtMoneyTransferRepository, IImtMoneyTransferService
//    {
//        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");

//        public ImtMoneyTransferService(ApplicationDbContext dbContext) : base(dbContext)
//        {
//            DependencyContainer.Initialize();
//        }
//        public object IImtMoneyTransferService.CreateTransaction(ulong id, MoneyTransferRequest request)
//        {
//            var transactionType = _thunesClient.QuotationAdapter().GetQuotationById(id);
//            if (request.IsValid(transactionType?.transaction_type?.ToLower()))
//            {
//                return _thunesClient.GetTransactionAdapter().CreateTransaction(id, request);
//            }
//        }

//        public bool IImtMoneyTransferService.IsValid(MoneyTransferRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        public ImtMoneyTransfer IImtMoneyTransferService.PrepareImtQuotation(MoneyTransferRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        public MoneyTransferDTO IImtMoneyTransferService.PrepareThunesCreateTransactionRequest(MoneyTransferRequest request)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
