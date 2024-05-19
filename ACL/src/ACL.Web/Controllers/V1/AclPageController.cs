using ACL.Application.Ports.Repositories;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Page")]
    [ApiController]
    public class AclPageController : ControllerBase
    {
        private readonly IAclPageRepository _repository;
         /// <inheritdoc/>
        public AclPageController(IAclPageRepository repository)
        {
            this._repository = repository;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.List, Name = AclRoutesName.AclPageNamesRouteNames.List)]
        public AclResponse Index()
        {
            return  this._repository.GetAll();
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteUrl.Add, Name = AclRoutesName.AclPageNamesRouteNames.Add)]
        public AclResponse Create(AclPageRequest request)
        {
            return  this._repository.AddAclPage(request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteUrl.Edit, Name = AclRoutesName.AclPageNamesRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclPageRequest request)
        {
            return  this._repository.EditAclPage(id, request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteUrl.Destroy, Name = AclRoutesName.AclPageNamesRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this._repository.DeleteById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclPageRouteUrl.View, Name = AclRoutesName.AclPageNamesRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this._repository.FindById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPageRouteRouteUrl.Add, Name = AclRoutesName.AclPageRouteRouteNames.Add)]
        public AclResponse AddPageRoute(AclPageRouteRequest request)
        {
            return this._repository.PageRouteCreate(request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclPageRouteRouteUrl.Edit, Name = AclRoutesName.AclPageRouteRouteNames.Edit)]
        public AclResponse EditPageRoute(ulong id, AclPageRouteRequest request)
        {
            return this._repository.PageRouteEdit(id, request);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclPageRouteRouteUrl.Destroy, Name = AclRoutesName.AclPageRouteRouteNames.Destroy)]
        public AclResponse DeletePageRoute(ulong id)
        {
            return this._repository.PageRouteDelete(id);
        }


    }
}
