using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.InstitutionFunds
{
    public class InstitutionFundBaseController : ApiControllerBase
    {
        protected InstitutionFundBaseController(ILogger<InstitutionFundBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
