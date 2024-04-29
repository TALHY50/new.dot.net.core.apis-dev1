using ACL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Interfaces.Repositories.V1;
using ACL.Response.V1;
using ACL.Requests;
using ACL.Interfaces;
using ACL.Route;

namespace ACL.Controllers.V1
{

    [Tags("Page")]
    [ApiController]
    public class AclPageController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclPageController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclPageRouteUrl.List, Name = AclRoutesName.AclPageNamesRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclPageRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclPageRouteUrl.Add, Name = AclRoutesName.AclPageNamesRouteNames.Add)]
        public async Task<AclResponse> Create(AclPageRequest request)
        {
            return await _unitOfWork.AclPageRepository.AddAclPage(request);
        }
        [HttpPut(AclRoutesUrl.AclPageRouteUrl.Edit, Name = AclRoutesName.AclPageNamesRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclPageRequest request)
        {
            return await _unitOfWork.AclPageRepository.EditAclPage(id, request);

        }

        [HttpDelete(AclRoutesUrl.AclPageRouteUrl.Destroy, Name = AclRoutesName.AclPageNamesRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclPageRepository.DeleteById(id);
        }

        [HttpGet(AclRoutesUrl.AclPageRouteUrl.View, Name = AclRoutesName.AclPageNamesRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return _unitOfWork.AclPageRepository.FindById(id);

        }

        [HttpPost(AclRoutesUrl.AclPageRouteRouteUrl.Add, Name = AclRoutesName.AclPageRouteRouteNames.Add)]
        public async Task<AclResponse> AddPageRoute(AclPageRouteRequest request)
        {
            return await _unitOfWork.AclPageRepository.PageRouteCreate(request);
        }

        [HttpPut(AclRoutesUrl.AclPageRouteRouteUrl.Edit, Name = AclRoutesName.AclPageRouteRouteNames.Edit)]
        public async Task<AclResponse> EditPageRoute(ulong id, AclPageRouteRequest request)
        {
            return await _unitOfWork.AclPageRepository.PageRouteEdit(id, request);
        }

        [HttpDelete(AclRoutesUrl.AclPageRouteRouteUrl.Destroy, Name = AclRoutesName.AclPageRouteRouteNames.Destroy)]
        public async Task<AclResponse> DeletePageRoute(ulong id)
        {
            return await _unitOfWork.AclPageRepository.PageRouteDelete(id);
        }


    }
}
