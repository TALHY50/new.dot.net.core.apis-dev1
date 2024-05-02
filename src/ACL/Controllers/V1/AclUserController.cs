using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("User")]
    [ApiController]
    public class AclUserController : ControllerBase
    {

        private readonly ICustomUnitOfWork _unitOfWork;
        public AclUserController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclUserRouteUrl.List, Name = AclRoutesName.AclUserRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclUserRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclUserRouteUrl.Add, Name = AclRoutesName.AclUserRouteNames.Add)]
        public async Task<AclResponse> Create(AclUserRequest request)
        {
            return await _unitOfWork.AclUserRepository.AddUser(request);
        }
        [HttpPut(AclRoutesUrl.AclUserRouteUrl.Edit, Name = AclRoutesName.AclUserRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            return await _unitOfWork.AclUserRepository.Edit(id, request);
        }

        [HttpDelete(AclRoutesUrl.AclUserRouteUrl.Destroy, Name = AclRoutesName.AclUserRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclUserRepository.DeleteById(id);
        }

        [HttpGet(AclRoutesUrl.AclUserRouteUrl.View, Name = AclRoutesName.AclUserRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclUserRepository.FindById(id);

        }

    }
}
