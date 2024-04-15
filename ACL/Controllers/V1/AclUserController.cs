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

        private readonly IUnitOfWork _unitOfWork;
        public AclUserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclUser.List, Name = AclRoutesName.AclUserNames.List)]
        public async Task<IActionResult> Index()
        {
            return Ok(_unitOfWork.AclUserRepository.GetAll());
        }

        [HttpPost(AclRoutesUrl.AclUser.Add, Name = AclRoutesName.AclUserNames.Add)]
        public async Task<AclResponse> Create(AclUserRequest request)
        {
            return _unitOfWork.AclUserRepository.Add(request);
        }
        [HttpPut(AclRoutesUrl.AclUser.Edit, Name = AclRoutesName.AclUserNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            return _unitOfWork.AclUserRepository.Edit(id, request);

        }

        [HttpDelete(AclRoutesUrl.AclUser.Destroy, Name = AclRoutesName.AclUserNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _unitOfWork.AclUserRepository.deleteById(id);
        }

        [HttpGet(AclRoutesUrl.AclUser.View, Name = AclRoutesName.AclUserNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return _unitOfWork.AclUserRepository.findById(id);

        }

    }
}
