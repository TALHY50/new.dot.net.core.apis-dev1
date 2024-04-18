using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Role & Page Association")]
    [ApiController]
    public class AclRoleAndPageAssocController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclRoleAndPageAssocController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclRolePage.List, Name = AclRoutesName.AclRolePageRouteNames.List)]
        public async Task<AclResponse> Index(ulong id)
        {
            return await _unitOfWork.AclRolePageRepository.GetAllById(id);
        }
        [HttpPut(AclRoutesUrl.AclRolePage.Edit, Name = AclRoutesName.AclRolePageRouteNames.Edit)]
        public async Task<AclResponse> Update(AclRoleAndPageAssocUpdateRequest req)
        {
            return await _unitOfWork.AclRolePageRepository.UpdateAll(req);
        }
    }
}
