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
    [Tags("Country")]
    [ApiController]
    public class AclCountryController : ControllerBase
    {
        private IAclCountryRepository AclCountryRepository;
         /// <inheritdoc/>
        public AclCountryController(IAclCountryRepository repository)
        {
            this.AclCountryRepository = repository;
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.List, Name = AclRoutesName.AclCountryRouteNames.List)]
        public AclResponse Index()
        {
            return this.AclCountryRepository.GetAll();
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCountryRouteUrl.Add, Name = AclRoutesName.AclCountryRouteNames.Add)]
        public AclResponse Create(AclCountryRequest request)
        {
            return this.AclCountryRepository.Add(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.View, Name = AclRoutesName.AclCountryRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclCountryRepository.FindById(id);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCountryRouteUrl.Edit, Name = AclRoutesName.AclCountryRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclCountryRequest request)
        {
            return this.AclCountryRepository.Edit(id, request);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCountryRouteUrl.Destroy, Name = AclRoutesName.AclCountryRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return this.AclCountryRepository.DeleteById(id);
        }

    }
}
