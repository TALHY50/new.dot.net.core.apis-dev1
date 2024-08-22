using IMT.App.Application.Ports.Services;
using IMT.App.Infrastructure.Persistence.Repositories.ConfirmTransaction;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using Thunes;
using Thunes.Exception;
using Thunes.Request.ConfirmTrasaction;
using Thunes.Response.Common;
using Thunes.Response.Transfer.Transaction;

namespace IMT.App.Infrastructure.Persistence.Services.ConfirmTransactionService
{

#pragma warning disable CS8629 // Nullable value type may be null.
    public class ImtConfirmTransactionService : ImtProviderErrorDetailsRepository, IImtConfirmTransactionService
    {
        // public readonly ThunesClient _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));
        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");
        private readonly IImtMoneyTransferService _moneyTransferService;
        private MoneyTransfer moneyTransferObj;
        private SharedKernel.Main.Domain.IMT.Entities.Transaction _transaction;
        private ConfirmTransactionResponse confirmTransactionResponse;
        public IImtTransactionRepository _transactionRepository;
        private enum TransactionStates { PENDING = 1, CONFIRMED = 2, FAILED = 3 };
        public ImtConfirmTransactionService(ApplicationDbContext dbContext, IImtMoneyTransferService moneyTransferService) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _moneyTransferService = moneyTransferService;
            _transactionRepository = DependencyContainer.GetService<IImtTransactionRepository>();
        }
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO)
        {
            moneyTransferObj = _moneyTransferService.Where(x => x.PaymentId == trasactionDTO.RemoteTrasactionId.ToString()).FirstOrDefault();
            try
            {
                confirmTransactionResponse = _thunesClient.GetTransactionAdapter().ConfirmTransactionById(trasactionDTO.RemoteTrasactionId);

                if (moneyTransferObj != null)
                {
                    if (confirmTransactionResponse.status == "20000" && confirmTransactionResponse.status_message == "CONFIRMED")
                    {
                        moneyTransferObj.TransactionStateId = (int)TransactionStates.CONFIRMED;
                        moneyTransferObj.UpdatedAt = DateTime.Now;
                    }

                    _moneyTransferService.Update(moneyTransferObj);
                    _transactionRepository.Add(PrepareTransaction(moneyTransferObj));
                }

                return confirmTransactionResponse;
            }
            catch (ThunesException e)
            {

                if (moneyTransferObj != null)
                {
                    ErrorStore(e.Errors, trasactionDTO);

                    moneyTransferObj.TransactionStateId = (int)TransactionStates.FAILED;
                    moneyTransferObj.UpdatedAt = DateTime.Now;
                    _moneyTransferService.Update(moneyTransferObj);

                    _transactionRepository.Add(PrepareTransaction(moneyTransferObj));
                }

                throw e;
            }
        }

        public void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO)
        {
            foreach (var error in Errors)
            {
                ProviderErrorDetail prepareData = new ProviderErrorDetail
                {
                    ErrorCode = error.code,
                    ErrorMessage = error.message,
                    ImtProviderId = trasactionDTO.ProviderId,
                    ReferenceId = trasactionDTO.RemoteTrasactionId,
                    Type = trasactionDTO.Type,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                Add(prepareData);
            }
        }

        public SharedKernel.Main.Domain.IMT.Entities.Transaction PrepareTransaction(MoneyTransfer moneyTransferObj)
        {
            var transaction = new SharedKernel.Main.Domain.IMT.Entities.Transaction
            {
                PaymentId = moneyTransferObj.PaymentId,
                TransactionStateId = moneyTransferObj.TransactionStateId,
                CustomerId = 1, // hard coded dont know from where it will come
                TransactionType = 1, // hard coded value cause we dont know from where we will get it
                MoneyFlow = 2,
                Amount = (decimal)100.00, // dont know which amount it will be
                TransactionId = moneyTransferObj.Id,
                Fee = moneyTransferObj.Fee,
                Gross = (decimal)1000.00, // dont know what is this and from where it will come
                CurrencyId = 1, //hard coded need to call the api and hold the data here
                CurrentBalance = (decimal)1000.00, //hard coded need to call the api and hold the data here
                PreviousBalance = (decimal)1000.00, //hard coded need to call the api and hold the data here
                Status = 1, // hard coded need to know from where And when depends what to update and what value to put from where
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return transaction;
        }


    }
}
