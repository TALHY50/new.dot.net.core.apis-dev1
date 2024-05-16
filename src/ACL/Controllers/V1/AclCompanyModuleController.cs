using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
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

      private IAclCompanyModuleRepository AclCompanyModuleRepository;
        public AclCompanyModuleController(IAclCompanyModuleRepository aclCompanyModuleRepository)
        {
            AclCompanyModuleRepository = aclCompanyModuleRepository;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Name = AclRoutesName.AclCompanyModuleRouteNames.List)]
        public Task<AclResponse> Index()
        {
            return  AclCompanyModuleRepository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public Task<AclResponse> Create(AclCompanyModuleRequest request)
        {
            return AclCompanyModuleRepository.AddAclCompanyModule(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyModuleRouteUrl.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public Task<AclResponse> Edit(ulong id, AclCompanyModuleRequest request)
        {
            return AclCompanyModuleRepository.EditAclCompanyModule(id, request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public Task<AclResponse> View(ulong id)
        {
            return AclCompanyModuleRepository.FindById(id);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public Task<AclResponse> Destroy(ulong id)
        {
            return AclCompanyModuleRepository.DeleteCompanyModule(id);
        }
    }
}
