using ACL.Application.Interfaces;
using ACL.Application.Ports.Repositories;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("User")]
    [ApiController]
    public class AclUserController : ControllerBase
    {
        private readonly IAclUserRepository _repository;
        public AclUserController(IAclUserRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.List, Name = AclRoutesName.AclUserRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _repository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserRouteUrl.Add, Name = AclRoutesName.AclUserRouteNames.Add)]
        public async Task<AclResponse> Create(AclUserRequest request)
        {
            return await _repository.AddUser(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserRouteUrl.Edit, Name = AclRoutesName.AclUserRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            return await _repository.Edit(id, request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserRouteUrl.Destroy, Name = AclRoutesName.AclUserRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _repository.DeleteById(id);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.View, Name = AclRoutesName.AclUserRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _repository.FindById(id);

        }

    }
}
