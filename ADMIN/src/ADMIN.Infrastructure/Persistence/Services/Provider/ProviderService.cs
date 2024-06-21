using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN.Application.Ports.Services.Interfaces.Provider;
using ADMIN.Contracts.Requests;
using ADMIN.Contracts.Response;
using ADMIN.Core.Entities.AdminProvider;
using ADMIN.Infrastructure.Persistence.Configurations;
using ADMIN.Infrastructure.Persistence.Repositories.Provider;
using SharedLibrary.Response.CustomStatusCode;

namespace ADMIN.Infrastructure.Persistence.Services.Provider
{
    public class ProviderService(ApplicationDbContext dbContext) : ProviderRepository(dbContext),IProviderService
    {
        public AdminResponse Response = new AdminResponse();
        public AdminResponse AddProvider(ProviderRequest request)
        {
            Response.Data = base.Add(PrepareData(request));
            Response.StatusCode = (Response.Data!=null) ?AppStatusCode.SUCCESS:AppStatusCode.FAIL;
            Response.Message = (Response.StatusCode == AppStatusCode.SUCCESS)?"Provider added successfully.":"Operation failed.";
            Response.Timestamp = DateTime.Now;
            return Response;
        }

        public AdminResponse Find(ulong id)
        {
            Response.Data = base.GetById(id);
            Response.StatusCode = (Response.Data!=null) ?AppStatusCode.SUCCESS:AppStatusCode.FAIL;
            Response.Message = (Response.StatusCode == AppStatusCode.SUCCESS)?"Provider fetched successfully.":"Operation failed.";
            Response.Timestamp = DateTime.Now;
            return Response;
        }

        public AdminResponse GetAll()
        {
            Response.Data = base.All();
            Response.StatusCode = (Response.Data!=null) ?AppStatusCode.SUCCESS:AppStatusCode.FAIL;
            Response.Message = (Response.StatusCode == AppStatusCode.SUCCESS)?"Provider fetched successfully.":"Operation failed.";
            Response.Timestamp = DateTime.Now;
            return Response;
        }

        public AdminResponse UpdateProvider(ulong id, ProviderRequest request)
        {
            var adminProvider = base.GetById(id);
            if(adminProvider != null)
                Response.Data = base.Update(PrepareData(request,adminProvider));
            Response.StatusCode = (Response.Data!=null) ?AppStatusCode.SUCCESS:AppStatusCode.FAIL;
            Response.Message = (Response.StatusCode == AppStatusCode.SUCCESS)?"Provider updated successfully.":"Operation failed.";
            Response.Timestamp = DateTime.Now;
            return Response;
        }

        public AdminResponse DeleteProvider(ulong id)
        {
            var adminProvider = base.GetById(id);
            if(adminProvider != null)
              Response.Data = (base.Delete(adminProvider).Result == true) ? adminProvider : null;
            Response.StatusCode = (Response.Data!=null) ?AppStatusCode.SUCCESS:AppStatusCode.FAIL;
            Response.Message = (Response.StatusCode == AppStatusCode.SUCCESS)?"Provider deleted successfully.":"Operation failed.";
            Response.Timestamp = DateTime.Now;
            return Response;
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
