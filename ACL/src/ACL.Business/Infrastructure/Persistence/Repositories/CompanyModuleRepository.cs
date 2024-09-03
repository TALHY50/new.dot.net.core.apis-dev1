using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class CompanyModuleRepository :EfRepository<CompanyModule>, ICompanyModuleRepository
    {
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public CompanyModuleRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

        }

        public bool CompanyModuleValid(uint companyId, uint moduleId, uint id = 0)
        {
            if (id == 0)
            {
                return !this._dbContext.CompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId);
            }
            else
            {
                return this._dbContext.CompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId && x.Id != id);
            }
        }

        public bool CompanyValid(uint companyId)
        {
                return this._dbContext.Companies.Any(x => x.Id == companyId);
        }
        public bool ModuleValid(uint moduleId)
        {
                return this._dbContext.AclModules.Any(x => x.Id == moduleId);
        }

        /// <inheritdoc/>
        public List<CompanyModule>? All()
        {
            try
            {
                return this._dbContext.CompanyModules.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public CompanyModule? Find(uint id)
        {
            try
            {
                return this._dbContext.CompanyModules.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public CompanyModule? Add(CompanyModule aclCompanyModule)
        {
            try
            {
                this._dbContext.CompanyModules.Add(aclCompanyModule);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclCompanyModule).ReloadAsync();
                return aclCompanyModule;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public CompanyModule? Update(CompanyModule aclCompanyModule)
        {
            try
            {
                this._dbContext.CompanyModules.Update(aclCompanyModule);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclCompanyModule).ReloadAsync();
                return aclCompanyModule;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public CompanyModule? Delete(CompanyModule aclCompanyModule)
        {
            try
            {
                this._dbContext.CompanyModules.Remove(aclCompanyModule);
                this._dbContext.SaveChangesAsync();
                return aclCompanyModule;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public CompanyModule? Delete(uint id)
        {
            try
            {
                var delete = this._dbContext.CompanyModules.Find(id);
                if (delete != null)
                    this._dbContext.CompanyModules.Remove(delete);
                this._dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
