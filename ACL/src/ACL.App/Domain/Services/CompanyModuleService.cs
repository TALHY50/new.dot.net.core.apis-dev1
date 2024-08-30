using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;
using ACL.App.Infrastructure.Auth.Auth;
using ACL.App.Infrastructure.Persistence.Context;
using ACL.App.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace ACL.App.Domain.Services
{
    public class CompanyModuleService : CompanyModuleRepository, ICompanyModuleService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Company Module";
        readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public CompanyModuleService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext, httpContextAccessor) 
        {
            this._dbContext = dbContext;
            this.ScopeResponse = new ScopeResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            this.ScopeResponse.Data = base.All();
            this.ScopeResponse.Message = (this.ScopeResponse.Data != null) ?this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
            this.ScopeResponse.StatusCode = (this.ScopeResponse.Data != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                this.ScopeResponse.Data = base.Add(PrepareInputData(request));
                this.ScopeResponse.Message = this.MessageResponse.createMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse EditAclCompanyModule(ulong id, AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = base.Find(id) ?? throw new Exception("company module not exist");
                this.ScopeResponse.Message = (aclCompanyModule != null) ? this.MessageResponse.editMessage : this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = (aclCompanyModule != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
                if (aclCompanyModule != null)
                {
                   this.ScopeResponse.Data = base.Update(PrepareInputData(request, id, aclCompanyModule));
                }
            }
            catch (Exception ex)
            {
               this.ScopeResponse.Message = ex.Message;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse FindById(ulong id)
        {
            try
            {
               this.ScopeResponse.Data = base.Find(id);
                var message = (this.ScopeResponse.Data != null) ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
                this.ScopeResponse.Message = message;
                this.ScopeResponse.StatusCode = (this.ScopeResponse.Data != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
                this.ScopeResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
               this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
               this.ScopeResponse.Timestamp = DateTime.Now;
            }
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public  ScopeResponse DeleteCompanyModule(ulong id)
        {
            var check = base.Find(id) ?? throw new Exception("company module not exist");
            this.ScopeResponse.Data = base.Delete(id);
            this.ScopeResponse.StatusCode = (this.ScopeResponse.Data != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ScopeResponse.Message = (this.ScopeResponse.Data != null) ? this.MessageResponse.deleteMessage : this.MessageResponse.notFoundMessage;
            return this.ScopeResponse;
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
        public CompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong id = 0, CompanyModule? companyModule = null)
        {
            bool valid = IsValidForCreateOrUpdate(request.CompanyId, request.ModuleId);
            CompanyModule aclCompanyModule = new CompanyModule();
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
