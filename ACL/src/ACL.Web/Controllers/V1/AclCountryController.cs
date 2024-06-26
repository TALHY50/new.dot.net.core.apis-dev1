using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Repositories.Company;
using ACL.Application.Ports.Services.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Country")]
    [ApiController]
    public class AclCountryController : ControllerBase
    {
        private IAclCountryService AclCountryService;
         /// <inheritdoc/>
        public AclCountryController(IAclCountryService repository)
        {
            AclCountryService = repository;
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.List, Name = AclRoutesName.AclCountryRouteNames.List)]
        public AclResponse Index()
        {
            return AclCountryService.GetAll();
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCountryRouteUrl.Add, Name = AclRoutesName.AclCountryRouteNames.Add)]
        public AclResponse Create(AclCountryRequest request)
        {
            return AclCountryService.Add(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.View, Name = AclRoutesName.AclCountryRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return AclCountryService.FindById(id);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCountryRouteUrl.Edit, Name = AclRoutesName.AclCountryRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclCountryRequest request)
        {
            return AclCountryService.Edit(id, request);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCountryRouteUrl.Destroy, Name = AclRoutesName.AclCountryRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return AclCountryService.DeleteById(id);
        }

    }
}
