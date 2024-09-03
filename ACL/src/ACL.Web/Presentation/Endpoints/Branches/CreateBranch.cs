using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;


public class CreateBranch : BranchBase
{
    public CreateBranch(IBranchService branchService) : base(branchService)
    {
    }
    
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(AclRoutesUrl.AclBranchRouteUrl.Add, Name = AclRoutesName.AclBranchRouteNames.Add)]
    public ScopeResponse Create(AclBranchRequest request)
    {
        return this._branchService.Add(request);
    }
}