using ErrorOr;
using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPayers;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.ImtProviderPayers
{
    public class ImtProviderPayersService : ImtProviderPayersRepository, IImtProviderPayersService
    {
        public IImtProviderPayersRepository _providerPayerRepository;
        public ImtProviderPayersService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _providerPayerRepository = DependencyContainer.GetService<IImtProviderPayersRepository>();
        }

        public ProviderPayer CreateProviderPayers(ProviderPayerRequest request)
        {
            try
            {
                return base.Add(ProviderPayerPrepareData(request));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<bool> DeleteProviderPayers(ulong id)
        {
            try
            {
                var providerPayers = base.GetById(id);
                return base.Delete(providerPayers);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public List<ProviderPayer> GetProviderPayers()
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

        public ProviderPayer GetProviderPayersById(ulong id)
        {
            try
            {
                return base.GetById(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ProviderPayer ProviderPayerPrepareData(ProviderPayerRequest request, ProviderPayer? providerPayer = null)
        {
            if (providerPayer == null)
            {
                return new ProviderPayer
                {
                    ImtProviderId = 1, // not yet provided, so hard coded
                    ImtCountryId = 1, // not yet provided, so hard coded
                    ImtCurrencyId = 1, // not yet provided, so hard coded
                    ImtProviderServiceId = request.imt_provider_service_id,
                    RemotePayerId = request.remote_payer_id,
                    Precision = request.precision,
                    Increment = request.increment,
                    CreatedAt = providerPayer == null ? DateTime.Now : providerPayer.CreatedAt,
                    UpdatedAt = providerPayer != null ? DateTime.Now : DateTime.UtcNow
                    //CreatedAt = DateTime.UtcNow,
                    //UpdatedAt = DateTime.UtcNow
                };
            }
            else
            {
                providerPayer.ImtProviderServiceId = request.imt_provider_service_id;
                providerPayer.RemotePayerId = request.remote_payer_id;
                providerPayer.Precision = request.precision;
                providerPayer.Increment = request.increment;
                providerPayer.UpdatedAt = DateTime.UtcNow;
                return providerPayer;
            }

        }

        public ProviderPayer UpdateProviderPayers(ulong id, ProviderPayerRequest request)
        {
            try
            {
                var providerPayers = base.GetById(id);
                return base.Update(ProviderPayerPrepareData(request, providerPayers));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
