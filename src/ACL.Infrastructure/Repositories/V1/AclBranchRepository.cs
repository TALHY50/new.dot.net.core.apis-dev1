using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.UseCases.Interfaces.Repositories.V1;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclBranchRepository : IAclBranchRepository
    {
        /// <inheritdoc/>
        protected readonly ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclBranchRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
                return null;
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
                return null;
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
                return false;
            }
        }
        /// <inheritdoc/>
        public AclBranch? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclBranches.Find(id);
                _dbContext.AclBranches.Remove(delete);
                _dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {

                return null;
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

                return null;
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

                return null;
            }
        }

    }
}
