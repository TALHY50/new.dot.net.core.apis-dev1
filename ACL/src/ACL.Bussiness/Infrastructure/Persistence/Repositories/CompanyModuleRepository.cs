using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Domain.Entities;
using ACL.Bussiness.Infrastructure.Auth.Auth;
using ACL.Bussiness.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Bussiness.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class CompanyModuleRepository : ICompanyModuleRepository
    {
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public CompanyModuleRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

        }

        public bool CompanyModuleValid(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (id == 0)
            {
                return !this._dbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId);
            }
            else
            {
                return this._dbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId && x.Id != id);
            }
        }

        public bool CompanyValid(ulong companyId)
        {
                return this._dbContext.AclCompanies.Any(x => x.Id == companyId);
        }
        public bool ModuleValid(ulong moduleId)
        {
                return this._dbContext.AclModules.Any(x => x.Id == moduleId);
        }

        /// <inheritdoc/>
        public List<Company>? All()
        {
            try
            {
                return this._dbContext.AclCompanies.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public CompanyModule? Find(ulong id)
        {
            try
            {
                return this._dbContext.AclCompanyModules.Find(id);
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
                this._dbContext.AclCompanyModules.Add(aclCompanyModule);
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
                this._dbContext.AclCompanyModules.Update(aclCompanyModule);
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
                this._dbContext.AclCompanyModules.Remove(aclCompanyModule);
                this._dbContext.SaveChangesAsync();
                return aclCompanyModule;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public CompanyModule? Delete(ulong id)
        {
            try
            {
                var delete = this._dbContext.AclCompanyModules.Find(id);
                if (delete != null)
                    this._dbContext.AclCompanyModules.Remove(delete);
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
