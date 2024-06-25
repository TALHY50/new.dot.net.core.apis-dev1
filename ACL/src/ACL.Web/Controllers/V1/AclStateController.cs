using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Repositories.Company;
using ACL.Application.Ports.Services.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
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
