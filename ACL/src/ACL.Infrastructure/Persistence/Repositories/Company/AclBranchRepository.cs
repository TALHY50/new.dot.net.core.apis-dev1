using ACL.Application.Ports.Repositories.Company;
using ACL.Core.Entities.Company;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ACL.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclBranchRepository : IAclBranchRepository
    {
        /// <inheritdoc/>
        protected readonly ApplicationDbContext _dbContext;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public AclBranchRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public AclBranch? Add(AclBranch entity)
        {
            try
            {
                _dbContext.AclBranches.Add(entity);
                _dbContext.SaveChanges();
                _dbContext.Entry(entity).ReloadAsync();
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
                return _dbContext.AclBranches.ToList();
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
                _dbContext.AclBranches.Remove(entity);
                _dbContext.SaveChangesAsync();
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
                var delete = _dbContext.AclBranches.Find(id);
#pragma warning disable CS8604 // Possible null reference argument.
                _dbContext.AclBranches.Remove(delete);
#pragma warning restore CS8604 // Possible null reference argument.
                _dbContext.SaveChangesAsync();
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
                return _dbContext.AclBranches.Find(id);
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
                _dbContext.AclBranches.Update(entity);
                _dbContext.SaveChanges();
                _dbContext.Entry(entity).ReloadAsync();
                return entity;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

    }
}
