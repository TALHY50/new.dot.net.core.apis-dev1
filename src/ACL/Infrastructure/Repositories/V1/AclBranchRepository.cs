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

        AclBranch? AclBranchRepository.Add(AclBranch entity)
        {
            try
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                _dbContext.Entry(entity).ReloadAsync();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        IEnumerable<AclBranch>? AclBranchRepository.All()
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

        bool AclBranchRepository.Delete(AclBranch entity)
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

        AclBranch? AclBranchRepository.GetById(ulong id)
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

        AclBranch? AclBranchRepository.Update(AclBranch entity)
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
