using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("User Group")]
    [ApiController]
    public class AclUserGroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclUserGroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet(AclRoutesUrl.AclUserGroupRoutesUrl.List, Name = AclRoutesName.AclUserGroupRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclUserGroupRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclUserGroupRoutesUrl.Add, Name = AclRoutesName.AclUserGroupRouteNames.Add)]
        public async Task<AclResponse> Create(AclUserGroupRequest request)
        {
            return await _unitOfWork.AclUserGroupRepository.AddUserGroup(request);
        }

        [HttpPut(AclRoutesUrl.AclUserGroupRoutesUrl.Edit, Name = AclRoutesName.AclUserGroupRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserGroupRequest request)
        {
            return await _unitOfWork.AclUserGroupRepository.UpdateUserGroup(id, request);
        }
        [HttpGet(AclRoutesUrl.AclUserGroupRoutesUrl.View, Name = AclRoutesName.AclUserGroupRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclUserGroupRepository.FindById(id);
        }

        [HttpDelete(AclRoutesUrl.AclUserGroupRoutesUrl.Destroy, Name = AclRoutesName.AclUserGroupRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclUserGroupRepository.Delete(id);
        }
    }
}
