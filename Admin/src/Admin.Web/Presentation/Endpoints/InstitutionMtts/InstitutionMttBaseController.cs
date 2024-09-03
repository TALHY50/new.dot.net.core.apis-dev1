using Admin.Web.Presentation.Endpoints.Payers;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.InstitutionMtts
{
    public class InstitutionMttBaseController : ApiControllerBase
    {
        protected InstitutionMttBaseController(ILogger<InstitutionMttBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
