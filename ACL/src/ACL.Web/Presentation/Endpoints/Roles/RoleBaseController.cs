using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Roles
{
    public class RoleBaseController : ApiControllerBase
    {
        protected RoleBaseController(ILogger<RoleBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
