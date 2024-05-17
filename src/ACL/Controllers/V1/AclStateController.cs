
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("State")]
    [ApiController]
    public class AclStateController : ControllerBase
    {
        private readonly IAclStateRepository _repository;
        /// <inheritdoc/>
        public AclStateController(IAclStateRepository repository)
        {
            _repository = repository;
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclStateRouteUrl.List, Name = Route.AclRoutesName.AclStateRouteNames.List)]
        public AclResponse Index()
        {
            return  _repository.GetAll();
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclStateRouteUrl.Add, Name = Route.AclRoutesName.AclStateRouteNames.Add)]
        public AclResponse Create(AclStateRequest objState)
        {
            return _repository.Add(objState);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclStateRouteUrl.View, Name = Route.AclRoutesName.AclStateRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return _repository.FindById(id);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclStateRouteUrl.Edit, Name = Route.AclRoutesName.AclStateRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclStateRequest objState)
        {
            return _repository.Edit(id, objState);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclStateRouteUrl.Destroy, Name = Route.AclRoutesName.AclStateRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return _repository.DeleteById(id);
        }




    }
}
