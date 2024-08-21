using ACL.App.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Services.Role;

namespace ACL.App.Application.Features
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Role & Page Association")]
    [ApiController]
    public class AclRoleAndPageAssocController : ControllerBase
    {
        private readonly IAclRolePageService AclRolePageService;
         /// <inheritdoc/>
        public AclRoleAndPageAssocController(IAclRolePageService _AclRolePageService)
        {
           this.AclRolePageService = _AclRolePageService;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRolePageRouteUrl.List, Name = AclRoutesName.AclRolePageRouteNames.List)]
        public async Task<AclResponse> Index(ulong id)
        {
            return await this.AclRolePageService.GetAllById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRolePageRouteUrl.Edit, Name = AclRoutesName.AclRolePageRouteNames.Edit)]
        public async Task<AclResponse> Update(AclRoleAndPageAssocUpdateRequest req)
        {
            return await this.AclRolePageService.UpdateAll(req);
        }
    }
}
