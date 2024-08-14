using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("Provider")]
    [Route("[controller]")]
    public class ProviderController : BaseController
    {
        private readonly IImtProviderService _providerService;
        private readonly ApplicationDbContext _context;
        public ProviderController(IImtProviderService providerService, ApplicationDbContext context)
        {
            _providerService = providerService;
            _context = context;
        }

        [HttpGet("GetAll")]
        public List<Provider> GetAll()
        {
            try
            {
                return _providerService.GetProvider();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id}")]
        public Provider GetById(ulong id)
        {
            try
            {
                return _providerService.GetProviderById(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost("Create")]
        public Provider Create(ProviderRequest request)
        {
            try
            {
                return _providerService.CreateProvider(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        public Provider Update(ulong id, ProviderRequest request)
        {
            try
            {
                return _providerService.UpdateProvider(id, request);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        public Task<bool> Delete(ulong id)
        {
            try
            {
                return _providerService.DeleteProvider(id);
            }
            catch(Exception e)
            {
                throw e;
            }

        }

    }
}
