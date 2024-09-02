using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.TransactionTypes
{
    public class TransactionTypeBase : ApiControllerBase
    {
        protected TransactionTypeBase(ILogger<TransactionTypeBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
