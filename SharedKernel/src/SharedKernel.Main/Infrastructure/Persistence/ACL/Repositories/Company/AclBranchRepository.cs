using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Company;
using SharedKernel.Main.Domain.ACL.Domain.Company;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Company
{
    /// <inheritdoc/>
    public class AclBranchRepository : IAclBranchRepository
    {
        /// <inheritdoc/>
        protected readonly AclApplicationDbContext _dbContext;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public AclBranchRepository(AclApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public AclBranch? Add(AclBranch entity)
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
        public IEnumerable<AclBranch>? All()
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
        public bool Delete(AclBranch entity)
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
        public AclBranch? Delete(ulong id)
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
        public AclBranch? GetById(ulong id)
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
        public AclBranch? Update(AclBranch entity)
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
