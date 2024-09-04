using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Users;

[Tags("User")]
[ApiController]
public class UserBaseController : ApiControllerBase
{
    protected IUserService _userService;

    public UserBaseController(IUserService userService)
    {
        _userService = userService;
    }

}