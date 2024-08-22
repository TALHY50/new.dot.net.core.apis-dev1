using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Company;
using SharedKernel.Main.Domain.ACL.Domain.Company;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Company
{
    /// <inheritdoc/>
    public class AclCountryRepository : IAclCountryRepository
    {
        readonly AclApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclCountryRepository(AclApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
        }
        /// <inheritdoc/>
        public bool ExistById(ulong id)
        {
            bool exist = false;
            var aclCountry = this._dbContext.AclCountries.Find(id);
            if (aclCountry != null)
            {
                exist = true;
            }
            return exist;
        }

        /// <inheritdoc/>
        public List<AclCountry>? All()
        {
            try
            {
                return this._dbContext.AclCountries.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCountry? Find(ulong id)
        {
            try
            {
                return this._dbContext.AclCountries.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCountry? Add(AclCountry aclCountry)
        {
            try
            {
                this._dbContext.AclCountries.Add(aclCountry);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclCountry).ReloadAsync();
                return aclCountry;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCountry? Update(AclCountry aclCountry)
        {
            try
            {
                this._dbContext.AclCountries.Update(aclCountry);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclCountry).ReloadAsync();
                return aclCountry;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclCountry? Delete(AclCountry aclCountry)
        {
            try
            {
                this._dbContext.AclCountries.Remove(aclCountry);
                this._dbContext.SaveChangesAsync();
                return aclCountry;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCountry? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
#pragma warning disable CS8604 // Possible null reference argument.
                this._dbContext.AclCountries.Remove(delete);
#pragma warning restore CS8604 // Possible null reference argument.
                this._dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception("Country not exist");
            }

        }
    }
}
