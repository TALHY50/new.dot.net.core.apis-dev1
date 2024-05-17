using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclUserUserGroupRepository : IAclUserUserGroupRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private readonly string modelName = "User User Group";
        readonly ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclUserUserGroupRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public AclUserUsergroup? Add(AclUserUsergroup request)
        {
            _dbContext.Add(request);
            _dbContext.SaveChanges();
            _dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>

        public AclUserUsergroup DeleteById(ulong id)
        {
            AclUserUsergroup? request = _dbContext.AclUserUsergroups.Find(id);
            _dbContext.AclUserUsergroups.Remove(request);
            _dbContext.SaveChanges();
            return request;
        }
        /// <inheritdoc/>
        public AclUserUsergroup Edit(ulong id, AclUserUsergroup? request)
        {
            AclUserUsergroup? requestOne = _dbContext.AclUserUsergroups.Find(id);
            if (request == null)
            {
                request = requestOne;
            }
            _dbContext.AclUserUsergroups.Update(request);
            _dbContext.SaveChanges();
            _dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>
        public AclUserUsergroup? FindById(ulong id)
        {
            return _dbContext.AclUserUsergroups.Find(id);
        }
        /// <inheritdoc/>
        public List<AclUserUsergroup> GetAll()
        {
            return _dbContext.AclUserUsergroups.ToList();
        }
        /// <inheritdoc/>
        public List<AclUserUsergroup>? All()
        {
            try
            {
                return _dbContext.AclUserUsergroups.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup? Find(ulong id)
        {
            try
            {
                return _dbContext.AclUserUsergroups.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup? Update(AclUserUsergroup acluseruserGroup)
        {
            try
            {
                _dbContext.AclUserUsergroups.Update(acluseruserGroup);
                _dbContext.SaveChanges();
                _dbContext.Entry(acluseruserGroup).Reload();
                return acluseruserGroup;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup? Delete(AclUserUsergroup acluseruserGroup)
        {
            try
            {
                _dbContext.AclUserUsergroups.Remove(acluseruserGroup);
                _dbContext.SaveChanges();
                return acluseruserGroup;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclUserUsergroup? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                _dbContext.AclUserUsergroups.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup[]? AddRange(AclUserUsergroup[]? userUsergroups)
        {
            if (userUsergroups == null || userUsergroups.Length == 0)
                return null;
            try
            {
                _dbContext.AclUserUsergroups.AddRange(userUsergroups);
                _dbContext.SaveChanges();
                return userUsergroups;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup[]? RemoveRange(AclUserUsergroup[] userUsergroups)
        {
            if (userUsergroups == null || userUsergroups.Length == 0)
                return null;
            try
            {
                _dbContext.AclUserUsergroups.RemoveRange(userUsergroups);
                _dbContext.SaveChanges();
                return userUsergroups;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup[]? Where(ulong userid)
        {
            try
            {
                return _dbContext.AclUserUsergroups
                    .Where(u => u.UserId == userid)
                    .ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
