

using ADMIN.Application.Ports.Repositories.Interface;
using ADMIN.Contracts.Requests;
using ADMIN.Core.Entities.AdminProvider;
using ADMIN.Infrastructure.Persistence.Configurations;

namespace ADMIN.Infrastructure.Persistence.Repositories.Provider
{
    public class ProviderRepository : IProviderRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public ProviderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AdminProvider> All()
        {
            return _dbContext.AdminProviders.ToList();
        }
        /// <inheritdoc/>
        public AdminProvider? Find(ulong id)
        {
            return _dbContext.AdminProviders.Find(id);
        }
        /// <inheritdoc/>
        public AdminProvider? Add(ProviderRequest request)
        {
            AdminProvider adminProvider = PrepareData(request);
            _dbContext.AdminProviders.Add(adminProvider);
            _dbContext.SaveChanges();
            _dbContext.Entry(adminProvider).Reload();
            return adminProvider;
        }
        /// <inheritdoc/>
        public AdminProvider? Update(ulong id, ProviderRequest request)
        {
            var adminProvider = Find(id);
            if (adminProvider != null)
            {
                AdminProvider prePareData = PrepareData(request, adminProvider);
                _dbContext.AdminProviders.Update(prePareData);
                _dbContext.SaveChanges();
                _dbContext.Entry(adminProvider).Reload();
                return prePareData;
            }
            return null;
        }
        /// <inheritdoc/>
        public AdminProvider? Delete(ulong id)
        {
            var adminProvider = Find(id);
            if (adminProvider != null)
            {
                _dbContext.AdminProviders.Remove(adminProvider);
                _dbContext.SaveChangesAsync();
                return adminProvider;
            }
            else
            {
                return null;
            }
        }

        public AdminProvider PrepareData(ProviderRequest request, AdminProvider? adminProvider = null)
        {
            if (adminProvider != null)
            {
                adminProvider.Name = request.Name;
                adminProvider.Code = request.Code;
                adminProvider.BaseUrl = request.BaseUrl;
                adminProvider.CreatedBy = 1;
                adminProvider.UpdatedBy = 1;
                adminProvider.UpdatedAt = DateTime.Now;
                return adminProvider;
            }
            else
            {
                return new AdminProvider
                {
                    Name = request.Name,
                    Code = request.Code,
                    BaseUrl = request.BaseUrl,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    UpdatedAt = DateTime.Now,
                    CretedAt = DateTime.Now,
                };
            }
        }
    }
}