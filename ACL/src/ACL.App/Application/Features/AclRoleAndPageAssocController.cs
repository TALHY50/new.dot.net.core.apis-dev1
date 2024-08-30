using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.Web.Application.Features
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
            _rolePageService = rolePageService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRolePageRouteUrl.List, Name = AclRoutesName.AclRolePageRouteNames.List)]
        public async Task<ScopeResponse> Index(ulong id)
        {
            return await _rolePageService.GetAllById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRolePageRouteUrl.Edit, Name = AclRoutesName.AclRolePageRouteNames.Edit)]
        public async Task<ScopeResponse> Update(AclRoleAndPageAssocUpdateRequest req)
        {
            return await _rolePageService.UpdateAll(req);
        }
    }
}
