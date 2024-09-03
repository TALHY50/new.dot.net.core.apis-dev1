using Admin.Web.Presentation.Endpoints.Corridors;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.Payers
{
    public class PayerBaseController : ApiControllerBase
    {
        protected PayerBaseController(ILogger<PayerBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
