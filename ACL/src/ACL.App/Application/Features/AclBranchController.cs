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
    [Tags("Branch")]
    [ApiController]
    public class AclBranchController : Controller
    {
        private IBranchService _branchService;
        /// <inheritdoc/>
        public AclBranchController(IBranchService branchService)
        {
            this._branchService = branchService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.List, Name = AclRoutesName.AclBranchRouteNames.List)]
        public ScopeResponse Index()
        {
            return this._branchService.Get();
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclBranchRouteUrl.Add, Name = AclRoutesName.AclBranchRouteNames.Add)]
        public ScopeResponse Create(AclBranchRequest request)
        {
            return this._branchService.Add(request);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclBranchRouteUrl.Edit, Name = AclRoutesName.AclBranchRouteNames.Edit)]
        public ScopeResponse Edit(ulong id, AclBranchRequest request)
        {
            return this._branchService.Edit(id, request);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.View, Name = AclRoutesName.AclBranchRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return this._branchService.Find(id);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclBranchRouteUrl.Destroy, Name = AclRoutesName.AclBranchRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return this._branchService.Delete(id);
        }
    }
}
