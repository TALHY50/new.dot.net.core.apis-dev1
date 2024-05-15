using ACL.Application.Interfaces;
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
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclUserGroupRoleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public async Task<AclResponse> Index(ulong userGroupId)
        {
            return await _unitOfWork.AclUserGroupRoleRepository.GetRolesByUserGroupId(userGroupId);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await _unitOfWork.AclUserGroupRoleRepository.Update(objUserGroupRole);
        }


    }
}
