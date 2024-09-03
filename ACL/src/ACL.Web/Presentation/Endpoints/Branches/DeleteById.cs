using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;

public class DeleteById : BranchBase
{
    public DeleteById(IBranchService branchService) : base(branchService)
    {
    }
    
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(AclRoutesUrl.AclBranchRouteUrl.Destroy, Name = AclRoutesName.AclBranchRouteNames.Destroy)]
    public ScopeResponse Destroy(ulong id)
    {
        return this._branchService.Delete(id);
    }
}