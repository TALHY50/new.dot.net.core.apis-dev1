using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.App.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("State")]
    [ApiController]
    public class AclStateController : ControllerBase
    {
        private readonly IStateService _stateService;
        /// <inheritdoc/>
        public AclStateController(IStateService stateService)
        {
            this._stateService = stateService;
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclStateRouteUrl.List, Name = AclRoutesName.AclStateRouteNames.List)]
        public ScopeResponse Index()
        {
            return  this._stateService.GetAll();
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclStateRouteUrl.Add, Name = AclRoutesName.AclStateRouteNames.Add)]
        public ScopeResponse Create(AclStateRequest objState)
        {
            return this._stateService.Add(objState);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclStateRouteUrl.View, Name = AclRoutesName.AclStateRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return this._stateService.FindById(id);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclStateRouteUrl.Edit, Name = AclRoutesName.AclStateRouteNames.Edit)]
        public ScopeResponse Edit(ulong id, AclStateRequest objState)
        {
            return this._stateService.Edit(id, objState);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclStateRouteUrl.Destroy, Name = AclRoutesName.AclStateRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return this._stateService.DeleteById(id);
        }




    }
}
