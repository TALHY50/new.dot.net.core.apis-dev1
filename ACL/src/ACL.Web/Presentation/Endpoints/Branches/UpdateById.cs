using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Presentation.Endpoints.Branches;

public class UpdateById : BranchBase
{
    public UpdateById(IBranchService branchService) : base(branchService)
    {
    }
    
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(AclRoutesUrl.AclBranchRouteUrl.Edit, Name = AclRoutesName.AclBranchRouteNames.Edit)]
    public ApplicationResponse Edit(uint id, AclBranchRequest request)
    {
        return this._branchService.Edit(id, request);
    }
}