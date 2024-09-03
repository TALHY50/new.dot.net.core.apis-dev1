using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Domain.Services
{
    public class UserService : UserRepository, IUserService
    {
        public ScopeResponse ScopeResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "User";
        private uint _companyId;
        private uint _userType;
        //   private bool _isUserTypeCreatedByCompany = false;
        private readonly IConfiguration _config;
        private readonly IDistributedCache _distributedCache;
        private readonly ICryptography _cryptography;
        public new IUserUserGroupRepository UserUserGroupRepository;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618
        private static IHttpContextAccessor _httpContextAccessor;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext, IConfiguration config, IDistributedCache distributedCache, ICryptography cryptography, IUserUserGroupRepository userUserGroupRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, config, distributedCache, cryptography, userUserGroupRepository, httpContextAccessor)
        {
            this.UserUserGroupRepository = userUserGroupRepository;
            this._config = config;
            this.ScopeResponse = new ScopeResponse();
            var user = _httpContextAccessor?.HttpContext?.User;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
            this._dbContext = dbContext;
            this._cryptography = cryptography;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
            this._companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
#pragma warning disable CS8629 // Nullable value type may be null.
            this._userType = (uint)AppAuth.GetAuthInfo().UserType;
#pragma warning restore CS8629 // Nullable value type may be null.
        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            List<User>? aclUser = All()?.Where(u => this._companyId == 0 || (u.CompanyId == this._companyId && u.CreatedById == this._companyId))?.ToList();
            aclUser?.ForEach(user =>
           {
               user.Password = "**********";
               user.Salt = "**********";
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
               user.Claims = null;
               user.RefreshToken = null;
           });

            // further we need to add with companyid from auth and created by  from UTHUSER ID other wise the system would be insecured.
            IEnumerable<User>? result = aclUser.Where(i => i.Id != 1 && i.Status == 1);
            if (aclUser.Any())
            {
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ScopeResponse.Data = result;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public Task<ScopeResponse> AddUser(AclUserRequest request)
        {
            var strategy = this._dbContext.Database.CreateExecutionStrategy();

            try
            {
                strategy.Execute(() =>
               {
                   var transaction = this._dbContext.Database.BeginTransaction();
                   try
                   {
                       User? aclUser = PrepareInputData(request);
                       aclUser = Add(aclUser);

                       // Need to insert user user group
                       UserUsergroup[] userUserGroups = PrepareDataForUserUserGroups(request, aclUser?.Id);
                       this._dbContext.AclUserUsergroups.AddRange(userUserGroups);
                       ReloadEntities(userUserGroups);

                       if (aclUser != null)
                       {
                           aclUser.Password = "******************"; // request.Password
                           aclUser.Salt = "******************";
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                           aclUser.Claims = null;
                           aclUser.RefreshToken = null;
                           this.ScopeResponse.Data = aclUser;
                       }

                       this.ScopeResponse.Message = this.MessageResponse.createMessage;
                       this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

                       transaction.CommitAsync();
                   }
                   catch (Exception ex)
                   {
                       transaction?.RollbackAsync();
                       this.ScopeResponse.Message = ex.Message;
                       this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                   }

               });
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }

            this.ScopeResponse.Timestamp = DateTime.Now;
            return Task.FromResult(this.ScopeResponse);
        }

        /// <inheritdoc/>
        public async Task<ScopeResponse> Edit(uint id, AclUserRequest request)
        {
            User? aclUser = Find(id);
            var strategy = this._dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(() =>
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = this._dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (aclUser != null)
                        {
                            aclUser = PrepareInputData(request, aclUser);
                            aclUser = Update(aclUser);
                            // first delete all user user group
                            UserUsergroup[] userUserGroups = this.UserUserGroupRepository.Where(id).ToArray();
                            this.UserUserGroupRepository.RemoveRange(userUserGroups);
                            // need to insert user user group
                            UserUsergroup[]? userGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser?.Id);
                            this.UserUserGroupRepository.AddRange(userGroupPrepareData);
                            //if (aclUser != null)
                            //{
                            //    aclUser.Password = "******************"; //request.Password
                            //    aclUser.Salt = "******************";
                            //    aclUser.Claims = null;
                            //    ScopeResponse.Data = aclUser;
                            //}
                            this.ScopeResponse.Message = this.MessageResponse.editMessage;
                            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

                            List<uint> users = new List<uint> { aclUser.Id };
                            UpdateUserPermissionVersion(users);
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                            this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        this.ScopeResponse.Message = ex.Message;
                        this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                    }
                }

                return Task.CompletedTask;
            });
            if (aclUser == null)
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
            }
            else
            {
                aclUser.Password = "***********";
                aclUser.Salt = "***********";
                aclUser.Claims = null;
                this.ScopeResponse.Message = this.MessageResponse.editMessage;
                this.ScopeResponse.Data = aclUser;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }

        /// <inheritdoc/>
        public ScopeResponse FindById(uint id)
        {
            try
            {
                User? aclUser = Find(id);
                if (aclUser == null)
                {
                    this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                }
                else
                {
                    aclUser.Password = "***********";
                    aclUser.Salt = "***********";
                    aclUser.Claims = null;
                    this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
                    this.ScopeResponse.Data = aclUser;
                }
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }

            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse DeleteById(uint id)
        {
            User? aclUser = Find(id);
            if (aclUser != null)
            {
                Delete(aclUser);
                // delete all item for user user group
                UserUsergroup[]? userUserGroups = this.UserUserGroupRepository?.Where(id)?.ToArray();
                if (userUserGroups?.Count() > 0)
                {
                    this.UserUserGroupRepository?.RemoveRange(userUserGroups);
                }

                this.ScopeResponse.Message = this.MessageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            return this.ScopeResponse;
        }

        public User PrepareInputData(AclUserRequest request, User? aclUser = null)
        {
            var salt = this._cryptography.GenerateSalt();
            if (aclUser == null)
            {

                if (IsAclUserEmailExist(request.Email))
                {
                    throw new InvalidOperationException("Email already exist");
                }
                return new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = this._cryptography.HashPassword(request.Password, salt),
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
                if (IsAclUserEmailExist(request.Email, aclUser.Id))
                {
                    throw new InvalidOperationException("Email already exist");
                }
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
        public UserUsergroup[] PrepareDataForUserUserGroups(AclUserRequest request, uint? user_id)
        {
            IList<UserUsergroup> res = new List<UserUsergroup>();

            foreach (uint user_group in request.UserGroup)
            {
                UserUsergroup userUserGroup = new UserUsergroup();
                userUserGroup.UserId = user_id ?? 0;
                userUserGroup.UsergroupId = user_group;
                userUserGroup.CreatedAt = DateTime.Now;
                userUserGroup.UpdatedAt = DateTime.Now;
                res.Add(userUserGroup);
            }
            return res.ToArray();
        }

    }
}
