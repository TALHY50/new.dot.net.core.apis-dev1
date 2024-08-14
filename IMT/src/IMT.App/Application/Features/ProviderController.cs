using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("Provider")]
    [Route("[controller]")]
    public class ProviderController : BaseController
    {
        private readonly IImtProviderService _provider;
        public ProviderController(IImtProviderService provider)
        {
            _provider = provider;
        }
        [Tags("Thunes.Provider")]
        [HttpPost("Create")]
        public Provider PostProvider(ProviderRequest request)
        {
            return _provider.CreateProvider(request);
        }
        [Tags("Thunes.Provider")]
        [HttpGet("GetAll")]
        public List<Provider> ProviderList()
        {
            return _provider.GetAllProvider();
        }
        [Tags("Thunes.Provider")]
        [HttpGet("Get/{Id}")]
        public Provider ProviderById(ulong Id)
        {
            return _provider.GetProviderById(Id);
        }
        [Tags("Thunes.Provider")]
        [HttpPut("Update/{Id}")]
        public Provider UpdateProvider(ulong Id, ProviderRequest request)
        {
            return _provider.UpdateProviderById(Id, request);
        }

        [Tags("Thunes.Provider")]
        [HttpDelete("Delete/{Id}")]
        public Task<bool> DeleteById(ulong Id)
        {
            return _provider.DeleteProviderById(Id);
        }
    }
}
