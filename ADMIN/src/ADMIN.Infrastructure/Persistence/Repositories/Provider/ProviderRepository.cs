using ADMIN.Application.Ports.Repositories.Interface.Provider;
using ADMIN.Contracts.Requests;
using ADMIN.Core.Entities.AdminProvider;
using ADMIN.Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Services;

namespace ADMIN.Infrastructure.Persistence.Repositories.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<AdminProvider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        ///// <inheritdoc/>
        //public AdminProvider? AddProvider(ProviderRequest request)
        //{
        //    AdminProvider adminProvider = PrepareData(request);
        //   return base.Add(adminProvider);
        //}
        ///// <inheritdoc/>
        //public AdminProvider? UpdateProvider(ulong id, ProviderRequest request)
        //{
        //    var adminProvider = base.GetById(id);
        //    if (adminProvider != null)
        //    {
        //        AdminProvider prePareData = PrepareData(request, adminProvider);
        //        return base.Update(prePareData);
        //    }
        //    return null;
        //}
        ///// <inheritdoc/>
        //public AdminProvider? DeleteProvider(ulong id)
        //{
        //    var adminProvider = base.GetById(id);
        //    if (adminProvider != null)
        //    {
        //        return (base.Delete(adminProvider).Result == true)?adminProvider:null;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public AdminProvider PrepareData(ProviderRequest request, AdminProvider? adminProvider = null)
        //{
        //    if (adminProvider != null)
        //    {
        //        adminProvider.Name = request.Name;
        //        adminProvider.Code = request.Code;
        //        adminProvider.BaseUrl = request.BaseUrl;
        //        adminProvider.UpdatedBy = 1;
        //        adminProvider.UpdatedAt = DateTime.Now;
        //        return adminProvider;
        //    }
        //    else
        //    {
        //        return new AdminProvider
        //        {
        //            Name = request.Name,
        //            Code = request.Code,
        //            BaseUrl = request.BaseUrl,
        //            CreatedBy = 1,
        //            UpdatedBy = 1,
        //            UpdatedAt = DateTime.Now,
        //            CreatedAt = DateTime.Now,
        //        };
        //    }
        //}
    }
}