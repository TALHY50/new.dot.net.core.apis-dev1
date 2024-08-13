using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using Thunes.Exception;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("ProvidedPayers")]
    [Route("[controller]")]
    public class ProviderPayersController : BaseController
    {
        private readonly IImtProviderPayersService _providerPayersService;
        private readonly ApplicationDbContext _context;
        public ProviderPayersController(IImtProviderPayersService providerPayersService, ApplicationDbContext context)
        {
            _providerPayersService = providerPayersService;
            _context = context;
        }



        [HttpGet("GetAll")]
        public List<ProviderPayer> GetAll()
        {
            try
            {
                return _providerPayersService.GetProviderPayers();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        [HttpGet("{id}")]
        public ProviderPayer GetById(ulong id)
        {
            try
            {
                return _providerPayersService.GetProviderPayersById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        [HttpPost("Create")]
        public ProviderPayer Create(ProviderPayerRequest request)
        {
            try
            {
                return _providerPayersService.CreateProviderPayers(request);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        public ProviderPayer Update(ulong id, ProviderPayerRequest request)
        {
            try
            {
                return _providerPayersService.UpdateProviderPayers(id, request);
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
                return _providerPayersService.DeleteProviderPayers(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

    }
}
