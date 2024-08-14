using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderService;
using pservice = SharedKernel.Main.Domain.IMT.ProviderService;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.ProviderService
{
    public class ImtProviderServiceService : ImtProviderServiceRepository, IImtProviderServiceService
    {
        private readonly IImtProviderServiceService _providerServiceService;
        private readonly IImtProviderServiceRepository _providerServiceRepository;
        public ImtProviderServiceService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _providerServiceRepository = DependencyContainer.GetService<IImtProviderServiceRepository>();
        }

        public pservice? AddProviderService(ProviderServiceRequest request)
        {
            return base.Add(PrepareDataProviderService(request));
        }

        public pservice? UpdateProviderService(ulong id, ProviderServiceRequest request)
        {
            return base.Update(PrepareDataProviderService(request, base.GetById(id)));
        }

        public pservice? GetProviderService(ulong id)
        {
            return base.GetById(id);
        }

        public Task<bool> DeleteByIdService(ulong id)
        {
            return base.Delete(base.GetById(id));
        }

        public List<pservice>? GetAllProviderService()
        {
            return base.All().ToList();
        }


        public pservice? PrepareDataProviderService(ProviderServiceRequest request, pservice? providerService = null)
        {
            if(providerService == null)
            {
                return new pservice
                {
                    ImtProviderId = request.imt_provider_id,
                    Name = request.name,
                    CreatedById = 1, //hard coded cause login not yet implemented
                    UpdatedById = 1, //hard coded cause login not yet implemented
                    CreatedAt = providerService == null ? DateTime.Now : providerService.CreatedAt,
                    UpdatedAt = providerService == null ? DateTime.Now : DateTime.UtcNow
                };
            }
            else
            {
                providerService.ImtProviderId = request.imt_provider_id;
                providerService.Name = request.name;
                providerService.UpdatedById = 1; //hard coded since login has not yet implemented
                providerService.UpdatedAt = DateTime.Now;

                return providerService;
            }
        }
    }
}
