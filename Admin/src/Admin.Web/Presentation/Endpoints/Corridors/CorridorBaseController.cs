using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.Corridors
{
    public class CorridorBaseController : ApiControllerBase
    {
        protected CorridorBaseController(ILogger<CorridorBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {   
        }
    }
}
