using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Route;
using ACL.UseCases.Interfaces.Repositories.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Role")]
    [ApiController]
    public class AclRoleController : ControllerBase
    {
        private readonly IAclRoleRepository _repository;
         /// <inheritdoc/>
        public AclRoleController(IAclRoleRepository repository)
        {
            _repository = repository;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.List, Name = AclRoutesName.AclRoleRouteNames.List)]
        public AclResponse Index()
        {
            return _repository.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclRoleRouteUrl.Add, Name = AclRoutesName.AclRoleRouteNames.Add)]
        public AclResponse Create(AclRoleRequest objRole)
        {
            return _repository.Add(objRole);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.View, Name = AclRoutesName.AclRoleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return  _repository.FindById(id);

        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRoleRouteUrl.Edit, Name = AclRoutesName.AclRoleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclRoleRequest objRole)
        {
            return  _repository.Edit(id, objRole);

        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclRoleRouteUrl.Destroy, Name = AclRoutesName.AclRoleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return _repository.DeleteById(id);
        }

    }
}
