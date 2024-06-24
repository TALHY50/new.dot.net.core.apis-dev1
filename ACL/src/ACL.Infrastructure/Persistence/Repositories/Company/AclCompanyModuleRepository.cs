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

        public bool CompanyModuleValid(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (id == 0)
            {
                return !_dbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId);
            }
            else
            {
                return _dbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId && x.Id != id);
            }
        }

        public bool CompanyValid(ulong companyId)
        {
                return _dbContext.AclCompanies.Any(x => x.Id == companyId);
        }
        public bool ModuleValid(ulong moduleId)
        {
                return _dbContext.AclModules.Any(x => x.Id == moduleId);
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
