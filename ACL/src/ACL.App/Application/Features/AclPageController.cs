using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.Web.Application.Features
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Page")]
    [ApiController]
    public class AclPageController : ControllerBase
    {
        private readonly IPageService _pageService;
        /// <inheritdoc/>
        public AclPageController(IPageService pageService)
        {
            _pageService = pageService;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.List, Name = AclRoutesName.AclPageNamesRouteNames.List)]
        public ScopeResponse Index()
        {
            return _pageService.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteUrl.Add, Name = AclRoutesName.AclPageNamesRouteNames.Add)]
        public ScopeResponse Create(AclPageRequest request)
        {
            return _pageService.AddAclPage(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteUrl.Edit, Name = AclRoutesName.AclPageNamesRouteNames.Edit)]
        public ScopeResponse Edit(AclPageRequest request)
        {
            return _pageService.EditAclPage(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteUrl.Destroy, Name = AclRoutesName.AclPageNamesRouteNames.Destroy)]
        public ScopeResponse Destroy(ulong id)
        {
            return _pageService.DeleteById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.View, Name = AclRoutesName.AclPageNamesRouteNames.View)]
        public ScopeResponse View(ulong id)
        {
            return _pageService.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteRouteUrl.Add, Name = AclRoutesName.AclPageRouteRouteNames.Add)]
        public ScopeResponse AddPageRoute(AclPageRouteRequest request)
        {
            return _pageService.PageRouteCreate(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteRouteUrl.Edit, Name = AclRoutesName.AclPageRouteRouteNames.Edit)]
        public ScopeResponse EditPageRoute(ulong id, AclPageRouteRequest request)
        {
            return _pageService.PageRouteEdit(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteRouteUrl.Destroy, Name = AclRoutesName.AclPageRouteRouteNames.Destroy)]
        public ScopeResponse DeletePageRoute(ulong id)
        {
            return _pageService.PageRouteDelete(id);
        }


    }
}
