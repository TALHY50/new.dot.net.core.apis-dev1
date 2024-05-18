using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Route;
using ACL.UseCases.Interfaces.Repositories.V1;
using Craftgate.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Module")]
    [ApiController]
    public class AclModuleController : ControllerBase
    {
        IAclModuleRepository _repository;
        /// <inheritdoc/>
        public AclModuleController(IAclModuleRepository repository)
        {
            _repository = repository;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.List, Name = AclRoutesName.AclModuleRouteNames.List)]
        public AclResponse Index()
        {
            return _repository.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclModuleRouteUrl.Add, Name = AclRoutesName.AclModuleRouteNames.Add)]
        public AclResponse Create(AclModuleRequest moduleRequest)
        {
            return _repository.AddAclModule(moduleRequest);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclModuleRouteUrl.Edit, Name = AclRoutesName.AclModuleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclModuleRequest moduleRequest)
        {
            return _repository.EditAclModule(id, moduleRequest);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclModuleRouteUrl.View, Name = AclRoutesName.AclModuleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return _repository.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclModuleRouteUrl.Destroy, Name = AclRoutesName.AclModuleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return _repository.DeleteModule(id);
        }
    }
}
