using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.Web.Application.Features
{
    /// <inheritdoc/>
    [Tags("User")]
    [ApiController]
    public class AclUserController : ControllerBase
    {
        private readonly IUserService _userService;
        /// <inheritdoc/>
        public AclUserController(IUserService userService)
        {
            this._userService = userService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.List, Name = AclRoutesName.AclUserRouteNames.List)]
        public ScopeResponse Index()
        {
            return this._userService.GetAll();
        }
        /// <inheritdoc/>
       // [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserRouteUrl.Add, Name = AclRoutesName.AclUserRouteNames.Add)]
        public async Task<ScopeResponse> Create(AclUserRequest request)
        {
            return await this._userService.AddUser(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserRouteUrl.Edit, Name = AclRoutesName.AclUserRouteNames.Edit)]
        public async Task<ScopeResponse> Edit(ulong id, AclUserRequest request)
        {
            return await this._userService.Edit(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserRouteUrl.Destroy, Name = AclRoutesName.AclUserRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return this._userService.DeleteById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserRouteUrl.View, Name = AclRoutesName.AclUserRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return this._userService.FindById(id);

        }
    }
}
