using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.UserGroups
{
    public class UserGroupBaseController : ApiControllerBase
    {
        protected UserGroupBaseController(ILogger<UserGroupBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
