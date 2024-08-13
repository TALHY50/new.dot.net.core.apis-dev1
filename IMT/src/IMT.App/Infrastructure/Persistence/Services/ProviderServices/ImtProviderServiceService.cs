using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderService;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using System.Linq;
using pservice = SharedKernel.Main.Domain.IMT.ProviderService;

namespace IMT.App.Infrastructure.Persistence.Services.ProviderService
{
    public class ImtProviderServiceService : ImtProviderServiceRepository, IImtProviderServiceService
    {
        public IImtProviderServiceRepository _providerServiceRepository;
        public ImtProviderServiceService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _providerServiceRepository = DependencyContainer.GetService<IImtProviderServiceRepository>();
        }

        public pservice CreateProviderService(ProviderServiceRequest request)
        {
            try
            {
                return base.Add(PrepareProviderService(request));
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        public List<pservice> GetAllProviderService()
        {
            return base.All().ToList();
        }

        public pservice ProviderServiceGetById(ulong Id)
        {
            return base.GetById(Id);
        }

        public pservice UpdateProviderService(ulong Id, ProviderServiceRequest request)
        {
            return base.Update(PrepareProviderService(request, base.GetById(Id)));
        }

        public Task<bool> DeleteProviderService(ulong Id)
        {
            return base.Delete(base.GetById(Id));
        }
        public pservice PrepareProviderService(ProviderServiceRequest request, pservice? providerService = null)
        {
            if(providerService == null)
            {
                return new pservice
                {
                    ImtProviderId = 420,
                    Name = request.name,
                    CreatedById = 1,
                    UpdatedById = 84,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

            }
            else
            {
                providerService.Name = request.name;   
                return providerService;
            }
        }

        
    }
}
