
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
        private readonly IUnitOfWork _repository;
        public AclUserGroupRoleController(IUnitOfWork repository)
        {
            _repository = repository;
        }

        [HttpGet(Route.AclRoutesUrl.AclUserGroupRole.List, Name = Route.AclRoutesName.AclUserGroupRole.List)]
        public async Task<AclResponse> Index(ulong userGroupId)
        {
            return _repository.AclUserGroupRoleRepository.GetRolesByUserGroupId(userGroupId);
        }

        [HttpPost(Route.AclRoutesUrl.AclUserGroupRole.Update, Name = Route.AclRoutesName.AclUserGroupRole.Update)]
        public async Task<AclResponse> Update(AclUserGroupRoleRequest objUserGroupRole)
        {
            return await _repository.AclUserGroupRoleRepository.Update(objUserGroupRole);
        }

      
    }
}
