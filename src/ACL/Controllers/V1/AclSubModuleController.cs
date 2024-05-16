
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Sub Module")]
    [ApiController]
    public class AclSubModuleController : ControllerBase
    {
        private readonly IAclSubModuleRepository _repository;
        public AclSubModuleController(IAclSubModuleRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = Route.AclRoutesName.AclSubmoduleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _repository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Add)]
        public async Task<AclResponse> Create(AclSubModuleRequest objSubModule)
        {
            return await _repository.Add(objSubModule);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = Route.AclRoutesName.AclSubmoduleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _repository.FindById(id);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return await _repository.Edit(id, objSubModule);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _repository.DeleteById(id);
        }




    }
}
