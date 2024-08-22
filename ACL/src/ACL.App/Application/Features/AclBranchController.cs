﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.ACL.Requests;
using SharedKernel.Main.Contracts.ACL.Response;
using SharedKernel.Main.Domain.ACL.Services.Company;

namespace ACL.App.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Branch")]
    [ApiController]
    public class AclBranchController : Controller
    {
        private IAclBranchService AclBranchService;
        /// <inheritdoc/>
        public AclBranchController(IAclBranchService aclBranchService)
        {
            this.AclBranchService = aclBranchService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.List, Name = AclRoutesName.AclBranchRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclBranchService.Get();
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclBranchRouteUrl.Add, Name = AclRoutesName.AclBranchRouteNames.Add)]
        public AclResponse Create(AclBranchRequest request)
        {
            return this.AclBranchService.Add(request);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclBranchRouteUrl.Edit, Name = AclRoutesName.AclBranchRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclBranchRequest request)
        {
            return this.AclBranchService.Edit(id, request);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.View, Name = AclRoutesName.AclBranchRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclBranchService.Find(id);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclBranchRouteUrl.Destroy, Name = AclRoutesName.AclBranchRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclBranchService.Delete(id);
        }
    }
}