using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("ProviderService")]
    [Route("[controller]")]
    public class ProviderServiceController : BaseController
    {
        private readonly IImtProviderServiceService _providerServiceService;
        public ProviderServiceController(IImtProviderServiceService providerServiceService)
        {
            _providerServiceService = providerServiceService;
        }

        [Tags("IMT.Provider.Service")]
        [HttpPost("create")]
        public ProviderService Add(ProviderServiceRequest request)
        {
            return _providerServiceService.AddProviderService(request);
        }

        [Tags("IMT.Provider.Service")]
        [HttpPut("updated/{id}")]
        public ProviderService Update(ulong id, ProviderServiceRequest request)
        {
            return _providerServiceService.UpdateProviderService(id, request);
        }

        [Tags("IMT.Provider.Service")]
        [HttpGet("view/{id}")]
        public ProviderService? View(ulong id)
        {
            return _providerServiceService.GetProviderService(id);
        }

        [Tags("IMT.Provider.Service")]
        [HttpDelete("delete/{id}")]
        public Task<bool> Delete(ulong id)
        {
            return _providerServiceService.DeleteByIdService(id);
        }

        [Tags("IMT.Provider.Service")]
        [HttpGet("getall")]
        public List<ProviderService> GetAll()
        {
            return _providerServiceService.GetAllProviderService();
        }
    }
}
