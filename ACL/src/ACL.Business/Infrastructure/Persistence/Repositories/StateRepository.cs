using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument
namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class StateRepository :EfRepository<State>, IStateRepository
    {
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public StateRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
      
        /// <inheritdoc/>
        public string ExistByName(uint? id, string name)
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
        public uint CountryIdExist(uint countryId)
        {
            var valid = this._dbContext.AclCountries.Any(x => x.Id == countryId);

            if (!valid)
            {
                throw new InvalidOperationException("Country Id does not exist.");
            }

            return countryId;
        }
        /// <inheritdoc/>
        public List<State> All()
        {

            return this._dbContext.AclStates.ToList();

        }
        /// <inheritdoc/>
        public State? Find(uint id)
        {

            return this._dbContext.AclStates.Find(id);

        }
        /// <inheritdoc/>
        public State? Add(State state)
        {
            this._dbContext.AclStates.Add(state);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(state).Reload();
            return state;
        }
        /// <inheritdoc/>
        public State? Update(State state)
        {

            this._dbContext.AclStates.Update(state);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(state).Reload();
            return state;

        }
        /// <inheritdoc/>
        public State? Delete(State state)
        {

            this._dbContext.AclStates.Remove(state);
            this._dbContext.SaveChangesAsync();
            return state;


        }
        /// <inheritdoc/>
        public State? Delete(uint id)
        {

            var delete = this._dbContext.AclStates.Find(id);
            this._dbContext.AclStates.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;

        }
    }
}
