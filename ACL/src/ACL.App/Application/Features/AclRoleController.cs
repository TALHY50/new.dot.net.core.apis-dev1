using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.Web.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Role")]
    [ApiController]
    public class AclRoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        /// <inheritdoc/>
        public AclRoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.List, Name = AclRoutesName.AclRoleRouteNames.List)]
        public ScopeResponse Index()
        {
            return _roleService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclRoleRouteUrl.Add, Name = AclRoutesName.AclRoleRouteNames.Add)]
        public ScopeResponse Create(AclRoleRequest objRole)
        {
            return _roleService.Add(objRole);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRoleRouteUrl.View, Name = AclRoutesName.AclRoleRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return _roleService.FindById(id);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRoleRouteUrl.Edit, Name = AclRoutesName.AclRoleRouteNames.Edit)]
        public ScopeResponse Edit(ulong id, AclRoleRequest objRole)
        {
            return _roleService.Edit(id, objRole);

        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclRoleRouteUrl.Destroy, Name = AclRoutesName.AclRoleRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return _roleService.DeleteById(id);
        }

    }
}
