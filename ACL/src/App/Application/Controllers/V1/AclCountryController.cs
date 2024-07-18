using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Services.Company;
using App.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Application.Controllers.V1
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
            this.AclCountryService = repository;
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.List, Name = AclRoutesName.AclCountryRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclCountryService.GetAll();
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCountryRouteUrl.Add, Name = AclRoutesName.AclCountryRouteNames.Add)]
        public AclResponse Create(AclCountryRequest request)
        {
            return this.AclCountryService.Add(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.View, Name = AclRoutesName.AclCountryRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclCountryService.FindById(id);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCountryRouteUrl.Edit, Name = AclRoutesName.AclCountryRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclCountryRequest request)
        {
            return this.AclCountryService.Edit(id, request);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCountryRouteUrl.Destroy, Name = AclRoutesName.AclCountryRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclCountryService.DeleteById(id);
        }

    }
}
