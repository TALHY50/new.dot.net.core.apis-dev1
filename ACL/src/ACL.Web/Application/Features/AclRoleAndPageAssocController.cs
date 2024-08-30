using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.App.Application.Features
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Role & Page Association")]
    [ApiController]
    public class AclRoleAndPageAssocController : ControllerBase
    {
        private readonly IRolePageService _rolePageService;
         /// <inheritdoc/>
        public AclRoleAndPageAssocController(IRolePageService rolePageService)
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
