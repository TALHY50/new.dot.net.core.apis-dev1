
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("State")]
    [ApiController]
    public class AclStateController : ControllerBase
    {
        private readonly IAclStateRepository _repository;
        public AclStateController(IAclStateRepository repository)
        {
            _repository = repository;
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclStateRouteUrl.List, Name = Route.AclRoutesName.AclStateRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _repository.GetAll();
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclStateRouteUrl.Add, Name = Route.AclRoutesName.AclStateRouteNames.Add)]
        public async Task<AclResponse> Create(AclStateRequest objState)
        {
            return await _repository.Add(objState);
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclStateRouteUrl.View, Name = Route.AclRoutesName.AclStateRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _repository.FindById(id);

        }

        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclStateRouteUrl.Edit, Name = Route.AclRoutesName.AclStateRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclStateRequest objState)
        {
            return await _repository.Edit(id, objState);

        }

        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclStateRouteUrl.Destroy, Name = Route.AclRoutesName.AclStateRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _repository.DeleteById(id);
        }




    }
}
