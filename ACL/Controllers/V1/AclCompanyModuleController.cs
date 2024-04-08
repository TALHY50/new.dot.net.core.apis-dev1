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
    public class AclCompanyModuleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclCompanyModuleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route(AclRoutesUrl.AclCompanyModule.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclCompanyModuleRepository.GetAll();
        }

        [HttpPost]
        [Route(AclRoutesUrl.AclCompanyModule.Add)]
        public async Task<AclResponse> Create(AclCompanyModuleRequest objSubModule)
        {
            return await _unitOfWork.AclCompanyModuleRepository.AddAclCompanyModule(objSubModule);
        }

        [HttpPut]
        [Route(AclRoutesUrl.AclCompanyModule.Edit)]
        public async Task<AclResponse> Edit(ulong Id, AclCompanyModuleRequest objSubModule)
        {
            return await _unitOfWork.AclCompanyModuleRepository.EditAclCompanyModule(Id, objSubModule);
        }
        [HttpGet]
        [Route(AclRoutesUrl.AclCompanyModule.View)]
        public async Task<AclResponse> View(ulong Id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.FindById(Id);
        }

        [HttpDelete]
        [Route(AclRoutesUrl.AclCompanyModule.Destroy)]
        public async Task<AclResponse> Destroy(ulong Id)
        {
            return await _unitOfWork.AclCompanyModuleRepository.DeleteCompanyModule(Id);
        }
    }
}
