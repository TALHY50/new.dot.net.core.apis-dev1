using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.UserGroup;
using SharedKernel.Main.Contracts.ACL.Requests;
using SharedKernel.Main.Domain.ACL.Domain.UserGroup;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.UserGroup
{
      
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class AclUserGroupRoleRepository : IAclUserGroupRoleRepository
    {
        readonly AclApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclUserGroupRoleRepository(AclApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._aclUserRepository = aclUserRepository;
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);

        }
        public AclUsergroupRole[] GetUserGroupRoles(AclUserGroupRoleRequest request)
        {

            var userGroupRoles = request.RoleIds.Select(roleId => new AclUsergroupRole
            {
                UsergroupId = UserGroupIdExist(request.UserGroupId),
                RoleId = RoleIdExist(roleId),
                CompanyId = AppAuth.GetAuthInfo().CompanyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }).ToArray();

            return userGroupRoles;
        }

        public async Task ReloadEntitiesAsync(IEnumerable<AclUsergroupRole> entities)
        {
            await Task.WhenAll(entities.Select(entity => this._dbContext.Entry(entity).ReloadAsync()));
        }

        public Task ReloadEntities(IEnumerable<AclUsergroupRole> entities)
        {
            return Task.WhenAll(entities.Select(entity => this._dbContext.Entry(entity).ReloadAsync()));
        }

        /// <inheritdoc/>
        public ulong RoleIdExist(ulong roleId)
        {
            var valid = Queryable.Any(this._dbContext.AclRoles, x => x.Id == roleId && x.CompanyId == AppAuth.GetAuthInfo().CompanyId);

            if (!valid)
            {
                throw new InvalidOperationException("Role Id " + roleId +" does not exist.");
            }

            return roleId;
        }
        /// <inheritdoc/>
        public ulong UserGroupIdExist(ulong userGroupId)
        {
            var valid = Queryable.Any(this._dbContext.AclUsergroups, x => x.Id == userGroupId && x.CompanyId == AppAuth.GetAuthInfo().CompanyId);

            if (!valid)
            {
                throw new InvalidOperationException("UserGroup Id does not exist.");
            }

            return userGroupId;
        }

        /// <inheritdoc/>
        public List<AclUsergroupRole>? All()
        {

            return Queryable.Where(this._dbContext.AclUsergroupRoles, x=>x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Find(ulong id)
        {

            return this._dbContext.AclUsergroupRoles.Find(id);

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Add(AclUsergroupRole aclUserGroupRole)
        {

            this._dbContext.AclUsergroupRoles.Add(aclUserGroupRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclUserGroupRole).Reload();
            return aclUserGroupRole;
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Update(AclUsergroupRole aclUserGroupRole)
        {

            this._dbContext.AclUsergroupRoles.Update(aclUserGroupRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclUserGroupRole).Reload();
            return aclUserGroupRole;

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Delete(AclUsergroupRole aclUserGroupRole)
        {
            this._dbContext.AclUsergroupRoles.Remove(aclUserGroupRole);
            this._dbContext.SaveChanges();
            return aclUserGroupRole;
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Delete(ulong id)
        {
            var delete = Find(id);
            this._dbContext.AclUsergroupRoles.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;
        }
    }
}
