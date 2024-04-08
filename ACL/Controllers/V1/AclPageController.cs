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

    [ApiController]
    [Route("api/v1/")]
    public class AclPageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AclPageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclPage.List, Name = AclRoutesName.AclPageNames.List)]
        public async Task<IActionResult> Index()
        {
            return Ok(_unitOfWork.AclPageRepository.GetAll());
        }

        [HttpPost(AclRoutesUrl.AclPage.Add, Name = AclRoutesName.AclPageNames.Add)]
        public async Task<AclResponse> Create(AclPageRequest request)
        {
            return _unitOfWork.AclPageRepository.Add(request);
        }
        [HttpPut(AclRoutesUrl.AclPage.Edit, Name = AclRoutesName.AclPageNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclPageRequest request)
        {
            return _unitOfWork.AclPageRepository.Edit(id, request);

        }

        [HttpDelete(AclRoutesUrl.AclPage.Destroy, Name = AclRoutesName.AclPageNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _unitOfWork.AclPageRepository.deleteById(id);
        }

        [HttpGet(AclRoutesUrl.AclPage.View, Name = AclRoutesName.AclPageNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return _unitOfWork.AclPageRepository.findById(id);

        }

        [HttpPost(AclRoutesUrl.AclPageRoute.Add, Name = AclRoutesName.AclPageRouteNames.Add)]
        public async Task<AclResponse> AddPageRoute(AclPageRouteRequest request)
        {
            return _unitOfWork.AclPageRepository.PageRouteCreate(request);
        }

        [HttpPut(AclRoutesUrl.AclPageRoute.Edit, Name = AclRoutesName.AclPageRouteNames.Edit)]
        public async Task<AclResponse> EditPageRoute(ulong id, AclPageRouteRequest request)
        {
            return _unitOfWork.AclPageRepository.PageRouteEdit(id, request);
        }

        [HttpDelete(AclRoutesUrl.AclPageRoute.Destroy, Name = AclRoutesName.AclPageRouteNames.Destroy)]
        public async Task<AclResponse> DeletePageRoute(ulong id)
        {
            return _unitOfWork.AclPageRepository.PageRouteDelete(id);
        }


    }
}
