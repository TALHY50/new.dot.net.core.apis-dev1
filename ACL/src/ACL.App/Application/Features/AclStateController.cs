using ACL.App.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Services.Company;

namespace ACL.App.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("State")]
    [ApiController]
    public class AclStateController : ControllerBase
    {
        private readonly IAclStateService AclStateService;
        /// <inheritdoc/>
        public AclStateController(IAclStateService aclStateService)
        {
            this.AclStateService = aclStateService;
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclStateRouteUrl.List, Name = AclRoutesName.AclStateRouteNames.List)]
        public AclResponse Index()
        {
            return  this.AclStateService.GetAll();
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclStateRouteUrl.Add, Name = AclRoutesName.AclStateRouteNames.Add)]
        public AclResponse Create(AclStateRequest objState)
        {
            return this.AclStateService.Add(objState);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclStateRouteUrl.View, Name = AclRoutesName.AclStateRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclStateService.FindById(id);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclStateRouteUrl.Edit, Name = AclRoutesName.AclStateRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclStateRequest objState)
        {
            return this.AclStateService.Edit(id, objState);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclStateRouteUrl.Destroy, Name = AclRoutesName.AclStateRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclStateService.DeleteById(id);
        }




    }
}
