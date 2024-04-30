
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Sub Module")]
    [ApiController]
    public class AclSubModuleController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclSubModuleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = Route.AclRoutesName.AclSubmoduleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclSubModuleRepository.GetAll();
        }
        [HttpPost(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Add)]
        public async Task<AclResponse> Create(AclSubModuleRequest objSubModule)
        {
            return await _unitOfWork.AclSubModuleRepository.Add(objSubModule);
        }
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = Route.AclRoutesName.AclSubmoduleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclSubModuleRepository.FindById(id);

        }
        [HttpPut(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return await _unitOfWork.AclSubModuleRepository.Edit(id, objSubModule);

        }
        [HttpDelete(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclSubModuleRepository.DeleteById(id);
        }




    }
}