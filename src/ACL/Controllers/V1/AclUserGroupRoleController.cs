
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("User Group Role")]
    [ApiController]
    public class AclUserGroupRoleController : ControllerBase
    {
        private readonly IAclUserGroupRoleRepository _repository;
        public AclUserGroupRoleController(IAclUserGroupRoleRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public async Task<AclResponse> Index(ulong userGroupId)
        {
            return await _repository.GetRolesByUserGroupId(userGroupId);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await _repository.Update(objUserGroupRole);
        }


    }
}
