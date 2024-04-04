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
    public class AclModuleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclModuleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route(AclRoutesUrl.AclModule.List)]
        public async Task<AclResponse> Index()
        {
            return _unitOfWork.AclModuleRepository.GetAll();
        }

        [HttpPost]
        [Route(AclRoutesUrl.AclModule.Add)]
        public async Task<AclResponse> Create(AclModuleRequest moduleRequest)
        {
            return _unitOfWork.AclModuleRepository.AddAclModule(moduleRequest);
        }

        [HttpPut]
        [Route(AclRoutesUrl.AclModule.Edit)]
        public async Task<AclResponse> Edit(ulong Id, AclModuleRequest moduleRequest)
        {
            return _unitOfWork.AclModuleRepository.EditAclModule(Id, moduleRequest);
        }
        [HttpGet]
        [Route(AclRoutesUrl.AclModule.View)]
        public async Task<AclResponse> View(ulong Id)
        {
            return _unitOfWork.AclModuleRepository.FindById(Id);
        }

        [HttpDelete]
        [Route(AclRoutesUrl.AclModule.Destroy)]
        public async Task<AclResponse> Destroy(ulong Id)
        {
            return _unitOfWork.AclModuleRepository.DeleteModule(Id);
        }
    }
}
