using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ACL.Controllers.V1
{
    [Tags("Company")]
    [ApiController]
    public class AclCompanyController : Controller
    {
        public readonly ICustomUnitOfWork _unitOfWork;

        public AclCompanyController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.List, Name = AclRoutesName.AclCompanyRouteNames.List)]
        public async Task<AclResponse> Index()
        {
           // return await _unitOfWork.AclCompanyRepository.GetAll();
            return (AclResponse)await _unitOfWork.AclUserUserGroupRepository.All();
        }

        [HttpPost(AclRoutesUrl.AclCompanyRouteUrl.Add, Name = AclRoutesName.AclCompanyRouteNames.Add)]
        public async Task<AclResponse> Create(AclCompanyCreateRequest request)
        {
            return await _unitOfWork.AclCompanyRepository.AddAclCompany(request);
        }

        [HttpPut(AclRoutesUrl.AclCompanyRouteUrl.Edit, Name = AclRoutesName.AclCompanyRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclCompanyEditRequest request)
        {
            return await _unitOfWork.AclCompanyRepository.EditAclCompany(id, request);
        }
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.View, Name = AclRoutesName.AclCompanyRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclCompanyRepository.FindById(id);
        }

        [HttpDelete(AclRoutesUrl.AclCompanyRouteUrl.Destroy, Name = AclRoutesName.AclCompanyRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclCompanyRepository.DeleteCompany(id);
        }
    }
}
