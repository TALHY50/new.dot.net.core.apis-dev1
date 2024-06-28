using ACL.Application.Domain.Company;
using ACL.Application.Domain.Ports.Repositories.Company;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace ACL.Application.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclCountryRepository : IAclCountryRepository
    {
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclCountryRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
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
            var aclCountry = _dbContext.AclCountries.Find(id);
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
                return _dbContext.AclCountries.ToList();
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
                return _dbContext.AclCountries.Find(id);
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
                _dbContext.AclCountries.Add(aclCountry);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCountry).ReloadAsync();
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
                _dbContext.AclCountries.Update(aclCountry);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCountry).ReloadAsync();
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
                _dbContext.AclCountries.Remove(aclCountry);
                _dbContext.SaveChangesAsync();
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
                _dbContext.AclCountries.Remove(delete);
#pragma warning restore CS8604 // Possible null reference argument.
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception("Country not exist");
            }

        }
    }
}
