using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.TransactionLimits;

public class TransactionLimitBaseController : ApiControllerBase
{
    protected TransactionLimitBaseController(ILogger<TransactionLimitBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}