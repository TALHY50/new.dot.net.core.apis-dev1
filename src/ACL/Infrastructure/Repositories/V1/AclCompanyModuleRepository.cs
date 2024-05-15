using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ACL.Infrastructure.Repositories.V1
{
    public class AclCompanyModuleRepository : GenericRepository<AclCompanyModule, ApplicationDbContext, ICustomUnitOfWork>, IAclCompanyModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company Module";
        public AclCompanyModuleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclCompanyModules = await base.All();
            this.aclResponse.Message = aclCompanyModules.Any() ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModules;
            this.aclResponse.StatusCode = aclCompanyModules.Any() ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = PrepareInputData(request);
                Add(aclCompanyModule);
                await this._unitOfWork.CompleteAsync();
                await base.ReloadAsync(aclCompanyModule);
                this.aclResponse.Data = aclCompanyModule;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> EditAclCompanyModule(ulong Id, AclCompanyModuleRequest request)
        {
            try
            {
                var _aclCompanyModule = await base.GetById(Id);
                this.aclResponse.Message = (_aclCompanyModule != null) ? this.messageResponse.editMessage : this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = (_aclCompanyModule != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                if (_aclCompanyModule != null)
                {
                    _aclCompanyModule = PrepareInputData(request, Id, _aclCompanyModule);
                    await base.UpdateAsync(_aclCompanyModule);
                    await this._unitOfWork.CompleteAsync();
                    await base.ReloadAsync(_aclCompanyModule);
                    this.aclResponse.Data = _aclCompanyModule;
                }
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclCompanyModule = await base.GetById(id);
                var message = aclCompanyModule != null ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
                this.aclResponse.Data = aclCompanyModule;
                this.aclResponse.Message = message;
                this.aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                this.aclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
                this.aclResponse.Timestamp = DateTime.Now;
            }
            return this.aclResponse;
        }
        public async Task<AclResponse> DeleteCompanyModule(ulong id)
        {
            var aclCompanyModule = await base.GetById(id);
            this.aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Message = aclCompanyModule != null ? this.messageResponse.deleteMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                await base.DeleteAsync(aclCompanyModule);
                await this._unitOfWork.CompleteAsync();
            }
            return this.aclResponse;
        }

        public bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (id == 0)
            {
                return !this._unitOfWork.ApplicationDbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId) && this._unitOfWork.ApplicationDbContext.AclCompanies.Any(x => x.Id == companyId) && this._unitOfWork.ApplicationDbContext.AclModules.Any(x => x.Id == moduleId);
            }
            else
            {
                return !this._unitOfWork.ApplicationDbContext.AclCompanyModules
               .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId && x.Id != id) && this._unitOfWork.ApplicationDbContext.AclCompanies.Any(x => x.Id == companyId) && this._unitOfWork.ApplicationDbContext.AclModules.Any(x => x.Id == moduleId);
            }
        }

        public AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong Id = 0, AclCompanyModule _aclCompanyModule = null)
        {
            bool valid = IsValidForCreateOrUpdate(request.CompanyId, request.ModuleId);
            AclCompanyModule aclCompanyModule = new AclCompanyModule();
            if (valid)
            {
                if (_aclCompanyModule != null)
                {
                    aclCompanyModule = _aclCompanyModule;
                }
                aclCompanyModule.CompanyId = request.CompanyId;
                aclCompanyModule.ModuleId = request.ModuleId;
                aclCompanyModule.UpdatedAt = DateTime.Now;
                if (Id == 0)
                {
                    aclCompanyModule.CreatedAt = DateTime.Now;
                }
                return aclCompanyModule;
            }
            else
            {
                throw new InvalidOperationException("Not valid data!");
            }
        }
    }
}
