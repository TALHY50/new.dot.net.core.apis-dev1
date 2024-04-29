
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("State")]
    [ApiController]
    public class AclStateController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclStateController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet(Route.AclRoutesUrl.AclState.List, Name = Route.AclRoutesName.AclState.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclStateRepository.GetAll();
        }
        [HttpPost(Route.AclRoutesUrl.AclState.Add, Name = Route.AclRoutesName.AclState.Add)]
        public async Task<AclResponse> Create(AclStateRequest objState)
        {
            return await _unitOfWork.AclStateRepository.Add(objState);
        }
        [HttpGet(Route.AclRoutesUrl.AclState.View, Name = Route.AclRoutesName.AclState.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclStateRepository.FindById(id);

        }
        [HttpPut(Route.AclRoutesUrl.AclState.Edit, Name = Route.AclRoutesName.AclState.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclStateRequest objState)
        {
            return await _unitOfWork.AclStateRepository.Edit(id, objState);

        }
        [HttpDelete(Route.AclRoutesUrl.AclState.Destroy, Name = Route.AclRoutesName.AclState.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclStateRepository.DeleteById(id);
        }




    }
}
