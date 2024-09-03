using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.TransactionLimits;

public class TransactionLimitBase : ApiControllerBase
{
    protected TransactionLimitBase(ILogger<TransactionLimitBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}