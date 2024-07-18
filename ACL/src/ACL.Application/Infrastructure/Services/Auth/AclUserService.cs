using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Auth;
using ACL.Application.Domain.Ports.Repositories.Auth;
using ACL.Application.Domain.Ports.Services.Auth;
using ACL.Application.Domain.Ports.Services.Cryptography;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Persistence.Repositories.Auth;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using SharedKernel.Contracts.Response;


namespace ACL.Application.Infrastructure.Services.Auth
{
    public class AclUserService : AclUserRepository, IAclUserService
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
        public new IAclUserUserGroupRepository AclUserUserGroupRepository;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618
        private static IHttpContextAccessor _httpContextAccessor;
        // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618
        private readonly ApplicationDbContext _dbContext;

        public AclUserService(ApplicationDbContext dbContext, IConfiguration config, IDistributedCache distributedCache, ICryptographyService cryptographyService, IAclUserUserGroupRepository aclUserUserGroupRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, config, distributedCache, cryptographyService, aclUserUserGroupRepository, httpContextAccessor)
        {
            AclUserUserGroupRepository = aclUserUserGroupRepository;
            _config = config;
            AclResponse = new AclResponse();
            var user = _httpContextAccessor?.HttpContext?.User;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
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
                AclResponse.Message = MessageResponse.fetchMessage;
            }
            AclResponse.Data = result;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            AclResponse.Timestamp = DateTime.Now;

            return AclResponse;
        }
        /// <inheritdoc/>
        public Task<AclResponse> AddUser(AclUserRequest request)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();

            try
            {
                strategy.Execute(() =>
               {
                   var transaction = _dbContext.Database.BeginTransaction();
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
                           AclResponse.Data = aclUser;
                       }

                       AclResponse.Message = MessageResponse.createMessage;
                       AclResponse.StatusCode = AppStatusCode.SUCCESS;

                       transaction.CommitAsync();
                   }
                   catch (Exception ex)
                   {
                       transaction?.RollbackAsync();
                       AclResponse.Message = ex.Message;
                       AclResponse.StatusCode = AppStatusCode.FAIL;
                   }

               });
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }

            AclResponse.Timestamp = DateTime.Now;
            return Task.FromResult(AclResponse);
        }

        /// <inheritdoc/>
        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            AclUser? aclUser = Find(id);
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(() =>
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
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
                            //    AclResponse.Data = aclUser;
                            //}
                            AclResponse.Message = MessageResponse.editMessage;
                            AclResponse.StatusCode = AppStatusCode.SUCCESS;

                            List<ulong> users = new List<ulong> { aclUser.Id };
                            UpdateUserPermissionVersion(users);
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            AclResponse.Message = MessageResponse.notFoundMessage;
                            AclResponse.StatusCode = AppStatusCode.FAIL;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        AclResponse.Message = ex.Message;
                        AclResponse.StatusCode = AppStatusCode.FAIL;
                    }
                }

                return Task.CompletedTask;
            });
            if (aclUser == null)
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
            }
            else
            {
                aclUser.Password = "***********";
                aclUser.Salt = "***********";
                aclUser.Claims = null;
                AclResponse.Message = MessageResponse.editMessage;
                AclResponse.Data = aclUser;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }

        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclUser? aclUser = Find(id);
                if (aclUser == null)
                {
                    AclResponse.Message = MessageResponse.notFoundMessage;
                }
                else
                {
                    aclUser.Password = "***********";
                    aclUser.Salt = "***********";
                    aclUser.Claims = null;
                    AclResponse.Message = MessageResponse.fetchMessage;
                    AclResponse.Data = aclUser;
                }
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }

            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            AclUser? aclUser = Find(id);
            if (aclUser != null)
            {
                Delete(aclUser);
                // delete all item for user user group
                AclUserUsergroup[]? userUserGroups = AclUserUserGroupRepository?.Where(id)?.ToArray();
                if (userUserGroups?.Count() > 0)
                {
                    AclUserUserGroupRepository?.RemoveRange(userUserGroups);
                }

                AclResponse.Message = MessageResponse.deleteMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return AclResponse;
        }

        public AclUser PrepareInputData(AclUserRequest request, AclUser? aclUser = null)
        {
            var salt = _cryptographyService.GenerateSalt();
            if (aclUser == null)
            {

                if (IsAclUserEmailExist(request.Email))
                {
                    throw new InvalidOperationException("Email already exist");
                }
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
                    CompanyId = (_companyId != 0) ? _companyId : (uint)AppAuth.GetAuthInfo().CompanyId,
                    UserType = (_companyId == 0) ? uint.Parse(_config["USER_TYPE_S_ADMIN"]) : uint.Parse(_config["USER_TYPE_USER"]),
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
                aclUser.CompanyId = (_companyId != 0) ? _companyId : (uint)AppAuth.GetAuthInfo().CompanyId;
                aclUser.UserType = (_userType != 0) ? _userType : (uint)AppAuth.GetAuthInfo().UserType;
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

    }
}
