using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Auth;

public class AuthBase : ApiControllerBase
{
    protected AuthBase(ILogger<AuthBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}