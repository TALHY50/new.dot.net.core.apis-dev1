using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;

public class GetById : BranchBase
{
    public GetById(IBranchService branchService) : base(branchService)
    {
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(AclRoutesUrl.AclBranchRouteUrl.View, Name = AclRoutesName.AclBranchRouteNames.View)]
    public ScopeResponse View(uint id)
    {
        return this._branchService.Find(id);
    }
}