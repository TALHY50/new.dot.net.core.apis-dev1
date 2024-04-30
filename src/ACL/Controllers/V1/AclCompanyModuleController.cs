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
        private readonly ICustomUnitOfWork _unitOfWork;

        public AclCompanyModuleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Name = AclRoutesName.AclCompanyModuleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclCompanyModuleRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public async Task<AclResponse> Create(AclCompanyModuleRequest request)
        {
            return await _unitOfWork.AclCompanyModuleRepository.AddAclCompanyModule(request);
        }

        [HttpPut(AclRoutesUrl.AclCompanyModuleRouteUrl.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclCompanyModuleRequest request)
        {
            return await _unitOfWork.AclCompanyModuleRepository.EditAclCompanyModule(id, request);
        }
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.FindById(id);
        }

        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.DeleteCompanyModule(id);
        }
    }
}
