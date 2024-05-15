using ACL.Application.Interfaces;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Country")]
    [ApiController]
    public class AclCountryController : ControllerBase
    {
        private readonly ICustomUnitOfWork _customUnitOfWork;
        public AclCountryController(ICustomUnitOfWork repository)
        {
            _customUnitOfWork = repository;
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclCountryRouteUrl.List, Name = Route.AclRoutesName.AclCountryRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _customUnitOfWork.AclCountryRepository.GetAll();
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclCountryRouteUrl.Add, Name = Route.AclRoutesName.AclCountryRouteNames.Add)]
        public async Task<AclResponse> Create(AclCountryRequest request)
        {
            return await _customUnitOfWork.AclCountryRepository.Add(request);
        }

        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Route.AclRoutesUrl.AclCountryRouteUrl.View, Name = Route.AclRoutesName.AclCountryRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _customUnitOfWork.AclCountryRepository.FindById(id);

        }

        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Route.AclRoutesUrl.AclCountryRouteUrl.Edit, Name = Route.AclRoutesName.AclCountryRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclCountryRequest request)
        {
            return await _customUnitOfWork.AclCountryRepository.Edit(id, request);

        }

        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Route.AclRoutesUrl.AclCountryRouteUrl.Destroy, Name = Route.AclRoutesName.AclCountryRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _customUnitOfWork.AclCountryRepository.DeleteById(id);
        }

    }
}
