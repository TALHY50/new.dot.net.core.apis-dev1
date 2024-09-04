using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.Roles
{
     /// <inheritdoc/>
    //[Authorize]
    //[Tags("Role")]
    //[ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
         /// <inheritdoc/>
        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpGet(AclRoutesUrl.AclRoleRouteUrl.List, Name = AclRoutesName.AclRoleRouteNames.List)]
        //public ScopeResponse Index()
        //{
        //    return this._roleService.GetAll();
        //}
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpPost(AclRoutesUrl.AclRoleRouteUrl.Add, Name = AclRoutesName.AclRoleRouteNames.Add)]
        //public ScopeResponse Create(AclRoleRequest objRole)
        //{
        //    return this._roleService.Add(objRole);
        //}
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpGet(AclRoutesUrl.AclRoleRouteUrl.View, Name = AclRoutesName.AclRoleRouteNames.View)]
        //public ScopeResponse View(uint id)
        //{
        //    return  this._roleService.FindById(id);

        //}
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpPut(AclRoutesUrl.AclRoleRouteUrl.Edit, Name = AclRoutesName.AclRoleRouteNames.Edit)]
        //public ScopeResponse Edit(uint id, AclRoleRequest objRole)
        //{
        //    return  this._roleService.Edit(id, objRole);

        //}
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        //[HttpDelete(AclRoutesUrl.AclRoleRouteUrl.Destroy, Name = AclRoutesName.AclRoleRouteNames.Destroy)]
        //public ScopeResponse Destroy(uint id)
        //{
        //    return this._roleService.DeleteById(id);
        //}

    }
}
