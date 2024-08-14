using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("Provider.Prayers")]
    [Route("[controller]")]
    public class ProviderPrayersController : BaseController
    {
        private readonly IImtProviderPrayersService _providerPrayersService;

        public ProviderPrayersController(IImtProviderPrayersService providerPrayersService)
        {
            _providerPrayersService = providerPrayersService;
        }

        [Tags("IMT.Provider.Prayers")]
        [HttpPost("create")]
        public ProviderPayer Add(ProviderPrayerRequest request)
        {
            return _providerPrayersService.AddProviderPrayer(request);
        }

        [Tags("IMT.Provider.Prayers")]
        [HttpPut("update/{id}")]
        public ProviderPayer Update(ulong id, ProviderPrayerRequest request)
        {
            return _providerPrayersService.UpdateProviderPrayer(id, request);
        }

        [Tags("IMT.Provider.Prayers")]
        [HttpGet("view/{id}")]
        public ProviderPayer View(ulong id)
        {
            return _providerPrayersService.GetProviderPrayer(id);
        }

        [Tags("IMT.Provider.Prayers")]
        [HttpDelete("delete/{id}")]
        public Task<bool> Delete(ulong id)
        {
            return _providerPrayersService.DeleteByIdPrayer(id);
        }

        [Tags("IMT.Provider.Prayers")]
        [HttpGet("getall")]
        public List<ProviderPayer> GetAll()
        {
            return _providerPrayersService.GetAllProviderPrayer();
        }
    }
}
