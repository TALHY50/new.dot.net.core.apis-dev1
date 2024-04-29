
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Country")]
    [ApiController]
    public class AclCountryController : ControllerBase
    {
        private readonly ICustomUnitOfWork _customUnitOfWork;
        public AclCountryController(ICustomUnitOfWork repository)
        {
            _customUnitOfWork = repository;
        }

        [HttpGet(Route.AclRoutesUrl.AclCountryRouteUrl.List, Name = Route.AclRoutesName.AclCountryRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _customUnitOfWork.AclCountryRepository.GetAll();
        }

        [HttpPost(Route.AclRoutesUrl.AclCountryRouteUrl.Add, Name = Route.AclRoutesName.AclCountryRouteNames.Add)]
        public async Task<AclResponse> Create(AclCountryRequest request)
        {
            return await _customUnitOfWork.AclCountryRepository.Add(request);
        }

        [HttpGet(Route.AclRoutesUrl.AclCountryRouteUrl.View, Name = Route.AclRoutesName.AclCountryRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _customUnitOfWork.AclCountryRepository.FindById(id);

        }

        [HttpPut(Route.AclRoutesUrl.AclCountryRouteUrl.Edit, Name = Route.AclRoutesName.AclCountryRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclCountryRequest request)
        {
            return await _customUnitOfWork.AclCountryRepository.Edit(id, request);

        }

        [HttpDelete(Route.AclRoutesUrl.AclCountryRouteUrl.Destroy, Name = Route.AclRoutesName.AclCountryRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _customUnitOfWork.AclCountryRepository.DeleteById(id);
        }

    }
}
