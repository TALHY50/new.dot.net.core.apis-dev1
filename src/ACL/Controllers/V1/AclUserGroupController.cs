using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("User Group")]
    [ApiController]
    public class AclUserGroupController : Controller
    {
        private readonly IAclUserGroupRepository _repository;

        public AclUserGroupController(IAclUserGroupRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.List, Name = AclRoutesName.AclUserGroupRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _repository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRouteUrl.Add, Name = AclRoutesName.AclUserGroupRouteNames.Add)]
        public async Task<AclResponse> Create(AclUserGroupRequest request)
        {
            return await _repository.AddUserGroup(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserGroupRouteUrl.Edit, Name = AclRoutesName.AclUserGroupRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserGroupRequest request)
        {
            return await _repository.UpdateUserGroup(id, request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.View, Name = AclRoutesName.AclUserGroupRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _repository.FindById(id);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserGroupRouteUrl.Destroy, Name = AclRoutesName.AclUserGroupRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _repository.Delete(id);
        }
    }
}
