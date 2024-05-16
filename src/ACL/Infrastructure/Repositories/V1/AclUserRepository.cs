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
using ACL.Infrastructure.Repositories.GenericRepository;
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
    public class AclUserRepository : GenericRepository<AclUser>, IAclUserRepository
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
        public AclUserRepository(ApplicationDbContext dbcontext,IConfiguration config,IDistributedCache distributedCache) : base(dbcontext)
        {
            AppAuth.SetAuthInfo();
            this._config = config;
            this.aclResponse = new AclResponse();
            this._companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
            this._userType = (uint)AppAuth.GetAuthInfo().UserType;
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclUser = await base.All();
            List<AclUser> re = (aclUser != null) ? aclUser.ToList():new List<AclUser>();
            re.ForEach(user =>
            {
                user.Password = "**********";
                user.Salt = "**********";
                user.Claims = null;
                user.RefreshToken = null;
            });
            aclUser =re;
            var result = (aclUser != null) ? aclUser.Where(i => i.Id != 1 && i.Status == 1 ) : null; // further we need to add with companyid from auth and created by  from UTHUSER ID other wise the system would be insecured.

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

            var executionStrategy = base.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await base.BeginTransactionAsync())
                {
                    try
                    {
                        var aclUser = PrepareInputData(request);
                        await base.AddAsync(aclUser);
                        await base.CompleteAsync();
                        await base.ReloadAsync(aclUser);

                        //  need to insert user user group
                        var userGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                        await base._dbContext.AddRangeAsync(userGroupPrepareData);
                        await base.CompleteAsync();
                        aclUser.Password = "******************"; //request.Password
                        aclUser.Salt = "******************";
                        aclUser.Claims = null;
                        aclUser.RefreshToken = null;
                        this.aclResponse.Data = aclUser;
                        this.aclResponse.Message = this.messageResponse.createMessage;
                        this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        this.aclResponse.Message = ex.Message;
                        this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    }
                }
            });

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }


        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            try
            {
                AclUser aclUser = await base.GetById(id);

                if (aclUser != null)
                {
                    aclUser = PrepareInputData(request, aclUser);
                    base.Update(aclUser);
                    base.Complete();
                    await base.ReloadAsync(aclUser);

                    // first delete all user user group
                    var UserUserGroups = AclUserUserGroupRepository.Where(x => x.UserId == id).ToArray();
                    await AclUserUserGroupRepository.RemoveRange(UserUserGroups);
                    base.Complete();

                    // need to insert user user group
                    var UserGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                    await AclUserUserGroupRepository.AddRange(UserGroupPrepareData);
                    base.Complete();
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
                var aclUser = await base.GetById(id);
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
            return await base._dbContext.AclUsers.FirstOrDefaultAsync(m => m.Email == email);

        }

        public async Task<AclUser?> FindByIdAsync(ulong id)
        {
            return await base._dbContext.AclUsers.FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<AclResponse> DeleteById(ulong id)
        {
            AclUser? aclUser = await base.GetById(id);

            if (aclUser != null)
            {
                await base.DeleteAsync(aclUser);
                base.Complete();

                // delete all item for user user group
                var UserUserGroups = base._dbContext.AclUserUsergroups.Where(x => x.UserId == id).ToArray();
                base._dbContext.RemoveRange(UserUserGroups);
                base.Complete();


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
                AclUser.Claims = AclUser.Claims??new Core.Claim[] { };
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
            await this._dbContext.AddAsync(entity);
            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<AclUser> UpdateAndSaveAsync(AclUser entity)
        {
            this._dbContext.Update(entity);
            await this._dbContext.SaveChangesAsync();
            
            return entity;
        } 
        public async Task<AclUser?> GetUserWithPermissionAsync(uint userId) 
        { 
            HashSet<string>? routeNames = new HashSet<string>();
            
            var user = await this.FindByIdAsync(userId);

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
                    tmpRouteNames = JsonConvert.DeserializeObject<HashSet<string>>(cachedRouteNames);
                    routeNames.UnionWith(tmpRouteNames);
                }
                
                if(tmpRouteNames.IsNullOrEmpty()){
                    var permissionList = (from rolePage in this._dbContext.AclRolePages
                        join page in this._dbContext.AclPages on rolePage.PageId equals page.Id
                        join pageRoute in this._dbContext.AclPageRoutes on page.Id equals pageRoute.PageId
                        join subModule in this._dbContext.AclSubModules on page.SubModuleId equals subModule.Id
                        join module in this._dbContext.AclModules on subModule.ModuleId equals module.Id
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
