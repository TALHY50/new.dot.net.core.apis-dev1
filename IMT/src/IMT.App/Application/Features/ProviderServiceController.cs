using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;
using Thunes.Exception;
using Thunes.Route;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("Provider")]
    [Route("[controller]")]
    public class ProviderServiceController : BaseController
    {
        private readonly IImtProviderServiceService _provider_service;

        public ProviderServiceController(IImtProviderServiceService provider_service)
        {
            _provider_service = provider_service;
        }

        [Tags("Thunes.ProviderService")]
        [HttpPost("Create")]
        public ProviderService ProviderServicePost(ProviderServiceRequest request)
        {
            return _provider_service.CreateProviderService(request);
        }
        [Tags("Thunes.ProviderService")]
        [HttpPost("GetAll")]
        public List<ProviderService> GetAll()
        {
            return _provider_service.GetAllProviderService();
        }
        [Tags("Thunes.ProviderService")]
        [HttpGet("GetById")]
        public ProviderService Get(ulong Id)
        {
            return _provider_service.ProviderServiceGetById(Id);
        }
        [Tags("Thunes.ProviderService")]
        [HttpPut("Update")]
        public ProviderService Update(ulong Id, ProviderServiceRequest request)
        {
            return _provider_service.UpdateProviderService(Id, request);
        } 
        
        [Tags("Thunes.ProviderService")]
        [HttpDelete("Delete/{Id}")]
        public Task<bool> DeleteById(ulong Id)
        {
            return _provider_service.DeleteProviderService(Id);
        }

    }
}
