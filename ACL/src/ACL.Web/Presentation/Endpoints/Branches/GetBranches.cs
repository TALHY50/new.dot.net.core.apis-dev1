using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;

public class GetBranches : BranchBase
{
    public GetBranches(IBranchService branchService) : base(branchService)
    {
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize(Policy = "HasPermission")]
    [HttpGet(AclRoutesUrl.AclBranchRouteUrl.List, Name = AclRoutesName.AclBranchRouteNames.List)]
    public ScopeResponse Index()
    {
        return this._branchService.Get();
    }
}