using ACL.Application.Interfaces;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACL.Route;
using Microsoft.AspNetCore.Authorization;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Page")]
    [ApiController]
    public class AclPageController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclPageController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.List, Name = AclRoutesName.AclPageNamesRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclPageRepository.GetAll();
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteUrl.Add, Name = AclRoutesName.AclPageNamesRouteNames.Add)]
        public async Task<AclResponse> Create(AclPageRequest request)
        {
            return await _unitOfWork.AclPageRepository.AddAclPage(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteUrl.Edit, Name = AclRoutesName.AclPageNamesRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclPageRequest request)
        {
            return await _unitOfWork.AclPageRepository.EditAclPage(id, request);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteUrl.Destroy, Name = AclRoutesName.AclPageNamesRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclPageRepository.DeleteById(id);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.View, Name = AclRoutesName.AclPageNamesRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclPageRepository.FindById(id);

        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteRouteUrl.Add, Name = AclRoutesName.AclPageRouteRouteNames.Add)]
        public async Task<AclResponse> AddPageRoute(AclPageRouteRequest request)
        {
            return await _unitOfWork.AclPageRepository.PageRouteCreate(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteRouteUrl.Edit, Name = AclRoutesName.AclPageRouteRouteNames.Edit)]
        public async Task<AclResponse> EditPageRoute(ulong id, AclPageRouteRequest request)
        {
            return await _unitOfWork.AclPageRepository.PageRouteEdit(id, request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteRouteUrl.Destroy, Name = AclRoutesName.AclPageRouteRouteNames.Destroy)]
        public async Task<AclResponse> DeletePageRoute(ulong id)
        {
            return await _unitOfWork.AclPageRepository.PageRouteDelete(id);
        }


    }
}
