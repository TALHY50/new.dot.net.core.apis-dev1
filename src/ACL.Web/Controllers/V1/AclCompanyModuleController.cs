using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Company Module")]
    [ApiController]
    public class AclCompanyModuleController : ControllerBase
    {

      private readonly IAclCompanyModuleRepository AclCompanyModuleRepository;
        /// <inheritdoc/>
        public AclCompanyModuleController(IAclCompanyModuleRepository _AclCompanyModuleRepository)
        {
            this.AclCompanyModuleRepository = _AclCompanyModuleRepository;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Name = AclRoutesName.AclCompanyModuleRouteNames.List)]
        public Task<AclResponse> Index()
        {
            return  this.AclCompanyModuleRepository.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Name = AclRoutesName.AclCompanyModuleRouteNames.Add)]
        public Task<AclResponse> Create(AclCompanyModuleRequest request)
        {
            return this.AclCompanyModuleRepository.AddAclCompanyModule(request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyModuleRouteUrl.Edit, Name = AclRoutesName.AclCompanyModuleRouteNames.Edit)]
        public Task<AclResponse> Edit(ulong id, AclCompanyModuleRequest request)
        {
            return this.AclCompanyModuleRepository.EditAclCompanyModule(id, request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyModuleRouteUrl.View, Name = AclRoutesName.AclCompanyModuleRouteNames.View)]
        public Task<AclResponse> View(ulong id)
        {
            return this.AclCompanyModuleRepository.FindById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyModuleRouteUrl.Destroy, Name = AclRoutesName.AclCompanyModuleRouteNames.Destroy)]
        public Task<AclResponse> Destroy(ulong id)
        {
            return this.AclCompanyModuleRepository.DeleteCompanyModule(id);
        }
    }
}
