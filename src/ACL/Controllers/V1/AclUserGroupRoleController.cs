using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.UseCases.Interfaces.Repositories.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User Group Role")]
    [ApiController]
    public class AclUserGroupRoleController : ControllerBase
    {
        private readonly IAclUserGroupRoleRepository _repository;
        /// <inheritdoc/>
        public AclUserGroupRoleController(IAclUserGroupRoleRepository repository)
        {
            _repository = repository;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public AclResponse Index(ulong userGroupId)
        {
            return _repository.GetRolesByUserGroupId(userGroupId);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await _repository.Update(objUserGroupRole);
        }


    }
}
