using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.States
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("State")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        /// <inheritdoc/>
        public StateController(IStateService stateService)
        {
            this._stateService = stateService;
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclStateRouteUrl.List, Name = AclRoutesName.AclStateRouteNames.List)]
        public ApplicationResponse Index()
        {
            return  this._stateService.GetAll();
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclStateRouteUrl.Add, Name = AclRoutesName.AclStateRouteNames.Add)]
        public ApplicationResponse Create(AclStateRequest objState)
        {
            return this._stateService.Add(objState);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclStateRouteUrl.View, Name = AclRoutesName.AclStateRouteNames.View)]
        public ApplicationResponse View(uint id)
        {
            return this._stateService.FindById(id);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclStateRouteUrl.Edit, Name = AclRoutesName.AclStateRouteNames.Edit)]
        public ApplicationResponse Edit(uint id, AclStateRequest objState)
        {
            return this._stateService.Edit(id, objState);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclStateRouteUrl.Destroy, Name = AclRoutesName.AclStateRouteNames.Destroy)]
        public ApplicationResponse Destroy(uint id)
        {
            return this._stateService.DeleteById(id);
        }




    }
}
