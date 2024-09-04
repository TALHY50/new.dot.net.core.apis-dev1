using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Endpoints.Users;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;

public class DeleteByUserIdController : UserBaseController
{
    public DeleteByUserIdController(IUserService userService) : base(userService)
    {
    }

    [Authorize(Policy = "HasPermission")]
    [HttpDelete(AclRoutesUrl.AclUserRouteUrl.Destroy, Name = AclRoutesName.AclUserRouteNames.Destroy)]
    public ScopeResponse Destroy(uint id)
    {
        return this._userService.DeleteById(id);
    }
}