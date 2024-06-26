﻿using ACL.Application.Common;
using ACL.Application.Enums;
using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Services;
using ACL.Application.Ports.Services.Cryptography;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Auth;
using ACL.Infrastructure.Persistence.Configurations;
//using ACL.Infrastructure.Persistence.DTOs;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharedLibrary.Response.CustomStatusCode;
using System.Collections.Generic;
using ACL.Infrastructure.Persistence.DTOs;
using Claim = ACL.Core.Entities.Auth.Claim;

namespace ACL.Infrastructure.Persistence.Repositories.Auth
{
    /// <inheritdoc/>
    public class AclUserRepository : IAclUserRepository
    {
        private uint _companyId;
        private uint _userType;
        //   private bool _isUserTypeCreatedByCompany = false;
        private readonly IConfiguration _config;
        private readonly IDistributedCache _distributedCache;
        private readonly ICryptographyService _cryptographyService;
        public IAclUserUserGroupRepository AclUserUserGroupRepository;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618
        private static IHttpContextAccessor _httpContextAccessor;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618

        private readonly ApplicationDbContext _dbContext;

        public AclUserRepository(ApplicationDbContext dbContext, IConfiguration config, IDistributedCache distributedCache, ICryptographyService cryptographyService, IAclUserUserGroupRepository aclUserUserGroupRepository, IHttpContextAccessor httpContextAccessor)
        {

            AclUserUserGroupRepository = aclUserUserGroupRepository;
            _config = config;
            var user = _httpContextAccessor?.HttpContext?.User;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            _distributedCache = distributedCache;
            _dbContext = dbContext;
            _cryptographyService = cryptographyService;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
            _companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
#pragma warning disable CS8629 // Nullable value type may be null.
            _userType = (uint)AppAuth.GetAuthInfo().UserType;
#pragma warning restore CS8629 // Nullable value type may be null.
        }
       
        public AclUser? FindByEmail(string email)
        {
            try
            {
                return _dbContext.AclUsers.FirstOrDefault(m => m.Email == email);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUser? FindByIdAsync(ulong id)
        {
            try
            {
                return _dbContext.AclUsers.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <inheritdoc/>
        /// <inheritdoc/>
        public uint SetCompanyId(uint companyId)
        {
            _companyId = companyId;
            return _companyId;
        }
        /// <inheritdoc/>
        public uint SetUserType(bool is_user_type_created_by_company)
        {
            return _userType = is_user_type_created_by_company ? uint.Parse(_config["USER_TYPE_S_ADMIN"]) : uint.Parse(_config["USER_TYPE_USER"]);
        }
        /// <inheritdoc/>
        public AclUser? AddAndSaveAsync(AclUser entity)
        {
            return Add(entity);
        }
        /// <inheritdoc/>
        public AclUser? UpdateAndSaveAsync(AclUser entity)
        {
            return Update(entity);
        }
        /// <inheritdoc/>
        public async Task<AclUser?> GetUserWithPermissionAsync(uint userId)
        {
            HashSet<string>? routeNames = new();

            var user = FindByIdAsync(userId);

            if (user == null) return user;

            var userPermissionVersion = user.PermissionVersion;

            var key = $"{Enum.GetName(CacheKeys.UserIdPermissionVersion)}-{userId}_{userPermissionVersion}";

            if (_distributedCache is IDistributedCache)
            {

                string? cachedPermittedRoutes = await _distributedCache.GetStringAsync(key);

                if (cachedPermittedRoutes != null)
                {
                    routeNames =
                        JsonConvert.DeserializeObject<HashSet<string>>(cachedPermittedRoutes) ?? null;
                }
            }

            if (routeNames.IsNullOrEmpty())
            {
                var result = (from userUsergroup in _dbContext.AclUserUsergroups
                              join usergroup in _dbContext.AclUsergroups on userUsergroup.UsergroupId equals usergroup.Id
                              join usergroupRole in _dbContext.AclUsergroupRoles on usergroup.Id equals usergroupRole.UsergroupId
                              join role in _dbContext.AclRoles on usergroupRole.RoleId equals role.Id
                              join rolePage in _dbContext.AclRolePages on role.Id equals rolePage.RoleId
                              join page in _dbContext.AclPages on rolePage.PageId equals page.Id
                              join pageRoute in _dbContext.AclPageRoutes on page.Id equals pageRoute.PageId
                              join subModule in _dbContext.AclSubModules on page.SubModuleId equals subModule.Id
                              join module in _dbContext.AclModules on subModule.ModuleId equals module.Id
                              where userUsergroup.UserId == user.Id
                              select new PermissionQueryResult()
                              {
                                  UserId = user.Id,
                                  PermissionVersion = user.PermissionVersion,
                                  PageId = page.Id,
                                  PageName = page.Name,
                                  PageRouteName = pageRoute.RouteName,
                                  UserGroupId = usergroup.Id,
                                  DefaultUrl = usergroup.DashboardUrl,
                                  UserGroupCategory = usergroup.Category,
                                  ModuleId = module.Id,
                                  ControllerName = subModule.ControllerName,
                                  SubmoduleName = subModule.Name,
                                  SubmoduleId = subModule.Id,
                                  MethodName = page.MethodName,
                                  MethodType = page.MethodType,
                                  DefaultMethod = subModule.DefaultMethod
                              }).ToList();

                if (!result.IsNullOrEmpty())
                {
                    routeNames = new HashSet<string>(result.Select(q => q.PageRouteName)!);
                }

                if (_distributedCache is IDistributedCache)
                {
                    await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(routeNames));
                }
            }

            var permission = new Permission(userPermissionVersion, routeNames);

            user.SetPermission(permission);

            return user;
        }
        /// <inheritdoc/>
        public List<AclUser>? All()
        {
            try
            {
                return _dbContext.AclUsers.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUser? Find(ulong id)
        {
            try
            {
                return _dbContext.AclUsers.FirstOrDefault(x => x.Id == id && x.CreatedById == AppAuth.GetAuthInfo().UserId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUser? Add(AclUser aclUser)
        {
            try
            {
                _dbContext.AclUsers.Add(aclUser);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUser).Reload();
                return aclUser;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUser? Update(AclUser aclUser)
        {
            try
            {
                _dbContext.AclUsers.Update(aclUser);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUser).Reload();
                return aclUser;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUser? Delete(AclUser aclUser)
        {
            try
            {
                _dbContext.AclUsers.Remove(aclUser);
                _dbContext.SaveChanges();
                return aclUser;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUser? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                _dbContext.AclUsers.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        /// <inheritdoc/>
        public async Task ReloadEntitiesAsync(IEnumerable<AclUserUsergroup> entities)
        {
            await Task.WhenAll(entities.Select(entity => _dbContext.Entry(entity).ReloadAsync()));
        }
        public Task ReloadEntities(IEnumerable<AclUserUsergroup> entities)
        {
            Task.WaitAll(entities.Select<AclUserUsergroup, Task>(entity => _dbContext.Entry(entity).ReloadAsync()).ToArray());
            return Task.CompletedTask;
        }


        public List<ulong>? GetUserIdByChangePermission(ulong? module_id = null, ulong? sub_module_id = null, ulong? page_id = null, ulong? role_id = null, ulong? user_group_id = null)
        {

            var query = from aclUser in _dbContext.AclUsers
                        join userUsergroup in _dbContext.AclUserUsergroups on aclUser.Id equals userUsergroup.UserId
                        join usergroup in _dbContext.AclUsergroups on userUsergroup.UsergroupId equals usergroup.Id
                        join usergroupRole in _dbContext.AclUsergroupRoles on usergroup.Id equals usergroupRole.UsergroupId
                        join role in _dbContext.AclRoles on usergroupRole.RoleId equals role.Id
                        join rolePage in _dbContext.AclRolePages on role.Id equals rolePage.RoleId
                        join page in _dbContext.AclPages on rolePage.PageId equals page.Id
                        join pageRoute in _dbContext.AclPageRoutes on page.Id equals pageRoute.PageId
                        join subModule in _dbContext.AclSubModules on page.SubModuleId equals subModule.Id
                        join module in _dbContext.AclModules on subModule.ModuleId equals module.Id
                        select new { aclUser, usergroup, subModule, role, page, module };

            if (module_id != null)
            {
                query = query.Where(u => u.module.Id == module_id);
            }

            if (sub_module_id != null)
            {
                query = query.Where(u => u.subModule.Id == sub_module_id);
            }

            if (page_id != null)
            {
                query = query.Where(u => u.page.Id == page_id);
            }

            if (role_id != null)
            {
                query = query.Where(u => u.role.Id == role_id);
            }

            if (user_group_id != null)
            {
                query = query.Where(u => u.usergroup.Id == user_group_id);
            }
            List<ulong>? result = query.GroupBy(x => x.aclUser.Id).Select(u => u.Key).ToList();
            return result;
        }

        public void UpdateUserPermissionVersion(List<ulong> userIds)
        {
            foreach (var userId in userIds)
            {
                AclUser? aclUser = _dbContext.AclUsers.Find(userId);
                if (aclUser != null)
                {
                    aclUser.PermissionVersion = aclUser.PermissionVersion + 1;
                }
                _dbContext.AclUsers.Update(aclUser);
                _dbContext.SaveChanges();
            }
        }


        public bool IsAclUserEmailExist(string email, ulong? isUserId = null)
        {

            if (isUserId == null)
            {
                return _dbContext.AclUsers.Any(x => x.Email == email);
            }
            else
            {
                return _dbContext.AclUsers.Any(x => x.Email == email && x.Id != isUserId);
            }
        }

        public bool IsExist(ulong id)
        {
            return _dbContext.AclUsers.Any(m => m.Id == id);
        }


    }
}
