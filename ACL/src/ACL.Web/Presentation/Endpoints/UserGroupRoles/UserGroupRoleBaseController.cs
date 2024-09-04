using ACL.Web.Presentation.Endpoints.RolePages;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.UserGroupRoles
{
    public class UserGroupRoleBaseController : ApiControllerBase
    {
        protected UserGroupRoleBaseController(ILogger<UserGroupRoleBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
