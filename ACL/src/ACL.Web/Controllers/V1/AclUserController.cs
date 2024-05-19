using ACL.Application.Ports.Repositories;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User")]
    [ApiController]
    public class AclUserController : ControllerBase
    {
        private readonly IAclUserRepository _repository;
        /// <inheritdoc/>
        public AclUserController(IAclUserRepository repository)
        {
            this._repository = repository;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.List, Name = AclRoutesName.AclUserRouteNames.List)]
        public AclResponse Index()
        {
            return this._repository.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserRouteUrl.Add, Name = AclRoutesName.AclUserRouteNames.Add)]
        public async Task<AclResponse> Create(AclUserRequest request)
        {
            return await this._repository.AddUser(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserRouteUrl.Edit, Name = AclRoutesName.AclUserRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            return await this._repository.Edit(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserRouteUrl.Destroy, Name = AclRoutesName.AclUserRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this._repository.DeleteById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.View, Name = AclRoutesName.AclUserRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this._repository.FindById(id);

        }
    }
}
