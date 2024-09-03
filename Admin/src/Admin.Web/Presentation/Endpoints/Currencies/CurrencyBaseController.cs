using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.Currencies
{
    public class CurrencyBaseController : ApiControllerBase
    {
        protected CurrencyBaseController(ILogger<CurrencyBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
