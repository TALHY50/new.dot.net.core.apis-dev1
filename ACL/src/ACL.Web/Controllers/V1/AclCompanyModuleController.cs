﻿using ACL.Application.Ports.Repositories;
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
    [Tags("Company Module")]
    [ApiController]
    public class AclCompanyModuleController : ControllerBase
    {

      private readonly IAclCompanyModuleService AclCompanyModuleService;
        /// <inheritdoc/>
        public AclCompanyModuleController(IAclCompanyModuleService aclCompanyModuleService)
        {
            this.AclCompanyModuleService = aclCompanyModuleService;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Name = AclRoutesName.AclCompanyModuleRouteNames.List)]
        public AclResponse Index()
        {
            return  this.AclCompanyModuleService.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public AclResponse Create(AclCompanyModuleRequest request)
        {
            return this.AclCompanyModuleService.AddAclCompanyModule(request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyModuleRouteUrl.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclCompanyModuleRequest request)
        {
            return this.AclCompanyModuleService.EditAclCompanyModule(id, request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclCompanyModuleService.FindById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclCompanyModuleService.DeleteCompanyModule(id);
        }
    }
}
