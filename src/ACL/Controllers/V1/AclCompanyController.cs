using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ACL.Controllers.V1
{
    [Tags("Company")]
    [ApiController]
    public class AclCompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer _localizer;

        public AclCompanyController(IUnitOfWork unitOfWork,IStringLocalizer<AclCompanyController> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.List, Name = AclRoutesName.AclCompanyRouteNames.List)]
        public async Task<ActionResult> Index()
        {
           return Ok(await _unitOfWork.AclCompanyRepository.GetAll());
        }

        [HttpPost(AclRoutesUrl.AclCompanyRouteUrl.Add, Name = AclRoutesName.AclCompanyRouteNames.Add)]
        public async Task<IActionResult> Create(AclCompanyCreateRequest request)
        {
            return Ok(await _unitOfWork.AclCompanyRepository.AddAclCompany(request));
        }

        [HttpPut(AclRoutesUrl.AclCompanyRouteUrl.Edit, Name = AclRoutesName.AclCompanyRouteNames.Edit)]
        public async Task<IActionResult> Edit(ulong id, AclCompanyEditRequest request)
        {
            return Ok(await _unitOfWork.AclCompanyRepository.EditAclCompany(id, request));
        }
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.View, Name = AclRoutesName.AclCompanyRouteNames.View)]
        public async Task<IActionResult> View(ulong id)
        {
            return Ok(await _unitOfWork.AclCompanyRepository.FindById(id));
        }

        [HttpDelete(AclRoutesUrl.AclCompanyRouteUrl.Destroy, Name = AclRoutesName.AclCompanyRouteNames.Destroy)]
        public async Task<IActionResult> Destroy(ulong id)
        {
            return Ok(await _unitOfWork.AclCompanyRepository.DeleteCompany(id));
        }
    }
}
