
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

        [HttpGet(Route.AclRoutesUrl.AclUserGroupRole.List, Name = Route.AclRoutesName.AclUserGroupRole.List)]
        public async Task<AclResponse> Index(ulong userGroupId)
        {
            return await _unitOfWork.AclUserGroupRoleRepository.GetRolesByUserGroupId(userGroupId);
        }

        [HttpPost(Route.AclRoutesUrl.AclUserGroupRole.Update, Name = Route.AclRoutesName.AclUserGroupRole.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await _unitOfWork.AclUserGroupRoleRepository.Update(objUserGroupRole);
        }

      
    }
}
