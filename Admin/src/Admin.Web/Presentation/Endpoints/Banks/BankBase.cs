using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.Banks
{
    public class BankBase : ApiControllerBase
    {
        protected BankBase(ILogger<BankBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
