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
    [Route("api/v1/company/")]
    public class AclCompanyModuleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclCompanyModuleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route(AclRoutes.CompanyModules)]
        public async Task<AclResponse> Index()
        {
            return _unitOfWork.AclCompanyModuleRepository.GetAll();
        }

        [HttpPost]
        [Route(AclRoutes.AddCompanyModules)]
        public async Task<AclResponse> Create(AclCompanyModuleRequest objSubModule)
        {
            return _unitOfWork.AclCompanyModuleRepository.AddAclCompanyModule(objSubModule);
        }

        [HttpPut]
        [Route(AclRoutes.EditCompanyModules)]
        public async Task<AclResponse> Edit(ulong Id, AclCompanyModuleRequest objSubModule)
        {
            return _unitOfWork.AclCompanyModuleRepository.EditAclCompanyModule(Id, objSubModule);
        }
        [HttpGet]
        [Route(AclRoutes.ViewCompanyModules)]
        public async Task<AclResponse> View(ulong Id)
        {
            return _unitOfWork.AclCompanyModuleRepository.FindById(Id);
        }

        [HttpDelete]
        [Route(AclRoutes.DeleteCompanyModules)]
        public async Task<AclResponse> Destroy(ulong Id)
        {
            return _unitOfWork.AclCompanyModuleRepository.DeleteModule(Id);
        }
    }
}
