using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class UserUserGroupRepository : EfRepository<UserUsergroup>, IUserUserGroupRepository
    {
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        public UserUserGroupRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        }
        /// <inheritdoc/>
        public UserUsergroup? Add(UserUsergroup request)
        {
            this._dbContext.Add(request);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>
        public UserUsergroup DeleteById(ulong id)
        {
            UserUsergroup? request = this._dbContext.AclUserUsergroups.Find(id);
            this._dbContext.AclUserUsergroups.Remove(request);
            this._dbContext.SaveChanges();
            return request;
        }
        /// <inheritdoc/>
        public UserUsergroup Edit(ulong id, UserUsergroup? request)
        {
            UserUsergroup? requestOne = this._dbContext.AclUserUsergroups.Find(id);
            request ??= requestOne;
            this._dbContext.AclUserUsergroups.Update(request);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>
        public UserUsergroup? FindById(ulong id)
        {
            return this._dbContext.AclUserUsergroups.Find(id);
        }
        /// <inheritdoc/>
        public List<UserUsergroup> GetAll()
        {
            return this._dbContext.AclUserUsergroups.ToList();
        }
        /// <inheritdoc/>
        public List<UserUsergroup>? All()
        {
            try
            {
                return this._dbContext.AclUserUsergroups.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public UserUsergroup? Find(ulong id)
        {
            try
            {
                return this._dbContext.AclUserUsergroups.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public UserUsergroup? Update(UserUsergroup userUserGroup)
        {
            try
            {
                this._dbContext.AclUserUsergroups.Update(userUserGroup);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(userUserGroup).Reload();
                return userUserGroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public UserUsergroup? Delete(UserUsergroup userUserGroup)
        {
            try
            {
                this._dbContext.AclUserUsergroups.Remove(userUserGroup);
                this._dbContext.SaveChanges();
                return userUserGroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public UserUsergroup? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                this._dbContext.AclUserUsergroups.Remove(delete);
                this._dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public UserUsergroup[]? AddRange(UserUsergroup[]? userUserGroups)
        {
            if (userUserGroups == null || userUserGroups.Length == 0)
                return null;
            try
            {
                this._dbContext.AclUserUsergroups.AddRange(userUserGroups);
                this._dbContext.SaveChanges();
                return userUserGroups;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public UserUsergroup[]? RemoveRange(UserUsergroup[] userUserGroups)
        {
            if ( userUserGroups.Length == 0)
                return null;
            try
            {
                this._dbContext.AclUserUsergroups.RemoveRange(userUserGroups);
                this._dbContext.SaveChanges();
                return userUserGroups;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public UserUsergroup[]? Where(ulong userid)
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

        public UserUsergroup PrepareDataForInput(ulong userGroup, ulong userId)
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
            UserUsergroup userUserGroup = new UserUsergroup
            {
                UserId = userId,
                UsergroupId = userGroup,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return userUserGroup;
        }

        public bool UserIsExist(ulong userId)
        {
            return this._dbContext.AclUsers.Any(i => i.Id == userId);
        }
        public bool UserGroupIsExist(ulong id)
        {
            return this._dbContext.AclUserUsergroups.Any(m=> m.Id == id);
        }
    }
}
