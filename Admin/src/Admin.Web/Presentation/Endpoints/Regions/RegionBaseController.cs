using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.Regions
{
    public class RegionBaseController : ApiControllerBase
    {
        protected RegionBaseController(ILogger<RegionBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
            
        }
    }
}
