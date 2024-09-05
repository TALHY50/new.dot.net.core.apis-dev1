using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Modules
{
    public class ModuleBaseController : ApiControllerBase
    {
        protected ModuleBaseController(ILogger<ModuleBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
