using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Company;
using SharedKernel.Main.Domain.ACL.Domain.Company;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument
namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Company
{
    /// <inheritdoc/>
    public class AclStateRepository : IAclStateRepository
    {
        /// <inheritdoc/>
        public readonly AclApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclStateRepository(AclApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
      
        /// <inheritdoc/>
        public string ExistByName(ulong? id, string name)
        {
            var valid = this._dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = this._dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
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
            var valid = this._dbContext.AclCountries.Any(x => x.Id == countryId);

            if (!valid)
            {
                throw new InvalidOperationException("Country Id does not exist.");
            }

            return countryId;
        }
        /// <inheritdoc/>
        public List<AclState> All()
        {

            return this._dbContext.AclStates.ToList();

        }
        /// <inheritdoc/>
        public AclState? Find(ulong id)
        {

            return this._dbContext.AclStates.Find(id);

        }
        /// <inheritdoc/>
        public AclState? Add(AclState aclState)
        {
            this._dbContext.AclStates.Add(aclState);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclState).Reload();
            return aclState;
        }
        /// <inheritdoc/>
        public AclState? Update(AclState aclState)
        {

            this._dbContext.AclStates.Update(aclState);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclState).Reload();
            return aclState;

        }
        /// <inheritdoc/>
        public AclState? Delete(AclState aclState)
        {

            this._dbContext.AclStates.Remove(aclState);
            this._dbContext.SaveChangesAsync();
            return aclState;


        }
        /// <inheritdoc/>
        public AclState? Delete(ulong id)
        {

            var delete = this._dbContext.AclStates.Find(id);
            this._dbContext.AclStates.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;

        }
    }
}
