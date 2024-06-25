using ACL.Application.Ports.Repositories.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

  
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument
namespace ACL.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclStateRepository : IAclStateRepository
    {
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclStateRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
      
        /// <inheritdoc/>
        public string ExistByName(ulong? id, string name)
        {
            var valid = _dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = _dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            if (valid)
            {
                throw new InvalidOperationException("Name does not unique.");
            }
            return name;
        }
        /// <inheritdoc/>
        public ulong CountryIdExist(ulong countryId)
        {
            var valid = _dbContext.AclCountries.Any(x => x.Id == countryId);

            if (!valid)
            {
                throw new InvalidOperationException("Country Id does not exist.");
            }

            return countryId;
        }
        /// <inheritdoc/>
        public List<AclState> All()
        {

            return _dbContext.AclStates.ToList();

        }
        /// <inheritdoc/>
        public AclState? Find(ulong id)
        {

            return _dbContext.AclStates.Find(id);

        }
        /// <inheritdoc/>
        public AclState? Add(AclState aclState)
        {
            _dbContext.AclStates.Add(aclState);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclState).Reload();
            return aclState;
        }
        /// <inheritdoc/>
        public AclState? Update(AclState aclState)
        {

            _dbContext.AclStates.Update(aclState);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclState).Reload();
            return aclState;

        }
        /// <inheritdoc/>
        public AclState? Delete(AclState aclState)
        {

            _dbContext.AclStates.Remove(aclState);
            _dbContext.SaveChangesAsync();
            return aclState;


        }
        /// <inheritdoc/>
        public AclState? Delete(ulong id)
        {

            var delete = _dbContext.AclStates.Find(id);
            _dbContext.AclStates.Remove(delete);
            _dbContext.SaveChanges();
            return delete;

        }
    }
}
