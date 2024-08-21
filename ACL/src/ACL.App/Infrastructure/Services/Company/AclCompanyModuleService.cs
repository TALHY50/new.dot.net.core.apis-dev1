using ACL.App.Application.Interfaces.Services.Company;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Persistence.Repositories.Company;
using ACL.App.Infrastructure.Utilities;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace ACL.App.Infrastructure.Services.Company
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
            this._dbContext = dbContext;
            this.AclResponse = new AclResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            this.AclResponse.Data = base.All();
            this.AclResponse.Message = (this.AclResponse.Data != null) ?this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
            this.AclResponse.StatusCode = (this.AclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                this.AclResponse.Data = base.Add(PrepareInputData(request));
                this.AclResponse.Message = this.MessageResponse.createMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse EditAclCompanyModule(ulong id, AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = base.Find(id) ?? throw new Exception("company module not exist");
                this.AclResponse.Message = (aclCompanyModule != null) ? this.MessageResponse.editMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = (aclCompanyModule != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                if (aclCompanyModule != null)
                {
                   this.AclResponse.Data = base.Update(PrepareInputData(request, id, aclCompanyModule));
                }
            }
            catch (Exception ex)
            {
               this.AclResponse.Message = ex.Message;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
               this.AclResponse.Data = base.Find(id);
                var message = (this.AclResponse.Data != null) ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.Message = message;
                this.AclResponse.StatusCode = (this.AclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                this.AclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
               this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
               this.AclResponse.Timestamp = DateTime.Now;
            }
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public  AclResponse DeleteCompanyModule(ulong id)
        {
            var check = base.Find(id) ?? throw new Exception("company module not exist");
            this.AclResponse.Data = base.Delete(id);
            this.AclResponse.StatusCode = (this.AclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.AclResponse.Message = (this.AclResponse.Data != null) ? this.MessageResponse.deleteMessage : this.MessageResponse.notFoundMessage;
            return this.AclResponse;
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
