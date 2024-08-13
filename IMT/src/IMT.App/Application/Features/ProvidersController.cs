using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;
using Thunes.Exception;
using Thunes.Route;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("Providers")]
    [Route("[controller]")]
    public class ProvidersController : BaseController
    {
        private readonly IImtProvidersService _providersService;
        public ProvidersController(IImtProvidersService providersService)
        {
            _providersService = providersService;
        }

        [Tags("IMT.Providers")]
        [HttpPost("create")]
        public Provider Add(ProvidersRequest request)
        {
            return _providersService.AddProvider(request);
        }

        [Tags("IMT.Providers")]
        [HttpPut("update/{id}")]
        public Provider Update(ulong id, ProvidersRequest request)
        {
            return _providersService.UpdateProvider(id, request);
        }

        [Tags("IMT.Providers")]
        [HttpGet("view/{id}")]
        public Provider? View(ulong id)
        {
            return _providersService.GetProvider(id);
        }

        [Tags("IMT.Providers")]
        [HttpDelete("delete/{id}")]
        public Task<bool> Delete(ulong id)
        {
            return _providersService.DeleteById(id);
        }

        [Tags("IMT.Providers")]
        [HttpGet("getall")]
        public List<Provider> GetAll()
        {
            return _providersService.GetAllProviders();
        }
    }
}
