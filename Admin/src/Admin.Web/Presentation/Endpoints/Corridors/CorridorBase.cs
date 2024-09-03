using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.Corridors
{
    public class CorridorBase : ApiControllerBase
    {
        protected CorridorBase(ILogger<CorridorBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {   
        }
    }
}
