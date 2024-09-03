using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.Banks
{
    public class BankBaseController : ApiControllerBase
    {
        protected BankBaseController(ILogger<BankBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
