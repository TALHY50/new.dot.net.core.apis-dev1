using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.UserGroup;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.UserGroup;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.UserGroup
{
      
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class AclUserGroupRoleRepository : IAclUserGroupRoleRepository
    {
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclUserGroupRoleRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            _dbContext = dbContext;
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
            await Task.WhenAll(entities.Select(entity => _dbContext.Entry(entity).ReloadAsync()));
        }

        public Task ReloadEntities(IEnumerable<AclUsergroupRole> entities)
        {
            return Task.WhenAll(entities.Select(entity => _dbContext.Entry(entity).ReloadAsync()));
        }

        /// <inheritdoc/>
        public ulong RoleIdExist(ulong roleId)
        {
            var valid = _dbContext.AclRoles.Any(x => x.Id == roleId && x.CompanyId == AppAuth.GetAuthInfo().CompanyId);

            if (!valid)
            {
                throw new InvalidOperationException("Role Id " + roleId +" does not exist.");
            }

            return roleId;
        }
        /// <inheritdoc/>
        public ulong UserGroupIdExist(ulong userGroupId)
        {
            var valid = _dbContext.AclUsergroups.Any(x => x.Id == userGroupId && x.CompanyId == AppAuth.GetAuthInfo().CompanyId);

            if (!valid)
            {
                throw new InvalidOperationException("UserGroup Id does not exist.");
            }

            return userGroupId;
        }

        /// <inheritdoc/>
        public List<AclUsergroupRole>? All()
        {

            return _dbContext.AclUsergroupRoles.Where(x=>x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Find(ulong id)
        {

            return _dbContext.AclUsergroupRoles.Find(id);

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Add(AclUsergroupRole aclUserGroupRole)
        {

            _dbContext.AclUsergroupRoles.Add(aclUserGroupRole);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclUserGroupRole).Reload();
            return aclUserGroupRole;
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Update(AclUsergroupRole aclUserGroupRole)
        {

            _dbContext.AclUsergroupRoles.Update(aclUserGroupRole);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclUserGroupRole).Reload();
            return aclUserGroupRole;

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Delete(AclUsergroupRole aclUserGroupRole)
        {
            _dbContext.AclUsergroupRoles.Remove(aclUserGroupRole);
            _dbContext.SaveChanges();
            return aclUserGroupRole;
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Delete(ulong id)
        {
            var delete = Find(id);
            _dbContext.AclUsergroupRoles.Remove(delete);
            _dbContext.SaveChanges();
            return delete;
        }
    }
}
