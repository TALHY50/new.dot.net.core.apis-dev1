using IMT.Application.Application.Ports.Repositories;
using IMT.Thunes.Request.ConfirmTrasaction;
using IMT.Thunes.Response.Common;

namespace IMT.Application.Application.Ports.Services
{
    public interface IImtConfirmTransactionService: IImtProviderErrorDetailsRepository
    {
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO);
        public void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO);
    }
}
