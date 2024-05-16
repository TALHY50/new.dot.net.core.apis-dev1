using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclBranchRepository : IAclBranchRepository
    {
        protected readonly DbSet<AclBranch> _dbSet;
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IDistributedCache _distributedCache;

        public AclBranchRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<AclBranch>();
        }
        AclBranch IAclBranchRepository.Add(AclBranch entity)
        {
            try
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();
                _dbSet.Entry(entity).ReloadAsync();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        IEnumerable<AclBranch> IAclBranchRepository.All()
        {
            try
            {
                return _dbContext.AclBranches.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        bool IAclBranchRepository.Delete(AclBranch entity)
        {
            try
            {
                _dbContext.AclBranches.Remove(entity);
               _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        AclBranch IAclBranchRepository.GetById(ulong id)
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

        AclBranch IAclBranchRepository.Update(AclBranch entity)
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
