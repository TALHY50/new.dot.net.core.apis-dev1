using ACL.Application.Ports.Repositories.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ACL.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclCompanyModuleRepository : IAclCompanyModuleRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Company Module";
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclCompanyModuleRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            this.AclResponse = new AclResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public async Task<AclResponse> GetAll()
        {
            var aclCompanyModules = await _dbContext.AclCompanyModules.ToListAsync();
            this.AclResponse.Message = aclCompanyModules.Any() ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
            this.AclResponse.Data = aclCompanyModules;
            this.AclResponse.StatusCode = aclCompanyModules.Any() ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = PrepareInputData(request);
                _dbContext.Add(aclCompanyModule);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(aclCompanyModule).ReloadAsync();
                this.AclResponse.Data = aclCompanyModule;
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
        public async Task<AclResponse> EditAclCompanyModule(ulong id, AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = await _dbContext.AclCompanyModules.FindAsync(id);
                this.AclResponse.Message = (aclCompanyModule != null) ? this.MessageResponse.editMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = (aclCompanyModule != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                if (aclCompanyModule != null)
                {
                    aclCompanyModule = PrepareInputData(request, id, aclCompanyModule);
                    _dbContext.AclCompanyModules.Update(aclCompanyModule);
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Entry(aclCompanyModule).ReloadAsync();
                    this.AclResponse.Data = aclCompanyModule;
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
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclCompanyModule = await _dbContext.AclCompanyModules.FindAsync(id);
                var message = aclCompanyModule != null ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.Data = aclCompanyModule;
                this.AclResponse.Message = message;
                this.AclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                this.AclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
                this.AclResponse.Timestamp = DateTime.Now;
            }
            return AclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> DeleteCompanyModule(ulong id)
        {
            var aclCompanyModule = await _dbContext.AclCompanyModules.FindAsync(id);
            this.AclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.AclResponse.Message = aclCompanyModule != null ? this.MessageResponse.deleteMessage : this.MessageResponse.notFoundMessage;
            this.AclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                _dbContext.AclCompanyModules.Remove(aclCompanyModule);
                await _dbContext.SaveChangesAsync();
            }
            return this.AclResponse;
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
                throw new Exception();
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
                throw new Exception();
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
                throw new Exception();
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
                throw new Exception();
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
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCompanyModule? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclCompanyModules.Find(id);
                if (delete != null)
                    _dbContext.AclCompanyModules.Remove(delete);
                _dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
