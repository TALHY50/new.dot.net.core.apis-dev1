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
        private readonly ICustomUnitOfWork _unitOfWork;

        public AclUserGroupController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.List, Name = AclRoutesName.AclUserGroupRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclUserGroupRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclUserGroupRouteUrl.Add, Name = AclRoutesName.AclUserGroupRouteNames.Add)]
        public async Task<AclResponse> Create(AclUserGroupRequest request)
        {
            return await _unitOfWork.AclUserGroupRepository.AddUserGroup(request);
        }

        [HttpPut(AclRoutesUrl.AclUserGroupRouteUrl.Edit, Name = AclRoutesName.AclUserGroupRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserGroupRequest request)
        {
            return await _unitOfWork.AclUserGroupRepository.UpdateUserGroup(id, request);
        }
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.View, Name = AclRoutesName.AclUserGroupRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclUserGroupRepository.FindById(id);
        }

        [HttpDelete(AclRoutesUrl.AclUserGroupRouteUrl.Destroy, Name = AclRoutesName.AclUserGroupRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclUserGroupRepository.Delete(id);
        }
    }
}
