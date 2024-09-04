//using ACL.Business.Contracts.Responses;
//using ACL.Business.Domain.Services;
//using ACL.Web.Presentation.Endpoints.Users;
//using ACL.Web.Presentation.Routes;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace ACL.Web.Presentation.Endpoints.Branches;

//public class GetUsersController : UserBaseController
//{
//    public GetUsersController(IUserService userService) : base(userService)
//    {
//    }

//    /// <inheritdoc/>
//    [Authorize(Policy = "HasPermission")]
//    [HttpGet(AclRoutesUrl.AclUserRouteUrl.List, Name = AclRoutesName.AclUserRouteNames.List)]
//    public ScopeResponse Index()
//    {
//        return this._userService.GetAll();
//    }
//}