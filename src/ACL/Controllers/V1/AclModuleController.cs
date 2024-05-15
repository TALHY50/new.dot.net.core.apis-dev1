using ACL.Application.Interfaces;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Route;
using Craftgate.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Module")]
    [ApiController]
    public class AclModuleController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;

        public AclModuleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.List, Name = AclRoutesName.AclModuleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclModuleRepository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclModuleRouteUrl.Add, Name = AclRoutesName.AclModuleRouteNames.Add)]
        public async Task<AclResponse> Create(AclModuleRequest moduleRequest)
        {
            return await _unitOfWork.AclModuleRepository.AddAclModule(moduleRequest);
        }

         [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclModuleRouteUrl.Edit, Name = AclRoutesName.AclModuleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclModuleRequest moduleRequest)
        {
            return await _unitOfWork.AclModuleRepository.EditAclModule(id, moduleRequest);
        }

         [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.View, Name = AclRoutesName.AclModuleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclModuleRepository.FindById(id);
        }

         [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclModuleRouteUrl.Destroy, Name = AclRoutesName.AclModuleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclModuleRepository.DeleteModule(id);
        }
    }
}
