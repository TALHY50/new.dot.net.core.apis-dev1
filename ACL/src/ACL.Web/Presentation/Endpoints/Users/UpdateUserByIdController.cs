using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Endpoints.Users;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;

public class UpdateUserByIdController : UserBaseController
{
    public UpdateUserByIdController(IUserService userService) : base(userService)
    {
    }

    [Authorize(Policy = "HasPermission")]
    [HttpPut(AclRoutesUrl.AclUserRouteUrl.Edit, Name = AclRoutesName.AclUserRouteNames.Edit)]
    [HttpPatch(AclRoutesUrl.AclUserRouteUrl.Edit, Name = AclRoutesName.AclUserRouteNames.Edit)]
    public async Task<ScopeResponse> Edit(uint id, AclUserRequest request)
    {
        return await this._userService.Edit(id, request);
    }
}