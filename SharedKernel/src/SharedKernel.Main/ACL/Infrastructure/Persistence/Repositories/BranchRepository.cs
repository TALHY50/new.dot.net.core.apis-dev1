using Microsoft.AspNetCore.Http;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Domain.Entities;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Auth;

namespace SharedKernel.Main.ACL.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class BranchRepository : IBranchRepository
    {
        /// <inheritdoc/>
        protected readonly ApplicationDbContext _dbContext;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public BranchRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
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
                this._dbContext.AclBranches.Add(entity);
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
                return this._dbContext.AclBranches.ToList();
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
                this._dbContext.AclBranches.Remove(entity);
                this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Branch? Delete(ulong id)
        {
            try
            {
                var delete = this._dbContext.AclBranches.Find(id);
#pragma warning disable CS8604 // Possible null reference argument.
                this._dbContext.AclBranches.Remove(delete);
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
        public Branch? GetById(ulong id)
        {
            try
            {
                return this._dbContext.AclBranches.Find(id);
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
                this._dbContext.AclBranches.Update(entity);
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
