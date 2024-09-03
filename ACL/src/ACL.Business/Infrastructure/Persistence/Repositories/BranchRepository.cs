using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class BranchRepository : EfRepository<Branch>, IBranchRepository
    {
        /// <inheritdoc/>
        protected readonly ApplicationDbContext _dbContext;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public BranchRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public Branch? Add(Branch entity)
        {
            try
            {
                this._dbContext.Branches.Add(entity);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(entity).ReloadAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public IEnumerable<Branch>? All()
        {
            try
            {
                return this._dbContext.Branches.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public bool Delete(Branch entity)
        {
            try
            {
                this._dbContext.Branches.Remove(entity);
                this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Branch? Delete(uint id)
        {
            try
            {
                var delete = this._dbContext.Branches.Find(id);
#pragma warning disable CS8604 // Possible null reference argument.
                this._dbContext.Branches.Remove(delete);
#pragma warning restore CS8604 // Possible null reference argument.
                this._dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {

                throw new Exception("Branch id not Exist");
            }
        }
        /// <inheritdoc/>
        public Branch? GetById(uint id)
        {
            try
            {
                return this._dbContext.Branches.Find(id);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Branch? Update(Branch entity)
        {
            try
            {
                this._dbContext.Branches.Update(entity);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(entity).ReloadAsync();
                return entity;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

    }
}
