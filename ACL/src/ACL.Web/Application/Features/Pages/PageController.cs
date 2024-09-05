using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.Pages
{
    /// <inheritdoc/>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Tags("Page")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;
        /// <inheritdoc/>
        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.List, Name = AclRoutesName.AclPageNamesRouteNames.List)]
        public ScopeResponse Index()
        {
            return this._pageService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteUrl.Add, Name = AclRoutesName.AclPageNamesRouteNames.Add)]
        public ScopeResponse Create(AclPageRequest request)
        {
            return this._pageService.AddAclPage(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteUrl.Edit, Name = AclRoutesName.AclPageNamesRouteNames.Edit)]
        public ScopeResponse Edit(AclPageRequest request)
        {
            return this._pageService.EditAclPage(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteUrl.Destroy, Name = AclRoutesName.AclPageNamesRouteNames.Destroy)]
        public ScopeResponse Destroy(uint id)
        {
            return this._pageService.DeleteById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.View, Name = AclRoutesName.AclPageNamesRouteNames.View)]
        public ScopeResponse View(uint id)
        {
            return this._pageService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteRouteUrl.Add, Name = AclRoutesName.AclPageRouteRouteNames.Add)]
        public ScopeResponse AddPageRoute(AclPageRouteRequest request)
        {
            return this._pageService.PageRouteCreate(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteRouteUrl.Edit, Name = AclRoutesName.AclPageRouteRouteNames.Edit)]
        public ScopeResponse EditPageRoute(uint id, AclPageRouteRequest request)
        {
            return this._pageService.PageRouteEdit(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteRouteUrl.Destroy, Name = AclRoutesName.AclPageRouteRouteNames.Destroy)]
        public ScopeResponse DeletePageRoute(uint id)
        {
            return this._pageService.PageRouteDelete(id);
        }


    }
}
