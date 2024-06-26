using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Repositories.Role;
using ACL.Application.Ports.Services.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
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
           AclRolePageService = _AclRolePageService;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRolePageRouteUrl.List, Name = AclRoutesName.AclRolePageRouteNames.List)]
        public async Task<AclResponse> Index(ulong id)
        {
            return await AclRolePageService.GetAllById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRolePageRouteUrl.Edit, Name = AclRoutesName.AclRolePageRouteNames.Edit)]
        public async Task<AclResponse> Update(AclRoleAndPageAssocUpdateRequest req)
        {
            return await AclRolePageService.UpdateAll(req);
        }
    }
}
