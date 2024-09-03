using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.Providers
{
    public class ProviderBaseController : ApiControllerBase
    {
        protected ProviderBaseController(ILogger<ProviderBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {

        }
    }
}
