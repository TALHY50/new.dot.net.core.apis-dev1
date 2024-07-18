using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Services.Module;
using App.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Application.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Page")]
    [ApiController]
    public class AclPageController : ControllerBase
    {
        private readonly IAclPageService AclPageService;
        /// <inheritdoc/>
        public AclPageController(IAclPageService _AclPageService)
        {
            this.AclPageService = _AclPageService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.List, Name = AclRoutesName.AclPageNamesRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclPageService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteUrl.Add, Name = AclRoutesName.AclPageNamesRouteNames.Add)]
        public AclResponse Create(AclPageRequest request)
        {
            return this.AclPageService.AddAclPage(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteUrl.Edit, Name = AclRoutesName.AclPageNamesRouteNames.Edit)]
        public AclResponse Edit(AclPageRequest request)
        {
            return this.AclPageService.EditAclPage(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteUrl.Destroy, Name = AclRoutesName.AclPageNamesRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclPageService.DeleteById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.View, Name = AclRoutesName.AclPageNamesRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclPageService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteRouteUrl.Add, Name = AclRoutesName.AclPageRouteRouteNames.Add)]
        public AclResponse AddPageRoute(AclPageRouteRequest request)
        {
            return this.AclPageService.PageRouteCreate(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteRouteUrl.Edit, Name = AclRoutesName.AclPageRouteRouteNames.Edit)]
        public AclResponse EditPageRoute(ulong id, AclPageRouteRequest request)
        {
            return this.AclPageService.PageRouteEdit(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteRouteUrl.Destroy, Name = AclRoutesName.AclPageRouteRouteNames.Destroy)]
        public AclResponse DeletePageRoute(ulong id)
        {
            return this.AclPageService.PageRouteDelete(id);
        }


    }
}
