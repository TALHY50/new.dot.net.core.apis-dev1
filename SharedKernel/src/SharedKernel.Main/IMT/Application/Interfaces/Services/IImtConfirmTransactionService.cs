using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using Thunes.Request.ConfirmTrasaction;
using Thunes.Response.Common;

namespace SharedKernel.Main.IMT.Application.Interfaces.Services
{
    public interface IImtConfirmTransactionService : IImtProviderErrorDetailsRepository
    {
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO);
        public void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO);
    }
}
