

using ADMIN.Application.Ports.Repositories.Interface;
using ADMIN.Contracts.Requests;
using ADMIN.Core.Entities.AdminProvider;
using ADMIN.Infrastructure.Persistence.Configurations;
using ADMIN.Infrastructure.Persistence.UnitOfWork;
using ADMIN.Infrastructure.Persistence.UnitOfWork.Interface;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Services;

namespace ADMIN.Infrastructure.Persistence.Repositories.Provider
{
    public class ProviderRepository: GenericRepository<AdminProvider, ApplicationDbContext, ICustomUnitOfWork>, IProviderRepository
    {
        public ProviderRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork,
            _unitOfWork.ApplicationDbContext)
        {

        }
        /// <inheritdoc/>
        public AdminProvider? AddProvider(ProviderRequest request)
        {
            AdminProvider adminProvider = PrepareData(request);
           return base.Add(adminProvider);
        }
        /// <inheritdoc/>
        public AdminProvider? UpdateProvider(ulong id, ProviderRequest request)
        {
            var adminProvider = base.GetById(id).Result;
            if (adminProvider != null)
            {
                AdminProvider prePareData = PrepareData(request, adminProvider);
                return base.Update(prePareData);
            }
            return null;
        }
        /// <inheritdoc/>
        public AdminProvider? DeleteProvider(ulong id)
        {
            var adminProvider = base.GetById(id).Result;
            if (adminProvider != null)
            {
                return (base.Delete(adminProvider).Result == true)?adminProvider:null;
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
                    CreatedAt = DateTime.Now,
                };
            }
        }
    }
}