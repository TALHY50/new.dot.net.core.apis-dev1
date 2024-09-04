using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.RolePages;

public class RolePageBaseController : ApiControllerBase
{
    protected RolePageBaseController(ILogger<RolePageBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }

}
