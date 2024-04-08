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
    [ApiController]
    public class AclModuleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclModuleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclModule.List, Name = AclRoutesName.AclModuleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclModuleRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclModule.Add, Name = AclRoutesName.AclModuleRouteNames.Add)]
        public async Task<AclResponse> Create(AclModuleRequest moduleRequest)
        {
            return await _unitOfWork.AclModuleRepository.AddAclModule(moduleRequest);
        }

        [HttpPut(AclRoutesUrl.AclModule.Edit, Name = AclRoutesName.AclModuleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclModuleRequest moduleRequest)
        {
            return await _unitOfWork.AclModuleRepository.EditAclModule(id, moduleRequest);
        }
        [HttpGet(AclRoutesUrl.AclModule.View, Name = AclRoutesName.AclModuleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclModuleRepository.FindById(id);
        }

        [HttpDelete(AclRoutesUrl.AclModule.Destroy, Name = AclRoutesName.AclModuleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclModuleRepository.DeleteModule(id);
        }
    }
}
