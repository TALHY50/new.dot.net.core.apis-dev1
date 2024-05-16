using ACL.Application.Interfaces;
using ACL.Application.Interfaces.ServiceInterfaces;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Services;
using ACL.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Branch")]
    [ApiController]
    public class AclBranchController : Controller
    {
        private IAclBranchService AclBranchService;

        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.List, Name = AclRoutesName.AclBranchRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await AclBranchService.Get();
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclBranchRouteUrl.Add, Name = AclRoutesName.AclBranchRouteNames.Add)]
        public async Task<AclResponse> Create(AclBranchRequest request)
        {
            return await AclBranchService.Add(request);
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclBranchRouteUrl.Edit, Name = AclRoutesName.AclBranchRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclBranchRequest request)
        {
            return await AclBranchService.Edit(id, request);
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.View, Name = AclRoutesName.AclBranchRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await AclBranchService.Find(id);
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclBranchRouteUrl.Destroy, Name = AclRoutesName.AclBranchRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await AclBranchService.Delete(id);
        }
    }
}
