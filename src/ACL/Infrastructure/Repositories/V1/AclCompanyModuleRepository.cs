using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclCompanyModuleRepository : IAclCompanyModuleRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Company Module";
        private ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclCompanyModuleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public async Task<AclResponse> GetAll()
        {
            var aclCompanyModules = await _dbContext.AclCompanyModules.ToListAsync();
            this.aclResponse.Message = aclCompanyModules.Any() ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModules;
            this.aclResponse.StatusCode = aclCompanyModules.Any() ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = PrepareInputData(request);
                _dbContext.Add(aclCompanyModule);
                await _dbContext.SaveChangesAsync();
                _dbContext.Entry(aclCompanyModule).Reload();
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
        /// <inheritdoc/>
        public async Task<AclResponse> EditAclCompanyModule(ulong Id, AclCompanyModuleRequest request)
        {
            try
            {
                var _aclCompanyModule = await _dbContext.AclCompanyModules.FindAsync(Id);
                this.aclResponse.Message = (_aclCompanyModule != null) ? this.messageResponse.editMessage : this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = (_aclCompanyModule != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                if (_aclCompanyModule != null)
                {
                    _aclCompanyModule = PrepareInputData(request, Id, _aclCompanyModule);
                    _dbContext.AclCompanyModules.Update(_aclCompanyModule);
                    _dbContext.SaveChanges();
                    _dbContext.Entry(_aclCompanyModule).Reload();
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
        /// <inheritdoc/>
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclCompanyModule = await _dbContext.AclCompanyModules.FindAsync(id);
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
            return aclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> DeleteCompanyModule(ulong id)
        {
            var aclCompanyModule = await _dbContext.AclCompanyModules.FindAsync(id);
            this.aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Message = aclCompanyModule != null ? this.messageResponse.deleteMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                _dbContext.AclCompanyModules.Remove(aclCompanyModule);
                _dbContext.SaveChanges();
            }
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (id == 0)
            {
                return !_dbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId) && _dbContext.AclCompanies.Any(x => x.Id == companyId) && _dbContext.AclModules.Any(x => x.Id == moduleId);
            }
            else
            {
                return _dbContext.AclCompanyModules
               .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId && x.Id != id) && _dbContext.AclCompanies.Any(x => x.Id == companyId) && _dbContext.AclModules.Any(x => x.Id == moduleId);
            }
        }
        /// <inheritdoc/>
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
        /// <inheritdoc/>
        public List<AclCompany>? All()
        {
            try
            {
                return _dbContext.AclCompanies.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompanyModule? Find(ulong id)
        {
            try
            {
                return _dbContext.AclCompanyModules.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompanyModule? Add(AclCompanyModule aclCompanyModule)
        {
            try
            {
                _dbContext.AclCompanyModules.Add(aclCompanyModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCompanyModule).ReloadAsync();
                return aclCompanyModule;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompanyModule? Update(AclCompanyModule aclCompanyModule)
        {
            try
            {
                _dbContext.AclCompanyModules.Update(aclCompanyModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCompanyModule).ReloadAsync();
                return aclCompanyModule;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclCompanyModule? Delete(AclCompanyModule aclCompanyModule)
        {
            try
            {
                _dbContext.AclCompanyModules.Remove(aclCompanyModule);
                _dbContext.SaveChangesAsync();
                return aclCompanyModule;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompanyModule? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclCompanyModules.Find(id);
                _dbContext.AclCompanyModules.Remove(delete);
                _dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
