
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("User Group Role")]
    [ApiController]
    public class AclUserGroupRoleController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclUserGroupRoleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.List, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.List)]
        public async Task<AclResponse> Index(ulong userGroupId)
        {
            return await _unitOfWork.AclUserGroupRoleRepository.GetRolesByUserGroupId(userGroupId);
        }

        [HttpPost(Route.AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Name = Route.AclRoutesName.AclUserGroupRoleRouteNames.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await _unitOfWork.AclUserGroupRoleRepository.Update(objUserGroupRole);
        }

      
    }
}
