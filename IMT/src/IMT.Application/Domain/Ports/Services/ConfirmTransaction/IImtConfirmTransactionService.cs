
using IMT.Application.Domain.Ports.Repositories.ConfirmTransaction;
using IMT.Thunes.Request.ConfirmTrasaction;
using IMT.Thunes.Response.Common;

namespace IMT.Application.Domain.Ports.Services.ConfirmTransaction
{
    public interface IImtConfirmTransactionService: IImtProviderErrorDetailsRepository
    {
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO);
        public void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO);
    }
}
