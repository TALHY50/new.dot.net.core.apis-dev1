
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Role")]
    [ApiController]
    public class AclRoleController : ControllerBase
    {
        private readonly IAclRoleRepository _repository;
        public AclRoleController(IAclRoleRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclRoleRouteUrl.List, Name = Route.AclRoutesName.AclRoleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _repository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclRoleRouteUrl.Add, Name = Route.AclRoutesName.AclRoleRouteNames.Add)]
        public async Task<AclResponse> Create(AclRoleRequest objRole)
        {
            return await _repository.Add(objRole);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclRoleRouteUrl.View, Name = Route.AclRoutesName.AclRoleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _repository.FindById(id);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclRoleRouteUrl.Edit, Name = Route.AclRoutesName.AclRoleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclRoleRequest objRole)
        {
            return await _repository.Edit(id, objRole);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclRoleRouteUrl.Destroy, Name = Route.AclRoutesName.AclRoleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _repository.DeleteById(id);
        }

    }
}
