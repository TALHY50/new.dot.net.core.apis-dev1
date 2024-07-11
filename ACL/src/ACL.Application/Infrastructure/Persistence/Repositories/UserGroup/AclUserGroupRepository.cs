using Notification.Application.Domain.Ports.Repositories.Auth;
using Notification.Application.Domain.Ports.Repositories.UserGroup;
using Notification.Application.Domain.UserGroup;
using Notification.Application.Infrastructure.Persistence.Configurations;
using Notification.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace ACL.Application.Infrastructure.Persistence.Repositories.UserGroup
{
    /// <inheritdoc/>
    public class AclUserGroupRepository : IAclUserGroupRepository
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public AclUserGroupRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public ulong SetCompanyId(ulong companyId)
        {
            CompanyId = companyId;
            return CompanyId;
        }
        /// <inheritdoc/>
        public List<AclUsergroup>? All()
        {
            try
            {
                return _dbContext.AclUsergroups.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Find(ulong id)
        {
            try
            {
                return _dbContext.AclUsergroups.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Add(AclUsergroup aclUsergroup)
        {
            try
            {
                _dbContext.AclUsergroups.Add(aclUsergroup);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUsergroup).Reload();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroup? Update(AclUsergroup aclUsergroup)
        {
            try
            {
                _dbContext.AclUsergroups.Update(aclUsergroup);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUsergroup).Reload();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroup? Delete(AclUsergroup aclUsergroup)
        {
            try
            {
                _dbContext.AclUsergroups.Remove(aclUsergroup);
                _dbContext.SaveChanges();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Deleted(ulong id)
        {
            try
            {
                var delete = Find(id);
                _dbContext.AclUsergroups.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsExist(ulong id)
        {
            return _dbContext.AclUserUsergroups.Any(m=> m.Id == id);
        }
    }
}
