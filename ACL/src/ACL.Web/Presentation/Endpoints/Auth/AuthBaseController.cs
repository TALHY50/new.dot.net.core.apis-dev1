using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Auth;

public class AuthBaseController : ApiControllerBase
{
    protected AuthBaseController(ILogger<AuthBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}