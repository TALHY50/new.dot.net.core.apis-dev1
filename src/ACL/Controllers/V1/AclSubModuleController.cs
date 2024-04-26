
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
        [HttpGet(Route.AclRoutesUrl.AclSubmodule.List, Name = Route.AclRoutesName.AclSubmodule.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclSubModuleRepository.GetAll();
        }
        [HttpPost(Route.AclRoutesUrl.AclSubmodule.Add, Name = Route.AclRoutesName.AclSubmodule.Add)]
        public async Task<AclResponse> Create(AclSubModuleRequest objSubModule)
        {
            return await _unitOfWork.AclSubModuleRepository.Add(objSubModule);
        }
        [HttpGet(Route.AclRoutesUrl.AclSubmodule.View, Name = Route.AclRoutesName.AclSubmodule.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclSubModuleRepository.FindById(id);

        }
        [HttpPut(Route.AclRoutesUrl.AclSubmodule.Edit, Name = Route.AclRoutesName.AclSubmodule.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return await _unitOfWork.AclSubModuleRepository.Edit(id, objSubModule);

        }
        [HttpDelete(Route.AclRoutesUrl.AclSubmodule.Destroy, Name = Route.AclRoutesName.AclSubmodule.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclSubModuleRepository.DeleteById(id);
        }




    }
}
