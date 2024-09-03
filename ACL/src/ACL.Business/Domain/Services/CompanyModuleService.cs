using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Contracts;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Domain.Services
{
    public class CompanyModuleService : CompanyModuleRepository, ICompanyModuleService
    {
        /// <inheritdoc/>
        public ApplicationResponse ApplicationResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Company Module";
        readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public CompanyModuleService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext, httpContextAccessor) 
        {
            this._dbContext = dbContext;
            this.ApplicationResponse = new ApplicationResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public ApplicationResponse GetAll()
        {
            this.ApplicationResponse.Data = base.All();
            this.ApplicationResponse.Message = (this.ApplicationResponse.Data != null) ?this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
            this.ApplicationResponse.StatusCode = (this.ApplicationResponse.Data != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                this.ApplicationResponse.Data = base.Add(PrepareInputData(request));
                this.ApplicationResponse.Message = this.MessageResponse.createMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse EditAclCompanyModule(uint id, AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = base.Find(id) ?? throw new Exception("company module not exist");
                this.ApplicationResponse.Message = (aclCompanyModule != null) ? this.MessageResponse.editMessage : this.MessageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = (aclCompanyModule != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
                if (aclCompanyModule != null)
                {
                   this.ApplicationResponse.Data = base.Update(PrepareInputData(request, id, aclCompanyModule));
                }
            }
            catch (Exception ex)
            {
               this.ApplicationResponse.Message = ex.Message;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse FindById(uint id)
        {
            try
            {
               this.ApplicationResponse.Data = base.Find(id);
                var message = (this.ApplicationResponse.Data != null) ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
                this.ApplicationResponse.Message = message;
                this.ApplicationResponse.StatusCode = (this.ApplicationResponse.Data != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
                this.ApplicationResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
               this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
               this.ApplicationResponse.Timestamp = DateTime.Now;
            }
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public  ApplicationResponse DeleteCompanyModule(uint id)
        {
            var check = base.Find(id) ?? throw new Exception("company module not exist");
            this.ApplicationResponse.Data = base.Delete(id);
            this.ApplicationResponse.StatusCode = (this.ApplicationResponse.Data != null) ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ApplicationResponse.Message = (this.ApplicationResponse.Data != null) ? this.MessageResponse.deleteMessage : this.MessageResponse.notFoundMessage;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public bool IsValidForCreateOrUpdate(uint companyId, uint moduleId, uint id = 0)
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
        public CompanyModule PrepareInputData(AclCompanyModuleRequest request, uint id = 0, CompanyModule? companyModule = null)
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
