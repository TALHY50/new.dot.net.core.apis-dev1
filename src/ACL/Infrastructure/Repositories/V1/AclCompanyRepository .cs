using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclCompanyRepository : GenericRepository<AclCompany>, IAclCompanyRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company";
        private IConfiguration _config;
        private ICryptographyService cryptographyService;
        private IAclUserGroupRepository AclUserGroupRepository;
        private IAclUserRepository AclUserRepository;
        private IAclUserUserGroupRepository AclUserUserGroupRepository;
        private IAclRoleRepository AclRoleRepository;
        private IAclUserGroupRoleRepository AclUserGroupRoleRepository;
        private IAclPageRepository AclPageRepository;
        private IAclRolePageRepository AclRolePageRepository;


        public AclCompanyRepository(ApplicationDbContext dbContext, IConfiguration config) : base(dbContext)
        {
            this.aclResponse = new AclResponse();
            this._config = config;
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclCompany = await base.Where(b => b.Status == 1).ToListAsync();
            if (aclCompany.Any())
            {

                this.aclResponse.Data = aclCompany;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            this.aclResponse.Message = aclCompany != null ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }

        public async Task<AclResponse> AddAclCompany(AclCompanyCreateRequest request)
        {
            try
            {
                var aclCompany = PrepareInputData(request);
                var executionStrategy = base.CreateExecutionStrategy();

                await executionStrategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await base.BeginTransactionAsync())
                    {
                        try
                        {
                            var aclCompany = PrepareInputData(request);
                            await base.AddAsync(aclCompany);
                            await base.CompleteAsync();
                            await base.ReloadAsync(aclCompany);

                            if (aclCompany.Id != 0)
                            {
                                AclUserGroupRequest userGroupRequest = new AclUserGroupRequest()
                                {
                                    GroupName = this._config["USER_GROUP_NAME"],
                                    Status = 1
                                };
                                AclUserGroupRepository.SetCompanyId(aclCompany.Id);
                                var userGroup = await AclUserGroupRepository.AddUserGroup(userGroupRequest);
                                await base.CompleteAsync();
                                var createdUserGroup = (AclUsergroup)userGroup.Data;
                                await AclUserGroupRepository.ReloadAsync(createdUserGroup);

                                var salt = cryptographyService.GenerateSalt();
                                string[] nameArr = request.Name.Split(' ');
                                string fname = (nameArr.Length > 0) ? nameArr[0] : "";
                                string lname = (nameArr.Length > 1) ? nameArr[1] : fname;
                                AclUser user = new AclUser()
                                {
                                    Email = aclCompany.Email,
                                    Password = (request.Password != null && request.Password.Length != 88) ? cryptographyService.HashPassword(request.Password, salt) : request.Password,
                                    UserType = AclUserRepository.SetUserType(true),
                                    FirstName = fname,
                                    LastName = lname,
                                    Language = "en-US",
                                    Username = aclCompany.Email,
                                    CreatedById = 0,
                                    Salt = salt,
                                    Claims = new Core.Claim[] { },
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now
                                };

                                AclUserRepository.SetCompanyId((uint)aclCompany.Id);
                                AclUserRepository.SetUserType(true);
                                AclUserRepository.Add(user);
                                await base.CompleteAsync();
                                await AclUserRepository.ReloadAsync(user);
                                var userusergroup = PrepareDataForUserUserGroups(createdUserGroup.Id, user.Id);
                                AclUserUserGroupRepository.Add(userusergroup);
                                await base.CompleteAsync();

                                AclRole role = new AclRole()
                                {
                                    Name = aclCompany.Name,
                                    Title = this._config["ROLE_TITLE"],
                                    CompanyId = (uint)aclCompany.Id,
                                    CreatedById = 0,
                                    UpdatedById = 0,
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now,
                                    Status = 1
                                };
                                var roleAdd = await AclRoleRepository.AddAsync(role);
                                await base.CompleteAsync();
                                await AclRoleRepository.ReloadAsync(role);

                                AclUsergroupRole userGroupRole = new AclUsergroupRole()
                                {
                                    UsergroupId = aclCompany.Id,
                                    RoleId = role.Id,
                                    CompanyId = aclCompany.Id,
                                    CreatedAt = DateTime.UtcNow,
                                    UpdatedAt = DateTime.UtcNow
                                };
                                var createdUserGroupRole = AclUserGroupRoleRepository.Add(userGroupRole);
                                await base.CompleteAsync();
                                List<AclPage> aclPagesByModuleId = await AclPageRepository.Where(x => x.ModuleId == ulong.Parse(this._config["S_ADMIN_DEFAULT_MODULE_ID"])).ToListAsync();
                                List<ulong> pageIds = aclPagesByModuleId.Select(page => page.Id).ToList();
                                List<AclRolePage> aclRolePages = pageIds.Select(pageId => new AclRolePage
                                {
                                    RoleId = role.Id,
                                    PageId = pageId,
                                    CreatedAt = DateTime.UtcNow,
                                    UpdatedAt = DateTime.UtcNow
                                }).ToList();
                                await AclRolePageRepository.AddRange(aclRolePages.ToArray());
                                await base.CompleteAsync();
                            }

                            this.aclResponse.Data = aclCompany;

                            this.aclResponse.Message = aclCompany != null ? this.messageResponse.createMessage : this.messageResponse.notFoundMessage;

                            this.aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;

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
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> EditAclCompany(ulong Id, AclCompanyEditRequest request)
        {
            try
            {
                var _aclCompany = await base.GetById(Id);
                _aclCompany = PrepareInputData(null, request, _aclCompany);
                await base.UpdateAsync(_aclCompany);
                await base.CompleteAsync();
                await base.ReloadAsync(_aclCompany);
                this.aclResponse.Data = _aclCompany;
                this.aclResponse.Message = _aclCompany != null ? this.messageResponse.editMessage : this.messageResponse.notFoundMessage;

                this.aclResponse.StatusCode = _aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
            var aclResponse = new AclResponse();

            try
            {
                var aclCompany = await base.GetById(id);

                aclResponse.Data = aclCompany;
                aclResponse.Message = aclCompany != null ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
                aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> DeleteCompany(ulong id)
        {

            var aclCompany = await base.GetById(id);

            if (aclCompany != null)
            {
                aclCompany.Status = 0;
                await base.UpdateAsync(aclCompany);
                await base.CompleteAsync();
                this.aclResponse.Data = aclCompany;
            }
            this.aclResponse.Message = aclCompany != null ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }

        public AclCompany PrepareInputData(AclCompanyCreateRequest requ = null, AclCompanyEditRequest req = null, AclCompany _aclCompany = null)
        {
            AclCompany aclCompany = _aclCompany == null ? new AclCompany() : _aclCompany;
            if (requ == null && req != null)
            {
                aclCompany.Name = req.Name;
                aclCompany.Cname = req.Cname;
                aclCompany.Cemail = req.Cemail;
                aclCompany.Address1 = req.Address1;
                aclCompany.Address2 = req.Address2;
                aclCompany.Postcode = req.PostCode;
                aclCompany.Phone = req.Phone;
                aclCompany.Fax = req.Fax;
                aclCompany.City = req.City;
                aclCompany.State = req.State;
                aclCompany.Country = req.Country;
                aclCompany.Logo = req.Logo;
                aclCompany.RegistrationNo = req.RegistrationNo;
                aclCompany.Timezone = req.Timezone;
                aclCompany.TimezoneValue = req.TimezoneValue;
                aclCompany.TaxNo = req.TaxNo;
                aclCompany.Status = req.Status;
            }
            if (requ != null && req == null)
            {
                aclCompany.Name = requ.Name;
                aclCompany.Cname = requ.Cname;
                aclCompany.Cemail = requ.Cemail;
                aclCompany.Address1 = requ.Address1;
                aclCompany.Address2 = requ.Address2;
                aclCompany.Postcode = requ.PostCode;
                aclCompany.Phone = requ.Phone;
                aclCompany.Email = requ.Email;
                aclCompany.Fax = requ.Fax;
                aclCompany.City = requ.City;
                aclCompany.State = requ.State;
                aclCompany.Country = requ.Country;
                aclCompany.Logo = requ.Logo;
                aclCompany.RegistrationNo = requ.RegistrationNo;
                aclCompany.Timezone = requ.Timezone;
                aclCompany.TimezoneValue = requ.TimeZoneValue;
                aclCompany.TaxNo = requ.TaxNo;
                aclCompany.UniqueColumnName = requ.UniqueColumnName;
            }
            aclCompany.UpdatedAt = DateTime.Now;
            if (aclCompany.Id == 0)
            {
                aclCompany.CreatedAt = DateTime.Now;
            }
            aclCompany.AddedBy = GetAuthUserId(); //to do get user id from auth
            return aclCompany;
        }

        private int GetAuthUserId()
        {
            return (int)AppAuth.GetAuthInfo().UserId;
        }

        public AclUserUsergroup PrepareDataForUserUserGroups(ulong usergroup, ulong user_id)
        {
            AclUserUsergroup aclUserUserGroup = new AclUserUsergroup();
            aclUserUserGroup.UserId = user_id;
            aclUserUserGroup.UsergroupId = usergroup;
            aclUserUserGroup.CreatedAt = DateTime.Now;
            aclUserUserGroup.UpdatedAt = DateTime.Now;
            return aclUserUserGroup;
        }
    }
}
