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
    [Tags("Module")]
    [ApiController]
    public class AclModuleController : ControllerBase
    {
        IAclModuleRepository AclModuleRepository;

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.List, Name = AclRoutesName.AclModuleRouteNames.List)]
        public AclResponse Index()
        {
            return AclModuleRepository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclModuleRouteUrl.Add, Name = AclRoutesName.AclModuleRouteNames.Add)]
        public AclResponse Create(AclModuleRequest moduleRequest)
        {
            return AclModuleRepository.AddAclModule(moduleRequest);
        }

         [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclModuleRouteUrl.Edit, Name = AclRoutesName.AclModuleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclModuleRequest moduleRequest)
        {
            return AclModuleRepository.EditAclModule(id, moduleRequest);
        }

         [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.View, Name = AclRoutesName.AclModuleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return AclModuleRepository.FindById(id);
        }

         [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclModuleRouteUrl.Destroy, Name = AclRoutesName.AclModuleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return AclModuleRepository.DeleteModule(id);
        }
    }
}
