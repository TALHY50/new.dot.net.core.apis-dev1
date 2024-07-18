using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Company;
using ACL.Application.Domain.Ports.Services.Company;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Persistence.Repositories.Company;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedKernel.Contracts.Response;

namespace ACL.Application.Infrastructure.Services.Company
{
    public class AclCompanyModuleService : AclCompanyModuleRepository, IAclCompanyModuleService
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Company Module";
        readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclCompanyModuleService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext, httpContextAccessor) 
        {
            _dbContext = dbContext;
            AclResponse = new AclResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            AclResponse.Data = base.All();
            AclResponse.Message = (AclResponse.Data != null) ?MessageResponse.fetchMessage : MessageResponse.notFoundMessage;
            AclResponse.StatusCode = (AclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                AclResponse.Data = base.Add(PrepareInputData(request));
                AclResponse.Message = MessageResponse.createMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse EditAclCompanyModule(ulong id, AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = base.Find(id) ?? throw new Exception("company module not exist");
                AclResponse.Message = (aclCompanyModule != null) ? MessageResponse.editMessage : MessageResponse.notFoundMessage;
                AclResponse.StatusCode = (aclCompanyModule != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                if (aclCompanyModule != null)
                {
                   AclResponse.Data = base.Update(PrepareInputData(request, id, aclCompanyModule));
                }
            }
            catch (Exception ex)
            {
               AclResponse.Message = ex.Message;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
               AclResponse.Data = base.Find(id);
                var message = (AclResponse.Data != null) ? MessageResponse.fetchMessage : MessageResponse.notFoundMessage;
                AclResponse.Message = message;
                AclResponse.StatusCode = (AclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                AclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
               AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
               AclResponse.Timestamp = DateTime.Now;
            }
            return AclResponse;
        }
        /// <inheritdoc/>
        public  AclResponse DeleteCompanyModule(ulong id)
        {
            var check = base.Find(id) ?? throw new Exception("company module not exist");
            AclResponse.Data = base.Delete(id);
            AclResponse.StatusCode = (AclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            AclResponse.Message = (AclResponse.Data != null) ? MessageResponse.deleteMessage : MessageResponse.notFoundMessage;
            return AclResponse;
        }
        /// <inheritdoc/>
        public bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (!CompanyModuleValid(companyId, moduleId, id))
            {
                throw new Exception("Company Module already exist");
            }

            if (!CompanyValid(companyId))
            {
                throw new Exception("Company not valid");
            }
            if (!ModuleValid(moduleId))
            {
                throw new Exception("Module not valid");
            }
            return true;
        }
        /// <inheritdoc/>
        public AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong id = 0, AclCompanyModule? companyModule = null)
        {
            bool valid = IsValidForCreateOrUpdate(request.CompanyId, request.ModuleId);
            AclCompanyModule aclCompanyModule = new AclCompanyModule();
            if (valid)
            {
                if (companyModule != null)
                {
                    aclCompanyModule = companyModule;
                }
                aclCompanyModule.CompanyId = request.CompanyId;
                aclCompanyModule.ModuleId = request.ModuleId;
                aclCompanyModule.UpdatedAt = DateTime.Now;
                if (id == 0)
                {
                    aclCompanyModule.CreatedAt = DateTime.Now;
                }
                return aclCompanyModule;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}
