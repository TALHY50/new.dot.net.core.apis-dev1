using ACL.Application.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using Craftgate.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Company Module")]
    [ApiController]
    public class AclCompanyModuleController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;

        public AclCompanyModuleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Name = AclRoutesName.AclCompanyModuleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclCompanyModuleRepository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public async Task<AclResponse> Create(AclCompanyModuleRequest request)
        {
            return await _unitOfWork.AclCompanyModuleRepository.AddAclCompanyModule(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyModuleRouteUrl.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclCompanyModuleRequest request)
        {
            return await _unitOfWork.AclCompanyModuleRepository.EditAclCompanyModule(id, request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.FindById(id);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.DeleteCompanyModule(id);
        }
    }
}
