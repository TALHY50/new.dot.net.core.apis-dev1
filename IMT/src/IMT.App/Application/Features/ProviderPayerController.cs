using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("Provider")]
    [Route("[controller]")]
    public class ProviderPayerController : BaseController
    {
        private readonly IImtProviderPayerService _provider_payer;
        public ProviderPayerController(IImtProviderPayerService provider_payer)
        {
            _provider_payer = provider_payer;
        }
        [Tags("Thunes.Provider")]
        [HttpPost("Create")]
        public ProviderPayer PostProviderPayer(ProviderPayerRequest request)
        {
            return _provider_payer.CreateProviderPayer(request);
        }
        [Tags("Thunes.Provider")]
        [HttpGet("GetAll")]
        public List<ProviderPayer> ProviderPayerList()
        {
            return _provider_payer.GetAllProviderPayer();
        }
        [Tags("Thunes.Provider")]
        [HttpGet("Get/{Id}")]
        public ProviderPayer ProviderPayerById(ulong Id)
        {
            return _provider_payer.GetProviderPayerById(Id);
        }
        [Tags("Thunes.Provider")]
        [HttpPut("Update/{Id}")]
        public ProviderPayer UpdateProviderPayer(ulong Id, ProviderPayerRequest request)
        {
            return _provider_payer.UpdateProviderPayerById(Id, request);
        }

        [Tags("Thunes.Provider")]
        [HttpDelete("Delete/{Id}")]
        public Task<bool> DeleteById(ulong Id)
        {
            return _provider_payer.DeleteProviderPayerById(Id);
        }

    }
}
