using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [ApiController]
    public class AclUserController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public AclUserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclUserUrl.List, Name = AclRoutesName.AclUserNames.List)]
        public async Task<IActionResult> Index()
        {
            return Ok(_unitOfWork.AclUserRepository.GetAll());
        }

        [HttpPost(AclRoutesUrl.AclUserUrl.Add, Name = AclRoutesName.AclUserNames.Add)]
        public async Task<AclResponse> Create(AclUserRequest request)
        {
            return await _unitOfWork.AclUserRepository.Add(request);
        }
        [HttpPut(AclRoutesUrl.AclUserUrl.Edit, Name = AclRoutesName.AclUserNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            return _unitOfWork.AclUserRepository.Edit(id, request);
        }

        [HttpDelete(AclRoutesUrl.AclUserUrl.Destroy, Name = AclRoutesName.AclUserNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _unitOfWork.AclUserRepository.deleteById(id);
        }

        [HttpGet(AclRoutesUrl.AclUserUrl.View, Name = AclRoutesName.AclUserNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return _unitOfWork.AclUserRepository.findById(id);

        }

    }
}
