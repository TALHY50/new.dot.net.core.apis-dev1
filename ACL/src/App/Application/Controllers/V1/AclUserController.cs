using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Services.Auth;
using App.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Application.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User")]
    [ApiController]
    public class AclUserController : ControllerBase
    {
        private readonly IAclUserService AclUserService;
        /// <inheritdoc/>
        public AclUserController(IAclUserService _AclUserService)
        {
            this.AclUserService = _AclUserService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.List, Name = AclRoutesName.AclUserRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclUserService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserRouteUrl.Add, Name = AclRoutesName.AclUserRouteNames.Add)]
        public async Task<AclResponse> Create(AclUserRequest request)
        {
            return await this.AclUserService.AddUser(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserRouteUrl.Edit, Name = AclRoutesName.AclUserRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            return await this.AclUserService.Edit(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserRouteUrl.Destroy, Name = AclRoutesName.AclUserRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclUserService.DeleteById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.View, Name = AclRoutesName.AclUserRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclUserService.FindById(id);

        }
    }
}
