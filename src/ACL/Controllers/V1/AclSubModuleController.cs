using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.UseCases.Interfaces.Repositories.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Sub Module")]
    [ApiController]
    public class AclSubModuleController : ControllerBase
    {
        private readonly IAclSubModuleRepository _repository;
        /// <inheritdoc/>
        public AclSubModuleController(IAclSubModuleRepository repository)
        {
            _repository = repository;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.List, Name = Route.AclRoutesName.AclSubmoduleRouteNames.List)]
        public AclResponse Index()
        {
            return _repository.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Add, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Add)]
        public AclResponse Create(AclSubModuleRequest objSubModule)
        {
            return _repository.Add(objSubModule);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclSubmoduleRouteUrl.View, Name = Route.AclRoutesName.AclSubmoduleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return _repository.FindById(id);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Edit, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return _repository.Edit(id, objSubModule);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclSubmoduleRouteUrl.Destroy, Name = Route.AclRoutesName.AclSubmoduleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return _repository.DeleteById(id);
        }
    }
}
