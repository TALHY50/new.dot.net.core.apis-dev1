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
        private readonly IUnitOfWork _unitOfWork;
        public AclPageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclPage.List, Name = AclRoutesName.AclPageNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclPageRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclPage.Add, Name = AclRoutesName.AclPageNames.Add)]
        public async Task<AclResponse> Create(AclPageRequest request)
        {
            return await _unitOfWork.AclPageRepository.Add(request);
        }
        [HttpPut(AclRoutesUrl.AclPage.Edit, Name = AclRoutesName.AclPageNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclPageRequest request)
        {
            return await _unitOfWork.AclPageRepository.Edit(id, request);

        }

        [HttpDelete(AclRoutesUrl.AclPage.Destroy, Name = AclRoutesName.AclPageNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclPageRepository.deleteById(id);
        }

        [HttpGet(AclRoutesUrl.AclPage.View, Name = AclRoutesName.AclPageNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclPageRepository.findById(id);

        }

        [HttpPost(AclRoutesUrl.AclPageRoute.Add, Name = AclRoutesName.AclPageRouteNames.Add)]
        public async Task<AclResponse> AddPageRoute(AclPageRouteRequest request)
        {
            return await _unitOfWork.AclPageRepository.PageRouteCreate(request);
        }

        [HttpPut(AclRoutesUrl.AclPageRoute.Edit, Name = AclRoutesName.AclPageRouteNames.Edit)]
        public async Task<AclResponse> EditPageRoute(ulong id, AclPageRouteRequest request)
        {
            return await _unitOfWork.AclPageRepository.PageRouteEdit(id, request);
        }

        [HttpDelete(AclRoutesUrl.AclPageRoute.Destroy, Name = AclRoutesName.AclPageRouteNames.Destroy)]
        public async Task<AclResponse> DeletePageRoute(ulong id)
        {
            return await _unitOfWork.AclPageRepository.PageRouteDelete(id);
        }


    }
}
