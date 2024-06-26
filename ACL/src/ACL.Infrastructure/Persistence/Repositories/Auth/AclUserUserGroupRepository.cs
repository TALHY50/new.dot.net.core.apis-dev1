using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.UserGroup;
using ACL.Contracts.Response;
using ACL.Core.Entities.Auth;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ACL.Infrastructure.Persistence.Repositories.Auth
{
    /// <inheritdoc/>
    public class AclUserUserGroupRepository : IAclUserUserGroupRepository
    {
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        public AclUserUserGroupRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
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
            request ??= requestOne;
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
                throw new Exception();
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
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup? Update(AclUserUsergroup aclUserUserGroup)
        {
            try
            {
                _dbContext.AclUserUsergroups.Update(aclUserUserGroup);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUserUserGroup).Reload();
                return aclUserUserGroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup? Delete(AclUserUsergroup aclUserUserGroup)
        {
            try
            {
                _dbContext.AclUserUsergroups.Remove(aclUserUserGroup);
                _dbContext.SaveChanges();
                return aclUserUserGroup;
            }
            catch (Exception)
            {
                throw new Exception();
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
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup[]? AddRange(AclUserUsergroup[]? userUserGroups)
        {
            if (userUserGroups == null || userUserGroups.Length == 0)
                return null;
            try
            {
                _dbContext.AclUserUsergroups.AddRange(userUserGroups);
                _dbContext.SaveChanges();
                return userUserGroups;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup[]? RemoveRange(AclUserUsergroup[] userUserGroups)
        {
            if ( userUserGroups.Length == 0)
                return null;
            try
            {
                _dbContext.AclUserUsergroups.RemoveRange(userUserGroups);
                _dbContext.SaveChanges();
                return userUserGroups;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUserUsergroup[]? Where(ulong userid)
        {
            try
            {
                return GetAll()
                    .Where(u => u.UserId == userid)
                    .ToArray();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public AclUserUsergroup PrepareDataForInput(ulong userGroup, ulong userId)
        {
            bool userIdValid = UserIsExist(userId);
            if (!userIdValid)
            {
                throw new Exception("User Id not Valid");
            }
            bool userGroupIdValid = UserGroupIsExist(userGroup);
            if (!userGroupIdValid)
            {
                throw new Exception("User Group Id not Valid");
            }
            AclUserUsergroup aclUserUserGroup = new AclUserUsergroup
            {
                UserId = userId,
                UsergroupId = userGroup,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return aclUserUserGroup;
        }

        public bool UserIsExist(ulong userId)
        {
            return _dbContext.AclUsers.Any(i => i.Id == userId);
        }
        public bool UserGroupIsExist(ulong id)
        {
            return _dbContext.AclUserUsergroups.Any(m=> m.Id == id);
        }
    }
}
