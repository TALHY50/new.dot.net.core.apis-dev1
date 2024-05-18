using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.UseCases.Interfaces.Repositories.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
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
            AclCountryRepository = repository;
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclCountryRouteUrl.List, Name = Route.AclRoutesName.AclCountryRouteNames.List)]
        public AclResponse Index()
        {
            return AclCountryRepository.GetAll();
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclCountryRouteUrl.Add, Name = Route.AclRoutesName.AclCountryRouteNames.Add)]
        public AclResponse Create(AclCountryRequest request)
        {
            return AclCountryRepository.Add(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclCountryRouteUrl.View, Name = Route.AclRoutesName.AclCountryRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return AclCountryRepository.FindById(id);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclCountryRouteUrl.Edit, Name = Route.AclRoutesName.AclCountryRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclCountryRequest request)
        {
            return AclCountryRepository.Edit(id, request);

        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclCountryRouteUrl.Destroy, Name = Route.AclRoutesName.AclCountryRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return AclCountryRepository.DeleteById(id);
        }

    }
}
