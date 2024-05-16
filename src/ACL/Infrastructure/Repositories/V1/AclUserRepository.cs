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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserRepository : IAclUserRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User";
        private uint _companyId;
        private uint _userType;
        private bool is_user_type_created_by_company = false;
        private IConfiguration _config;
        private readonly IDistributedCache _distributedCache;
        private readonly ICryptographyService cryptographyService;
        private readonly IAclUserUserGroupRepository AclUserUserGroupRepository;

        private readonly ApplicationDbContext _dbcontext;
        public AclUserRepository(ApplicationDbContext dbcontext, IConfiguration config, IDistributedCache distributedCache) 
        {
            AppAuth.SetAuthInfo();
            this._config = config;
            this.aclResponse = new AclResponse();
            this._companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
            this._userType = (uint)AppAuth.GetAuthInfo().UserType;
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
            _dbcontext = dbcontext;
        }

        public async Task<AclResponse> GetAll()
        {
            List<AclUser>? aclUser = _dbcontext.AclUsers.ToList();
            aclUser.ForEach(user =>
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
        public async Task<AclResponse> AddUser(AclUserRequest request)
        {
            try
            {
                AclUser? aclUser = PrepareInputData(request);
                await _dbcontext.AclUsers.AddAsync(aclUser);
                await _dbcontext.SaveChangesAsync();
                await _dbcontext.Entry(aclUser).ReloadAsync();

                //  need to insert user user group
                AclUserUsergroup[]? userGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                await _dbcontext.AclUserUsergroups.AddRangeAsync(userGroupPrepareData);
                await _dbcontext.SaveChangesAsync();
                await _dbcontext.Entry(userGroupPrepareData).ReloadAsync();
                aclUser.Password = "******************"; //request.Password
                aclUser.Salt = "******************";
                aclUser.Claims = null;
                aclUser.RefreshToken = null;
                this.aclResponse.Data = aclUser;
                this.aclResponse.Message = this.messageResponse.createMessage;
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


        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            try
            {
                AclUser aclUser = await _dbcontext.AclUsers.FindAsync(id);

                if (aclUser != null)
                {
                    aclUser = PrepareInputData(request, aclUser);
                    _dbcontext.AclUsers.Update(aclUser);
                    _dbcontext.SaveChanges();
                    await _dbcontext.Entry(aclUser).ReloadAsync();

                    // first delete all user user group
                    AclUserUsergroup[]? UserUserGroups = _dbcontext.AclUserUsergroups.Where(x => x.UserId == id).ToArray();
                    _dbcontext.AclUserUsergroups.RemoveRange(UserUserGroups);
                    _dbcontext.SaveChanges();

                    // need to insert user user group
                    AclUserUsergroup[]? UserGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                    _dbcontext.AclUserUsergroups.AddRange(UserGroupPrepareData);
                    _dbcontext.SaveChanges();
                    aclUser.Password = "******************"; //request.Password
                    aclUser.Salt = "******************";
                    aclUser.Claims = null;
                    this.aclResponse.Data = aclUser;
                    this.aclResponse.Message = this.messageResponse.editMessage;
                    this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.aclResponse;
                }

            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }


        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                AclUser? aclUser = await _dbcontext.AclUsers.FindAsync(id);
                this.aclResponse.Data = aclUser;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                if (aclUser == null)
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
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

        public async Task<AclUser?> FindByEmail(string email)
        {
            return await _dbcontext.AclUsers.FirstOrDefaultAsync(m => m.Email == email);

        }

        public async Task<AclUser?> FindByIdAsync(ulong id)
        {
            return await _dbcontext.AclUsers.FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<AclResponse> DeleteById(ulong id)
        {
            AclUser? aclUser = await _dbcontext.AclUsers.FindAsync(id);

            if (aclUser != null)
            {
                _dbcontext.AclUsers.Remove(aclUser);
                _dbcontext.SaveChanges();
                await _dbcontext.Entry(aclUser).ReloadAsync();

                // delete all item for user user group
                var UserUserGroups = _dbcontext.AclUserUsergroups.Where(x => x.UserId == id).ToArray();
                _dbcontext.RemoveRange(UserUserGroups);
                _dbcontext.SaveChanges();
                await _dbcontext.Entry(UserUserGroups).ReloadAsync();

                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.aclResponse;
        }

        public AclUser PrepareInputData(AclUserRequest request, AclUser AclUser = null)
        {
            var salt = cryptographyService.GenerateSalt();
            if (AclUser == null)
            {
                return new AclUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = cryptographyService.HashPassword(request.Password, salt),
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
                AclUser.Password = cryptographyService.HashPassword(request.Password, AclUser.Salt ?? salt);
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


        public AclUserUsergroup[] PrepareDataForUserUserGroups(AclUserRequest request, ulong user_id)
        {
            IList<AclUserUsergroup> res = new List<AclUserUsergroup>();

            foreach (ulong user_group in request.UserGroup)
            {
                AclUserUsergroup aclUserUserGroup = new AclUserUsergroup();
                aclUserUserGroup.UserId = user_id;
                aclUserUserGroup.UsergroupId = user_group;
                aclUserUserGroup.CreatedAt = DateTime.Now;
                aclUserUserGroup.UpdatedAt = DateTime.Now;
                res.Add(aclUserUserGroup);
            }
            return res.ToArray();
        }

        public uint SetCompanyId(uint companyId)
        {
            this._companyId = companyId;
            return this._companyId;
        }
        public uint SetUserType(bool is_user_type_created_by_company)
        {

            return this._userType = is_user_type_created_by_company ? uint.Parse(this._config["USER_TYPE_S_ADMIN"]) : uint.Parse(this._config["USER_TYPE_USER"]);
        }

        public async Task<AclUser> AddAndSaveAsync(AclUser entity)
        {
            await _dbcontext.AclUsers.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<AclUser> UpdateAndSaveAsync(AclUser entity)
        {
            this._dbcontext.Update(entity);
            await this._dbcontext.SaveChangesAsync();

            return entity;
        }
        public async Task<AclUser?> GetUserWithPermissionAsync(uint userId)
        {
            HashSet<string>? routeNames = new HashSet<string>();

            var user = await this.FindByIdAsync(userId);

            if (user == null) return user;

            var roleIds = (from userUsergroup in this._dbcontext.AclUserUsergroups
                           join usergroup in this._dbcontext.AclUsergroups on userUsergroup.UsergroupId equals usergroup.Id
                           join usergroupRole in this._dbcontext.AclUsergroupRoles on usergroup.Id equals usergroupRole.UsergroupId
                           join role in this._dbcontext.AclRoles on usergroupRole.RoleId equals role.Id
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
                    tmpRouteNames = JsonConvert.DeserializeObject<HashSet<string>>(cachedRouteNames);
                    routeNames.UnionWith(tmpRouteNames);
                }

                if (tmpRouteNames.IsNullOrEmpty())
                {
                    var permissionList = (from rolePage in _dbcontext.AclRolePages
                                          join page in _dbcontext.AclPages on rolePage.PageId equals page.Id
                                          join pageRoute in _dbcontext.AclPageRoutes on page.Id equals pageRoute.PageId
                                          join subModule in _dbcontext.AclSubModules on page.SubModuleId equals subModule.Id
                                          join module in _dbcontext.AclModules on subModule.ModuleId equals module.Id
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
                        tmpRouteNames = permissionList.Select(q => q.PageRouteName).ToHashSet();
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

    }
}
