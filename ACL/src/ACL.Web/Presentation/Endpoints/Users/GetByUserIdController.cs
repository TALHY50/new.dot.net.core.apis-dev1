//using ACL.Business.Contracts.Responses;
//using ACL.Business.Domain.Services;
//using ACL.Web.Presentation.Endpoints.Users;
//using ACL.Web.Presentation.Routes;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace ACL.Web.Presentation.Endpoints.Branches;

//public class GetByUserIdController : UserBaseController
//{
//    public GetByUserIdController(IUserService userService) : base(userService)
//    {
//    }

//    /// <inheritdoc/>
//    [Authorize(Policy = "HasPermission")]
//    [HttpGet(AclRoutesUrl.AclUserRouteUrl.View, Name = AclRoutesName.AclUserRouteNames.View)]
//    public ScopeResponse View(uint id)
//    {
//        return this._userService.FindById(id);

//    }
//}