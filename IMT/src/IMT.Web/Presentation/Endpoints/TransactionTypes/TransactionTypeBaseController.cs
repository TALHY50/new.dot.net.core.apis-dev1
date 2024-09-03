using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace IMT.App.Presentation.Endpoints.TransactionTypes
{
    public class TransactionTypeBaseController : ApiControllerBase
    {
        protected TransactionTypeBaseController(ILogger<TransactionTypeBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
