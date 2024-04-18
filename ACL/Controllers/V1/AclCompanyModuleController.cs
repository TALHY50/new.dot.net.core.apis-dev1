using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using ACL.Services;
using Craftgate.Response;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Company Module")]
    [ApiController]
    public class AclCompanyModuleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclCompanyModuleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclCompanyModule.List, Name = AclRoutesName.AclCompanyModuleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclCompanyModuleRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclCompanyModule.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public async Task<AclResponse> Create(AclCompanyModuleRequest request)
        {
            return await _unitOfWork.AclCompanyModuleRepository.AddAclCompanyModule(request);
        }

        [HttpPut(AclRoutesUrl.AclCompanyModule.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclCompanyModuleRequest request)
        {
            return await _unitOfWork.AclCompanyModuleRepository.EditAclCompanyModule(id, request);
        }
        [HttpGet(AclRoutesUrl.AclCompanyModule.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.FindById(id);
        }

        [HttpDelete(AclRoutesUrl.AclCompanyModule.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.DeleteCompanyModule(id);
        }
    }
}
