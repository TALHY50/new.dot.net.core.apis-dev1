using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Domain.ACL.Domain.Auth;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Auth
{
    /// <inheritdoc/>
    public class AclUserUserGroupRepository : IAclUserUserGroupRepository
    {
        readonly AclApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        public AclUserUserGroupRepository(AclApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        }
        /// <inheritdoc/>
        public AclUserUsergroup? Add(AclUserUsergroup request)
        {
            this._dbContext.Add(request);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>
        public AclUserUsergroup DeleteById(ulong id)
        {
            AclUserUsergroup? request = this._dbContext.AclUserUsergroups.Find(id);
            this._dbContext.AclUserUsergroups.Remove(request);
            this._dbContext.SaveChanges();
            return request;
        }
        /// <inheritdoc/>
        public AclUserUsergroup Edit(ulong id, AclUserUsergroup? request)
        {
            AclUserUsergroup? requestOne = this._dbContext.AclUserUsergroups.Find(id);
            request ??= requestOne;
            this._dbContext.AclUserUsergroups.Update(request);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>
        public AclUserUsergroup? FindById(ulong id)
        {
            return this._dbContext.AclUserUsergroups.Find(id);
        }
        /// <inheritdoc/>
        public List<AclUserUsergroup> GetAll()
        {
            return this._dbContext.AclUserUsergroups.ToList();
        }
        /// <inheritdoc/>
        public List<AclUserUsergroup>? All()
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
        public AclUserUsergroup? Find(ulong id)
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
        public AclUserUsergroup? Update(AclUserUsergroup aclUserUserGroup)
        {
            try
            {
                this._dbContext.AclUserUsergroups.Update(aclUserUserGroup);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclUserUserGroup).Reload();
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
                this._dbContext.AclUserUsergroups.Remove(aclUserUserGroup);
                this._dbContext.SaveChanges();
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
        public AclUserUsergroup[]? AddRange(AclUserUsergroup[]? userUserGroups)
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
        public AclUserUsergroup[]? RemoveRange(AclUserUsergroup[] userUserGroups)
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
            return this._dbContext.AclUsers.Any(i => i.Id == userId);
        }
        public bool UserGroupIsExist(ulong id)
        {
            return this._dbContext.AclUserUsergroups.Any(m=> m.Id == id);
        }
    }
}
