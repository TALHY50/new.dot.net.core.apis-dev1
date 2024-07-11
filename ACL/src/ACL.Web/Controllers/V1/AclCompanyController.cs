using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Services.Company;
using Notification.Application.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Company")]
    [ApiController]
    public class AclCompanyController : Controller
    {
        /// <inheritdoc/>
        public  required IAclCompanyService AclCompanyService;
        /// <inheritdoc/>
        public AclCompanyController(IAclCompanyService _AclCompanyService)
        {
            AclCompanyService = _AclCompanyService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.List, Name = AclRoutesName.AclCompanyRouteNames.List)]
        public AclResponse Index()
        {
            return  AclCompanyService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyRouteUrl.Add, Name = AclRoutesName.AclCompanyRouteNames.Add)]
        public Task<AclResponse> Create(AclCompanyCreateRequest request)
        {
            return  AclCompanyService.AddAclCompany(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyRouteUrl.Edit, Name = AclRoutesName.AclCompanyRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclCompanyEditRequest request)
        {
            return  AclCompanyService.EditAclCompany(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.View, Name = AclRoutesName.AclCompanyRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return AclCompanyService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyRouteUrl.Destroy, Name = AclRoutesName.AclCompanyRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return  AclCompanyService.DeleteCompany(id);
        }
    }
}
