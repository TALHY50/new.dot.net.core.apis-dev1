using ACL.Application.Interfaces;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Sub Module")]
    [ApiController]
    public class AclSubModuleController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclSubModuleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = Route.AclRoutesName.AclSubmoduleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclSubModuleRepository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Add)]
        public async Task<AclResponse> Create(AclSubModuleRequest objSubModule)
        {
            return await _unitOfWork.AclSubModuleRepository.Add(objSubModule);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = Route.AclRoutesName.AclSubmoduleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclSubModuleRepository.FindById(id);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return await _unitOfWork.AclSubModuleRepository.Edit(id, objSubModule);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclSubModuleRepository.DeleteById(id);
        }




    }
}
