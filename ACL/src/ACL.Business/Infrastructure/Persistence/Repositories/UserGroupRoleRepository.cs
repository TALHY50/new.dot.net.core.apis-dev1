﻿using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
      
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class UserGroupRoleRepository :EfRepository<UsergroupRole>, IUserGroupRoleRepository
    {
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public UserGroupRoleRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._userRepository = userRepository;
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);

        }
        public UsergroupRole[] GetUserGroupRoles(AclUserGroupRoleRequest request)
        {

            var userGroupRoles = request.RoleIds.Select(roleId => new UsergroupRole
            {
                UsergroupId = UserGroupIdExist(request.UserGroupId),
                RoleId = RoleIdExist(roleId),
                CompanyId = AppAuth.GetAuthInfo().CompanyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }).ToArray();

            return userGroupRoles;
        }

        public async Task ReloadEntitiesAsync(IEnumerable<UsergroupRole> entities)
        {
            await Task.WhenAll(entities.Select(entity => this._dbContext.Entry(entity).ReloadAsync()));
        }

        public Task ReloadEntities(IEnumerable<UsergroupRole> entities)
        {
            return Task.WhenAll(entities.Select(entity => this._dbContext.Entry(entity).ReloadAsync()));
        }

        /// <inheritdoc/>
        public uint RoleIdExist(uint roleId)
        {
            var valid = Queryable.Any(this._dbContext.AclRoles, x => x.Id == roleId && x.CompanyId == AppAuth.GetAuthInfo().CompanyId);

            if (!valid)
            {
                throw new InvalidOperationException("Role Id " + roleId +" does not exist.");
            }

            return roleId;
        }
        /// <inheritdoc/>
        public uint UserGroupIdExist(uint userGroupId)
        {
            var valid = Queryable.Any(this._dbContext.AclUsergroups, x => x.Id == userGroupId && x.CompanyId == AppAuth.GetAuthInfo().CompanyId);

            if (!valid)
            {
                throw new InvalidOperationException("UserGroup Id does not exist.");
            }

            return userGroupId;
        }

        /// <inheritdoc/>
        public List<UsergroupRole>? All()
        {

            return Queryable.Where(this._dbContext.AclUsergroupRoles, x=>x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();

        }
        /// <inheritdoc/>
        public UsergroupRole? Find(uint id)
        {

            return this._dbContext.AclUsergroupRoles.Find(id);

        }
        /// <inheritdoc/>
        public UsergroupRole? Add(UsergroupRole userGroupRole)
        {

            this._dbContext.AclUsergroupRoles.Add(userGroupRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(userGroupRole).Reload();
            return userGroupRole;
        }
        /// <inheritdoc/>
        public UsergroupRole? Update(UsergroupRole userGroupRole)
        {

            this._dbContext.AclUsergroupRoles.Update(userGroupRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(userGroupRole).Reload();
            return userGroupRole;

        }
        /// <inheritdoc/>
        public UsergroupRole? Delete(UsergroupRole userGroupRole)
        {
            this._dbContext.AclUsergroupRoles.Remove(userGroupRole);
            this._dbContext.SaveChanges();
            return userGroupRole;
        }
        /// <inheritdoc/>
        public UsergroupRole? Delete(uint id)
        {
            var delete = Find(id);
            this._dbContext.AclUsergroupRoles.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;
        }

        public List<UsergroupRole>? FindByUserGroupId(uint userGroupId)
        {
            return _dbContext.AclUsergroupRoles.Where(x => x.UsergroupId == userGroupId).ToList();
        }

        public UsergroupRole[]? AddAll(UsergroupRole[] aclUserGroupRoles)
        {
            _dbContext.AclUsergroupRoles.AddRange(aclUserGroupRoles);
            _dbContext.SaveChanges();
            return aclUserGroupRoles;
        }

        public UsergroupRole[]? DeleteAll(UsergroupRole[] aclUserGroupRoles)
        {
            _dbContext.AclUsergroupRoles.RemoveRange(aclUserGroupRoles);
            _dbContext.SaveChanges();
            return aclUserGroupRoles;
        }

        public bool IsExist(uint id)
        {
            return this._dbContext.AclUsergroupRoles.Any(i => i.Id == id);
        }
    }
}
