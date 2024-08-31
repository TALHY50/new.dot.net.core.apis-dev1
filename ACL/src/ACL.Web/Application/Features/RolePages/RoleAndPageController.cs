using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace ACL.Web.Application.Features.RolePages
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Role & Page Association")]
    [ApiController]
    public class RoleAndPageController : ControllerBase
    {
        private readonly IRolePageService _rolePageService;
         /// <inheritdoc/>
        public RoleAndPageController(IRolePageService rolePageService)
        {
           this._rolePageService = rolePageService;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRolePageRouteUrl.List, Name = AclRoutesName.AclRolePageRouteNames.List)]
        public async Task<ScopeResponse> Index(ulong id)
        {
            return await this._rolePageService.GetAllById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRolePageRouteUrl.Edit, Name = AclRoutesName.AclRolePageRouteNames.Edit)]
        public async Task<ScopeResponse> Update(AclRoleAndPageAssocUpdateRequest req)
        {
            return await this._rolePageService.UpdateAll(req);
        }
    }
}
