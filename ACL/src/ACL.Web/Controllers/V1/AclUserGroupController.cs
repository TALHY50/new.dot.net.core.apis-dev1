using ACL.Application.Ports.Repositories;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("User Group")]
    [ApiController]
    public class AclUserGroupController : Controller
    {
        private readonly IAclUserGroupRepository _repository;
        /// <inheritdoc/>
        public AclUserGroupController(IAclUserGroupRepository repository)
        {
            this._repository = repository;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.List, Name = AclRoutesName.AclUserGroupRouteNames.List)]
        public AclResponse Index()
        {
            return this._repository.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclUserGroupRouteUrl.Add, Name = AclRoutesName.AclUserGroupRouteNames.Add)]
        public AclResponse AclResponseCreate(AclUserGroupRequest request)
        {
            return this._repository.AddUserGroup(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclUserGroupRouteUrl.Edit, Name = AclRoutesName.AclUserGroupRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclUserGroupRequest request)
        {
            return this._repository.UpdateUserGroup(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclUserGroupRouteUrl.View, Name = AclRoutesName.AclUserGroupRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return  this._repository.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclUserGroupRouteUrl.Destroy, Name = AclRoutesName.AclUserGroupRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this._repository.Delete(id);
        }
    }
}
