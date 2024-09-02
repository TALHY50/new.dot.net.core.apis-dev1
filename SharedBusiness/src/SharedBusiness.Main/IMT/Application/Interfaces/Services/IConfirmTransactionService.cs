using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using Thunes.Request.ConfirmTrasaction;
using Thunes.Response.Common;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Services
{
    public interface IConfirmTransactionService : IProviderErrorDetailsRepository
    {
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO);
        public void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO);
    }
}
