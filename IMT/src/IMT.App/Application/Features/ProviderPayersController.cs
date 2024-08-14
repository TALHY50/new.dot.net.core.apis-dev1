using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("Provider.Payers")]
    [Route("[controller]")]
    public class ProviderPayerController : BaseController
    {
        private readonly IImtProviderPayersService _providerPayersService;

        public ProviderPayerController(IImtProviderPayersService ProviderPayersService)
        {
            _providerPayersService = ProviderPayersService;
        }

        [Tags("IMT.Provider.Payers")]
        [HttpPost("create")]
        public ProviderPayer Add(ProviderPayerRequest request)
        {
            return _providerPayersService.AddProviderPayer(request);
        }

        [Tags("IMT.Provider.Payers")]
        [HttpPut("update/{id}")]
        public ProviderPayer Update(ulong id, ProviderPayerRequest request)
        {
            return _providerPayersService.UpdateProviderPayer(id, request);
        }

        [Tags("IMT.Provider.Payers")]
        [HttpGet("view/{id}")]
        public ProviderPayer View(ulong id)
        {
            return _providerPayersService.GetProviderPayer(id);
        }

        [Tags("IMT.Provider.Payers")]
        [HttpDelete("delete/{id}")]
        public Task<bool> Delete(ulong id)
        {
            return _providerPayersService.DeleteByIdPayer(id);
        }

        [Tags("IMT.Provider.Payers")]
        [HttpGet("getall")]
        public List<ProviderPayer> GetAll()
        {
            return _providerPayersService.GetAllProviderPayer();
        }
    }
}
