using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Users;

[Tags("User")]
[ApiController]
public class UserBaseController : ApiControllerBase
{
            public UserBaseController(ILogger<UserBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
}