using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Extensions;

//using ACL.Infrastructure.Persistence.DTOs;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class UserRepository : IUserRepository
    {
        private uint _companyId;
        private uint _userType;
        //   private bool _isUserTypeCreatedByCompany = false;
        private readonly IConfiguration _config;
        private readonly IDistributedCache _distributedCache;
        private readonly ICryptographyService _cryptographyService;
        public IUserUserGroupRepository UserUserGroupRepository;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618
        private static IHttpContextAccessor _httpContextAccessor;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618

        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext, IConfiguration config, IDistributedCache distributedCache, ICryptographyService cryptographyService, IUserUserGroupRepository userUserGroupRepository, IHttpContextAccessor httpContextAccessor)
        {

            this.UserUserGroupRepository = userUserGroupRepository;
            this._config = config;
            var user = _httpContextAccessor?.HttpContext?.User;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this._distributedCache = distributedCache;
            this._dbContext = dbContext;
            this._cryptographyService = cryptographyService;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
            this._companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
#pragma warning disable CS8629 // Nullable value type may be null.
            this._userType = (uint)AppAuth.GetAuthInfo().UserType;
#pragma warning restore CS8629 // Nullable value type may be null.
        }
       
        public User? FindByEmail(string email)
        {
            return this._dbContext.AclUsers.FirstOrDefault(m => m.Email == email);
        }
        /// <inheritdoc/>
        public User? FindByIdAsync(ulong id)
        {
            try
            {
                return this._dbContext.AclUsers.FirstOrDefault(m => m.Id == id);
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
            this._companyId = companyId;
            return this._companyId;
        }
        /// <inheritdoc/>
        public uint SetUserType(bool is_user_type_created_by_company)
        {
            return this._userType = is_user_type_created_by_company ? uint.Parse(this._config["USER_TYPE_S_ADMIN"]) : uint.Parse(this._config["USER_TYPE_USER"]);
        }
        /// <inheritdoc/>
        public User? AddAndSaveAsync(User entity)
        {
            return Add(entity);
        }
        /// <inheritdoc/>
        public User? UpdateAndSaveAsync(User entity)
        {
            return Update(entity);
        }
        /// <inheritdoc/>
        public async Task<User?> GetUserWithPermissionAsync(uint userId)
        {
            HashSet<string>? routeNames = new();

            var user = FindByIdAsync(userId);

            if (user == null) return user;

            var userPermissionVersion = user.PermissionVersion;

            var key = $"{Enum.GetName(CacheKeys.UserIdPermissionVersion)}-{userId}_{userPermissionVersion}";

            if (this._distributedCache is IDistributedCache)
            {

                string? cachedPermittedRoutes = await this._distributedCache.GetStringAsync(key);

                if (cachedPermittedRoutes != null)
                {
                    routeNames =
                        JsonConvert.DeserializeObject<HashSet<string>>(cachedPermittedRoutes) ?? null;
                }
            }

            if (! routeNames.Safe().Any())
            {
                var result = (from userUsergroup in this._dbContext.AclUserUsergroups
                              join usergroup in this._dbContext.AclUsergroups on userUsergroup.UsergroupId equals usergroup.Id
                              join usergroupRole in this._dbContext.AclUsergroupRoles on usergroup.Id equals usergroupRole.UsergroupId
                              join role in this._dbContext.AclRoles on usergroupRole.RoleId equals role.Id
                              join rolePage in this._dbContext.AclRolePages on role.Id equals rolePage.RoleId
                              join page in this._dbContext.AclPages on rolePage.PageId equals page.Id
                              join pageRoute in this._dbContext.AclPageRoutes on page.Id equals pageRoute.PageId
                              join subModule in this._dbContext.AclSubModules on page.SubModuleId equals subModule.Id
                              join module in this._dbContext.AclModules on subModule.ModuleId equals module.Id
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

                if (result.Safe().Any())
                {
                    routeNames = new HashSet<string>(result.Select(q => q.PageRouteName)!);
                }

                if (this._distributedCache is IDistributedCache)
                {
                    await this._distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(routeNames));
                }
            }

            var permission = new Permission(userPermissionVersion, routeNames);

            user.SetPermission(permission);

            return user;
        }
        /// <inheritdoc/>
        public List<User>? All()
        {
            try
            {
                return this._dbContext.AclUsers.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public User? Find(ulong id)
        {
            try
            {
                return Queryable.FirstOrDefault(this._dbContext.AclUsers, x => x.Id == id && x.CreatedById == AppAuth.GetAuthInfo().UserId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public User? Add(User user)
        {
            try
            {
                this._dbContext.AclUsers.Add(user);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(user).Reload();
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public User? Update(User user)
        {
            try
            {
                this._dbContext.AclUsers.Update(user);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(user).Reload();
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public User? Delete(User user)
        {
            try
            {
                this._dbContext.AclUsers.Remove(user);
                this._dbContext.SaveChanges();
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public User? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                this._dbContext.AclUsers.Remove(delete);
                this._dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        /// <inheritdoc/>
        public async Task ReloadEntitiesAsync(IEnumerable<UserUsergroup> entities)
        {
            await Task.WhenAll(entities.Select(entity => this._dbContext.Entry(entity).ReloadAsync()));
        }
        public Task ReloadEntities(IEnumerable<UserUsergroup> entities)
        {
            Task.WaitAll(entities.Select<UserUsergroup, Task>(entity => this._dbContext.Entry(entity).ReloadAsync()).ToArray());
            return Task.CompletedTask;
        }


        public List<ulong>? GetUserIdByChangePermission(ulong? module_id = null, ulong? sub_module_id = null, ulong? page_id = null, ulong? role_id = null, ulong? user_group_id = null)
        {

            var query = from aclUser in this._dbContext.AclUsers
                        join userUsergroup in this._dbContext.AclUserUsergroups on aclUser.Id equals userUsergroup.UserId
                        join usergroup in this._dbContext.AclUsergroups on userUsergroup.UsergroupId equals usergroup.Id
                        join usergroupRole in this._dbContext.AclUsergroupRoles on usergroup.Id equals usergroupRole.UsergroupId
                        join role in this._dbContext.AclRoles on usergroupRole.RoleId equals role.Id
                        join rolePage in this._dbContext.AclRolePages on role.Id equals rolePage.RoleId
                        join page in this._dbContext.AclPages on rolePage.PageId equals page.Id
                        join pageRoute in this._dbContext.AclPageRoutes on page.Id equals pageRoute.PageId
                        join subModule in this._dbContext.AclSubModules on page.SubModuleId equals subModule.Id
                        join module in this._dbContext.AclModules on subModule.ModuleId equals module.Id
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
                User? aclUser = this._dbContext.AclUsers.Find(userId);
                if (aclUser != null)
                {
                    aclUser.PermissionVersion = aclUser.PermissionVersion + 1;
                }
                this._dbContext.AclUsers.Update(aclUser);
                this._dbContext.SaveChanges();
            }
        }


        public bool IsAclUserEmailExist(string email, ulong? isUserId = null)
        {

            if (isUserId == null)
            {
                return this._dbContext.AclUsers.Any(x => x.Email == email);
            }
            else
            {
                return this._dbContext.AclUsers.Any(x => x.Email == email && x.Id != isUserId);
            }
        }

        public bool IsExist(ulong id)
        {
            return this._dbContext.AclUsers.Any(m => m.Id == id);
        }


    }
}
