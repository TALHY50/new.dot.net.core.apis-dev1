using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Branches;

[Tags("Branch")]
[ApiController]
public class BranchBase : ApiControllerBase
{
    protected IBranchService _branchService;
    
    public BranchBase(IBranchService branchService)
    {
        this._branchService = branchService;
    }
    
}