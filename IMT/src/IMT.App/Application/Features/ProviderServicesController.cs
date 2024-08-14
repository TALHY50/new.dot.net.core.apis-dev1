using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Services.ImtProviderServices;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Application.Features
{
    [ApiController]
    [Tags("ProviderServices")]
    [Route("[controller]")]
    public class ProviderServicesController : BaseController
    {

        private readonly IImtProviderServicesService _providerServicesService;
        private readonly ApplicationDbContext _dbContext;
        public ProviderServicesController(IImtProviderServicesService providerServicesService, ApplicationDbContext dbContext)
        {
            _providerServicesService = providerServicesService;
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public List<ProviderService> GetAll()
        {
            try
            {
                return _providerServicesService.GetAllProviderServices();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id}")]
        public ProviderService GetById(ulong id)
        {
            try
            {
                return _providerServicesService.GetProviderServicesById(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost("Create")]
        public ProviderService Create(ProviderServicesRequest request)
        {
            try
            {
                return _providerServicesService.CreateProviderServices(request);
            }
            catch (Exception e)
            { 
                throw e;
            }
        }

        [HttpPut("{id}")]
        public ProviderService Update(ulong id, ProviderServicesRequest request)
        {
            try
            {
                return _providerServicesService.UpdateProviderServices(id, request);
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
                return _providerServicesService.DeleteProviderServices(id);
            }
            catch( Exception e) 
            {
                throw e;
            }
        }
        
    }
}
