using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Branch")]
    [ApiController]
    public class AclBranchController : Controller
    {
        public readonly ICustomUnitOfWork _unitOfWork;

        public AclBranchController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.List, Name = AclRoutesName.AclBranchRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclBranchService.Get();
        }

        [HttpPost(AclRoutesUrl.AclBranchRouteUrl.Add, Name = AclRoutesName.AclBranchRouteNames.Add)]
        public async Task<AclResponse> Create(AclBranchRequest request)
        {
            return await _unitOfWork.AclBranchService.Add(request);
        }

        [HttpPut(AclRoutesUrl.AclBranchRouteUrl.Edit, Name = AclRoutesName.AclBranchRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclBranchRequest request)
        {
            return await _unitOfWork.AclBranchService.Edit(id, request);
        }
        [HttpGet(AclRoutesUrl.AclBranchRouteUrl.View, Name = AclRoutesName.AclBranchRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclBranchService.Find(id);
        }

        [HttpDelete(AclRoutesUrl.AclBranchRouteUrl.Destroy, Name = AclRoutesName.AclBranchRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclBranchService.Delete(id);
        }
    }
}
