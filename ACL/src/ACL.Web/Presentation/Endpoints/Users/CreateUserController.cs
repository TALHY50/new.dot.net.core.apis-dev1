using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Endpoints.Users;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;


public class CreateUserController : UserBaseController
{
    public CreateUserController(IUserService branchService) : base(branchService)
    {
    }

    /// <inheritdoc/>
    // [Authorize(Policy = "HasPermission")]
    [HttpPost(AclRoutesUrl.AclUserRouteUrl.Add, Name = AclRoutesName.AclUserRouteNames.Add)]
    public async Task<ScopeResponse> Create(AclUserRequest request)
    {
        return await this._userService.AddUser(request);
    }
}