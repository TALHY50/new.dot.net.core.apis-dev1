using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Core.Permissions;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.UseCases.Enums;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclUserRepository : IAclUserRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "User";
        private uint _companyId;
        private uint _userType;
        private bool is_user_type_created_by_company = false;
        private IConfiguration _config;
        private readonly IDistributedCache _distributedCache;
        private readonly ICryptographyService _cryptographyService;
        private readonly IAclUserUserGroupRepository AclUserUserGroupRepository;

        private readonly ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclUserRepository(ApplicationDbContext dbcontext, IConfiguration config, IDistributedCache distributedCache, ICryptographyService cryptographyService, IAclUserUserGroupRepository _AclUserUserGroupRepository)
        {
            AclUserUserGroupRepository = _AclUserUserGroupRepository;
            AppAuth.SetAuthInfo();
            this._config = config;
            this.aclResponse = new AclResponse();
            this._companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
            this._userType = (uint)AppAuth.GetAuthInfo().UserType;
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
            _dbContext = dbcontext;
            _cryptographyService = cryptographyService;
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclUser>? aclUser = All()?.Where(u => _companyId == 0 ||( u.CompanyId == _companyId && u.CreatedById ==_companyId))?.ToList();
            aclUser?.ForEach(user =>
           {
               user.Password = "**********";
               user.Salt = "**********";
               user.Claims = null;
               user.RefreshToken = null;
           });

            // further we need to add with companyid from auth and created by  from UTHUSER ID other wise the system would be insecured.
            IEnumerable<AclUser>? result = (aclUser != null) ? aclUser.Where(i => i.Id != 1 && i.Status == 1) : null;
            if (aclUser.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = result;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> AddUser(AclUserRequest request)
        {

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        AclUser? aclUser = PrepareInputData(request);
                        aclUser = Add(aclUser);
                        //  need to insert user user group
                        AclUserUsergroup[] aclUserUsergroups = PrepareDataForUserUserGroups(request, aclUser?.Id);
                        _dbContext.AclUserUsergroups.AddRange(aclUserUsergroups);
                        await ReloadEntitiesAsync(aclUserUsergroups);
                        if (aclUser != null)
                        {
                            aclUser.Password = "******************"; //request.Password
                            aclUser.Salt = "******************";
                            aclUser.Claims = null;
                            aclUser.RefreshToken = null;
                            this.aclResponse.Data = aclUser;
                        }
                        this.aclResponse.Message = this.messageResponse.createMessage;
                        this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        this.aclResponse.Message = ex.Message;
                        this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    }
                }
            });
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(() =>
            {
                using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        AclUser? aclUser = Find(id);
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
                            if (aclUser != null)
                            {
                                aclUser.Password = "******************"; //request.Password
                                aclUser.Salt = "******************";
                                aclUser.Claims = null;
                                this.aclResponse.Data = aclUser;
                            }
                            this.aclResponse.Message = this.messageResponse.editMessage;
                            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            this.aclResponse.Message = this.messageResponse.notFoundMessage;
                            this.aclResponse.StatusCode = AppStatusCode.FAIL;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        this.aclResponse.Message = ex.Message;
                        this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    }
                }

                return Task.CompletedTask;
            });
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclUser? aclUser = Find(id);
                if (aclUser == null)
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                }
                else
                {
                    aclUser.Password = "***********";
                    aclUser.Salt = "***********";
                    aclUser.Claims = null;
                    this.aclResponse.Message = this.messageResponse.fetchMessage;
                    this.aclResponse.Data = aclUser;
                }
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

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
                this.aclResponse.Data = Delete(aclUser);
                // delete all item for user user group
                AclUserUsergroup[] userUserGroups = AclUserUserGroupRepository.Where(id).ToArray();
                if (userUserGroups.Count() > 0)
                {
                    AclUserUserGroupRepository.RemoveRange(userUserGroups);
                }

                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclUser PrepareInputData(AclUserRequest request, AclUser AclUser = null)
        {
            var salt = _cryptographyService.GenerateSalt();
            if (AclUser == null)
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
                    CompanyId = this._companyId,
                    UserType = (this._companyId == 0) ? uint.Parse(this._config["USER_TYPE_S_ADMIN"]) : uint.Parse(this._config["USER_TYPE_USER"]),
                    Salt = salt,
                    Claims = new Core.Claim[] { }
                };
            }
            else
            {
                AclUser.FirstName = request.FirstName;
                AclUser.LastName = request.LastName;
                AclUser.Email = request.Email;
                AclUser.Password = _cryptographyService.HashPassword(request.Password, AclUser.Salt ?? salt);
                AclUser.Avatar = request.Avatar;
                AclUser.Dob = request.DOB;
                AclUser.Gender = request.Gender;
                AclUser.Address = request.Address;
                AclUser.City = request.City;
                AclUser.Country = request.Country;
                AclUser.Phone = request.Phone;
                AclUser.Language = "en-US";
                AclUser.Username = request.UserName;
                AclUser.ImgPath = request.ImgPath;
                AclUser.Status = request.Status;
                AclUser.UpdatedAt = DateTime.Now;
                AclUser.CompanyId = (this._companyId != 0) ? this._companyId : 0;
                AclUser.UserType = (this._userType != 0) ? this._userType : 0;
                AclUser.Salt = AclUser.Salt ?? salt;
                AclUser.Claims = AclUser.Claims ?? new Core.Claim[] { };
            }
            return AclUser;
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

            var roleIds = (from userUsergroup in this._dbContext.AclUserUsergroups
                           join usergroup in this._dbContext.AclUsergroups on userUsergroup.UsergroupId equals usergroup.Id
                           join usergroupRole in this._dbContext.AclUsergroupRoles on usergroup.Id equals usergroupRole.UsergroupId
                           join role in this._dbContext.AclRoles on usergroupRole.RoleId equals role.Id
                           where userUsergroup.UserId == userId
                           select role.Id).ToList();


            foreach (var roleId in roleIds)
            {
                var key = $"{Enum.GetName(CacheKeys.RoleRouteNames)}-{roleId}";
                HashSet<string> tmpRouteNames = new HashSet<string>();

                string? cachedRouteNames = null;

                if (this._distributedCache is IDistributedCache)
                {
                    cachedRouteNames = await this._distributedCache.GetStringAsync(key);
                }

                if (cachedRouteNames != null)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    tmpRouteNames = JsonConvert.DeserializeObject<HashSet<string>>(cachedRouteNames);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    routeNames.UnionWith(tmpRouteNames);
                }

                if (tmpRouteNames.IsNullOrEmpty())
                {
                    var permissionList = (from rolePage in _dbContext.AclRolePages
                                          join page in _dbContext.AclPages on rolePage.PageId equals page.Id
                                          join pageRoute in _dbContext.AclPageRoutes on page.Id equals pageRoute.PageId
                                          join subModule in _dbContext.AclSubModules on page.SubModuleId equals subModule.Id
                                          join module in _dbContext.AclModules on subModule.ModuleId equals module.Id
                                          where rolePage.RoleId == roleId
                                          select new PermissionQueryResult()
                                          {
                                              UserId = user.Id,
                                              PermissionVersion = user.PermissionVersion,
                                              PageId = page.Id,
                                              PageName = page.Name,
                                              PageRouteName = pageRoute.RouteName,
                                              ModuleId = module.Id,
                                              ControllerName = subModule.ControllerName,
                                              SubmoduleName = subModule.Name,
                                              SubmoduleId = subModule.Id,
                                              MethodName = page.MethodName,
                                              MethodType = page.MethodType,
                                              DefaultMethod = subModule.DefaultMethod
                                          }).ToList();
                    if (permissionList != null)
                    {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                        tmpRouteNames = permissionList.Select(q => q.PageRouteName).ToHashSet();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
                        routeNames.UnionWith(tmpRouteNames);
                        if (this._distributedCache is IDistributedCache)
                        {
                            await this._distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(tmpRouteNames));
                        }
                    }

                }
            }

            var permission = new Permission(routeNames);

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
    }
}
