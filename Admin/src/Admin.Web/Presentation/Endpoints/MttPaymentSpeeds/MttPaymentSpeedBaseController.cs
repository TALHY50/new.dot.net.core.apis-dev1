using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.MttPaymentSpeeds
{
    public class MttPaymentSpeedBaseController : ApiControllerBase
    {
        protected MttPaymentSpeedBaseController(ILogger<MttPaymentSpeedBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {

        }
    }
}
