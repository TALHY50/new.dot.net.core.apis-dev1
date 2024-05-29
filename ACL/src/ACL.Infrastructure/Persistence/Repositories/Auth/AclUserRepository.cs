using ACL.Application.Common;
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

        public AclResponse AclResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "User";
        private uint _companyId;
        private uint _userType;
        //   private bool _isUserTypeCreatedByCompany = false;
        private readonly IConfiguration _config;
        private readonly IDistributedCache _distributedCache;
        private readonly ICryptographyService _cryptographyService;
        public IAclUserUserGroupRepository AclUserUserGroupRepository;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IHttpContextAccessor _httpContextAccessor;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private readonly ApplicationDbContext _dbContext;

        public AclUserRepository(ApplicationDbContext dbContext, IConfiguration config, IDistributedCache distributedCache, ICryptographyService cryptographyService, IAclUserUserGroupRepository aclUserUserGroupRepository, IHttpContextAccessor httpContextAccessor)
        {

            AclUserUserGroupRepository = aclUserUserGroupRepository;
            this._config = config;
            this.AclResponse = new AclResponse();
            var user = _httpContextAccessor?.HttpContext?.User;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
            _dbContext = dbContext;
            _cryptographyService = cryptographyService;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
            this._companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
#pragma warning disable CS8629 // Nullable value type may be null.
            this._userType = (uint)AppAuth.GetAuthInfo().UserType;
#pragma warning restore CS8629 // Nullable value type may be null.
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclUser>? aclUser = All()?.Where(u => _companyId == 0 || (u.CompanyId == _companyId && u.CreatedById == _companyId))?.ToList();
            aclUser?.ForEach(user =>
           {
               user.Password = "**********";
               user.Salt = "**********";
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
               user.Claims = null;
               user.RefreshToken = null;
           });

            // further we need to add with companyid from auth and created by  from UTHUSER ID other wise the system would be insecured.
            IEnumerable<AclUser>? result = aclUser.Where(i => i.Id != 1 && i.Status == 1);
            if (aclUser.Any())
            {
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.AclResponse.Data = result;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public Task<AclResponse> AddUser(AclUserRequest request)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();

            try
            {
                strategy.Execute(() =>
               {
                   using IDbContextTransaction? transaction = _dbContext.Database.BeginTransaction();
                   try
                   {
                       AclUser? aclUser = PrepareInputData(request);
                       aclUser = Add(aclUser);

                       // Need to insert user user group
                       AclUserUsergroup[] userUserGroups = PrepareDataForUserUserGroups(request, aclUser?.Id);
                       _dbContext.AclUserUsergroups.AddRange(userUserGroups);
                       ReloadEntities(userUserGroups);

                       if (aclUser != null)
                       {
                           aclUser.Password = "******************"; // request.Password
                           aclUser.Salt = "******************";
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                           aclUser.Claims = null;
                           aclUser.RefreshToken = null;
                           this.AclResponse.Data = aclUser;
                       }

                       this.AclResponse.Message = this.MessageResponse.createMessage;
                       this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

                       transaction.CommitAsync();
                   }
                   catch (Exception ex)
                   {
                       transaction?.RollbackAsync();
                       this.AclResponse.Message = ex.Message;
                       this.AclResponse.StatusCode = AppStatusCode.FAIL;
                   }
               });
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }

            this.AclResponse.Timestamp = DateTime.Now;
            return Task.FromResult(this.AclResponse);
        }

        /// <inheritdoc/>
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            AclUser? aclUser = Find(id);
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(() =>
            {
                using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (aclUser != null)
                        {
                            aclUser = PrepareInputData(request, aclUser);
                            aclUser = Update(aclUser);
                            // first delete all user user group
                            AclUserUsergroup[] userUserGroups = AclUserUserGroupRepository.Where(id).ToArray();
                            AclUserUserGroupRepository.RemoveRange(userUserGroups);
                            // need to insert user user group
                            AclUserUsergroup[]? userGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser?.Id);
                            AclUserUserGroupRepository.AddRange(userGroupPrepareData);
                            //if (aclUser != null)
                            //{
                            //    aclUser.Password = "******************"; //request.Password
                            //    aclUser.Salt = "******************";
                            //    aclUser.Claims = null;
                            //    this.AclResponse.Data = aclUser;
                            //}
                            this.AclResponse.Message = this.MessageResponse.editMessage;
                            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

                            List<ulong> users = new List<ulong> { aclUser.Id };
                            this.UpdateUserPermissionVersion(users);
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                            this.AclResponse.StatusCode = AppStatusCode.FAIL;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        this.AclResponse.Message = ex.Message;
                        this.AclResponse.StatusCode = AppStatusCode.FAIL;
                    }
                }

                return Task.CompletedTask;
            });
            if (aclUser == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
            }
            else
            {
                aclUser.Password = "***********";
                aclUser.Salt = "***********";
                aclUser.Claims = null;
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
                this.AclResponse.Data = aclUser;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }

        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclUser? aclUser = Find(id);
                if (aclUser == null)
                {
                    this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                }
                else
                {
                    aclUser.Password = "***********";
                    aclUser.Salt = "***********";
                    aclUser.Claims = null;
                    this.AclResponse.Message = this.MessageResponse.fetchMessage;
                    this.AclResponse.Data = aclUser;
                }
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }

            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclUser? FindByEmail(string email)
        {
            try
            {
                return _dbContext.AclUsers.FirstOrDefault(m => m.Email == email);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUser? FindByIdAsync(ulong id)
        {
            try
            {
                return _dbContext.AclUsers.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            AclUser? aclUser = Find(id);
            if (aclUser != null)
            {
                this.AclResponse.Data = Delete(aclUser);
                // delete all item for user user group
                AclUserUsergroup[]? userUserGroups = AclUserUserGroupRepository?.Where(id)?.ToArray();
                if (userUserGroups?.Count() > 0)
                {
                    AclUserUserGroupRepository?.RemoveRange(userUserGroups);
                }

                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.AclResponse;
        }

        public AclUser PrepareInputData(AclUserRequest request, AclUser? aclUser = null)
        {
            var salt = _cryptographyService.GenerateSalt();
            if (aclUser == null)
            {
                return new AclUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = _cryptographyService.HashPassword(request.Password, salt),
                    Avatar = request.Avatar,
                    Dob = request.DOB,
                    Gender = request.Gender,
                    Address = request.Address,
                    City = request.City,
                    Country = request.Country,
                    Phone = request.Phone,
                    Username = request.UserName,
                    Language = request.Language,
                    ImgPath = request.ImgPath,
                    Status = request.Status,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedById = (uint)AppAuth.GetAuthInfo().UserId,
                    CompanyId = (this._companyId != 0) ? this._companyId : (uint)AppAuth.GetAuthInfo().CompanyId,
                    UserType = (this._companyId == 0) ? uint.Parse(this._config["USER_TYPE_S_ADMIN"]) : uint.Parse(this._config["USER_TYPE_USER"]),
                    Salt = salt,
                    Claims = new Claim[] { }
                };
            }
            else
            {
                aclUser.FirstName = request.FirstName;
                aclUser.LastName = request.LastName;
                aclUser.Email = request.Email;
                aclUser.Password = aclUser.Password;
                aclUser.Avatar = request.Avatar;
                aclUser.Dob = request.DOB;
                aclUser.Gender = request.Gender;
                aclUser.Address = request.Address;
                aclUser.City = request.City;
                aclUser.Country = request.Country;
                aclUser.Phone = request.Phone;
                aclUser.Language = "en-US";
                aclUser.Username = request.UserName;
                aclUser.ImgPath = request.ImgPath;
                aclUser.Status = request.Status;
                aclUser.UpdatedAt = DateTime.Now;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument.
                aclUser.CompanyId = (this._companyId != 0) ? this._companyId : (uint)AppAuth.GetAuthInfo().CompanyId;
                aclUser.UserType = (this._userType != 0) ? this._userType : (uint)AppAuth.GetAuthInfo().UserType;
                aclUser.Salt = aclUser.Salt;
                aclUser.Claims = aclUser.Claims;
            }
            return aclUser;
        }

        /// <inheritdoc/>
        public AclUserUsergroup[] PrepareDataForUserUserGroups(AclUserRequest request, ulong? user_id)
        {
            IList<AclUserUsergroup> res = new List<AclUserUsergroup>();

            foreach (ulong user_group in request.UserGroup)
            {
                AclUserUsergroup aclUserUserGroup = new AclUserUsergroup();
                aclUserUserGroup.UserId = user_id ?? 0;
                aclUserUserGroup.UsergroupId = user_group;
                aclUserUserGroup.CreatedAt = DateTime.Now;
                aclUserUserGroup.UpdatedAt = DateTime.Now;
                res.Add(aclUserUserGroup);
            }
            return res.ToArray();
        }
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

            var user = this.FindByIdAsync(userId);

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
        public List<AclUser>? All()
        {
            try
            {
                return _dbContext.AclUsers.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclUser? Find(ulong id)
        {
            try
            {
                return _dbContext.AclUsers.Find(id);
            }
            catch (Exception)
            {
                return null;
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
                return null;
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
                return null;
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
                return null;
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
                return null;
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



    }
}
