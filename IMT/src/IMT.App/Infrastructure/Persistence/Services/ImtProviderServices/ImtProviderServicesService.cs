using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderServices;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.ImtProviderServices
{
    public class ImtProviderServicesService : ImtProviderServicesRepository, IImtProviderServicesService
    {
        public ImtProviderServicesService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
        }

        public ProviderService CreateProviderServices(ProviderServicesRequest request)
        {
            try
            {
                return base.Add(ProviderServicePrepareData(request));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<bool> DeleteProviderServices(ulong Id)
        {
            try
            {
                var providerService = base.GetById(Id);

                return base.Delete(providerService);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<ProviderService> GetAllProviderServices()
        {
            try
            {
                return base.All().ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ProviderService GetProviderServicesById(ulong Id)
        {
            try
            {
                return base.GetById(Id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ProviderService ProviderServicePrepareData(ProviderServicesRequest request, ProviderService providerService = null)
        {
            if(providerService == null)
            {
                return new ProviderService
                {
                    ImtProviderId = request.imt_provider_id,
                    Name = request.name,
                    CreatedById = 1, // not yet provided, so hard coded
                    UpdatedById = 1, // not yet provider, so hard coded
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            else
            {
                providerService.ImtProviderId = request.imt_provider_id;
                providerService.Name = request.name;
                providerService.UpdatedAt = DateTime.Now;

                return providerService;
            }
        }

        public ProviderService UpdateProviderServices(ulong Id, ProviderServicesRequest request)
        {
            try
            {
                var providerService = base.GetById(Id);
                return base.Update(ProviderServicePrepareData(request, providerService));
            }
            catch(Exception e)
            {
                throw e; 
            }
        }
    }
}
