using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Infrastructure.Security;

namespace ACL.Web.Presentation.Endpoints.Branches;

[Authorize]
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