
using IMT.Application.Domain.Ports.Repositories.ConfirmTransaction;
using IMT.Thunes.Request.ConfirmTrasaction;

namespace IMT.Application.Domain.Ports.Services.ConfirmTransaction
{
    public interface IImtConfirmTransactionService: IImtConfirmTransactionRepository
    {
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO);
    }
}
