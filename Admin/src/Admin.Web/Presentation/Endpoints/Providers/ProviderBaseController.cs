using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.Providers
{
    public class ProviderBaseController : ApiControllerBase
    {
        protected ProviderBaseController(ILogger<ProviderBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {

        }
    }
}
