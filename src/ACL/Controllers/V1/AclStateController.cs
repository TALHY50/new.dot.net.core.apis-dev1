
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
        [HttpGet(Route.AclRoutesUrl.AclStateRouteUrl.List, Name = Route.AclRoutesName.AclStateRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclStateRepository.GetAll();
        }
        [HttpPost(Route.AclRoutesUrl.AclStateRouteUrl.Add, Name = Route.AclRoutesName.AclStateRouteNames.Add)]
        public async Task<AclResponse> Create(AclStateRequest objState)
        {
            return await _unitOfWork.AclStateRepository.Add(objState);
        }
        [HttpGet(Route.AclRoutesUrl.AclStateRouteUrl.View, Name = Route.AclRoutesName.AclStateRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclStateRepository.FindById(id);

        }
        [HttpPut(Route.AclRoutesUrl.AclStateRouteUrl.Edit, Name = Route.AclRoutesName.AclStateRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclStateRequest objState)
        {
            return await _unitOfWork.AclStateRepository.Edit(id, objState);

        }
        [HttpDelete(Route.AclRoutesUrl.AclStateRouteUrl.Destroy, Name = Route.AclRoutesName.AclStateRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclStateRepository.DeleteById(id);
        }




    }
}