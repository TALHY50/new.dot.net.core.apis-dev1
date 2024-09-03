using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.Regions
{
    public class RegionBase : ApiControllerBase
    {
        protected RegionBase(ILogger<RegionBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
            
        }
    }
}
