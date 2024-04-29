
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

        [HttpGet(Route.AclRoutesUrl.AclCountry.List, Name = Route.AclRoutesName.AclCountryNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _customUnitOfWork.AclCountryRepository.GetAll();
        }

        [HttpPost(Route.AclRoutesUrl.AclCountry.Add, Name = Route.AclRoutesName.AclCountryNames.Add)]
        public async Task<AclResponse> Create(AclCountryRequest request)
        {
            return await _customUnitOfWork.AclCountryRepository.Add(request);
        }

        [HttpGet(Route.AclRoutesUrl.AclCountry.View, Name = Route.AclRoutesName.AclCountryNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _customUnitOfWork.AclCountryRepository.FindById(id);

        }

        [HttpPut(Route.AclRoutesUrl.AclCountry.Edit, Name = Route.AclRoutesName.AclCountryNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclCountryRequest request)
        {
            return await _customUnitOfWork.AclCountryRepository.Edit(id, request);

        }

        [HttpDelete(Route.AclRoutesUrl.AclCountry.Destroy, Name = Route.AclRoutesName.AclCountryNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _customUnitOfWork.AclCountryRepository.DeleteById(id);
        }

    }
}
