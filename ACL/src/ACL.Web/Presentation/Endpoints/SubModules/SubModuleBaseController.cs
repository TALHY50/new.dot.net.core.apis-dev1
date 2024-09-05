using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.SubModules
{
    public class SubModuleBaseController : ApiControllerBase
    {
        protected SubModuleBaseController(ILogger<SubModuleBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
