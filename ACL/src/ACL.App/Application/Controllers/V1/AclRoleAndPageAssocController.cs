using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Services.Role;
using ACL.App.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.App.Application.Controllers.V1
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
