using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Module;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Role;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.UserGroup;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Auth;
using SharedKernel.Main.Domain.ACL.Domain.Company;
using SharedKernel.Main.Domain.ACL.Domain.Module;
using SharedKernel.Main.Domain.ACL.Domain.Role;
using SharedKernel.Main.Domain.ACL.Domain.UserGroup;
using SharedKernel.Main.Domain.ACL.Services.UserGroup;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Company;

namespace SharedKernel.Main.Domain.ACL.Services.Company
{
    public class AclCompanyService : AclCompanyRepository, IAclCompanyService
    {
        /// <inheritdoc/>
        public new AclResponse AclResponse;
        /// <inheritdoc/>
        public new MessageResponse MessageResponse;
        private readonly string _modelName = "Company";
        private readonly IConfiguration _config;
        private readonly ICryptographyService _cryptographyService;
        private readonly IAclUserGroupService _aclUserGroupService;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly IAclUserUserGroupRepository _aclUserUserGroupRepository;
        private readonly IAclRoleRepository _aclRoleRepository;
        private readonly IAclUserGroupRoleRepository _aclUserGroupRoleRepository;
        private readonly IAclPageRepository _aclPageRepository;
        private readonly IAclRolePageRepository _aclRolePageRepository;
        public new static IHttpContextAccessor HttpContextAccessor;

        private readonly AclApplicationDbContext _dbContext;


        /// <inheritdoc/>
        public AclCompanyService(AclApplicationDbContext dbContext, IConfiguration config, ICryptographyService cryptographyService, IAclUserGroupService aclUserGroupRepository, IAclUserRepository aclUserRepository, IAclUserUserGroupRepository aclUserUserGroupRepository, IAclRoleRepository aclRoleRepository, IAclUserGroupRoleRepository aclUserGroupRoleRepository, IAclPageRepository aclPageRepository, IAclRolePageRepository aclRolePageRepository, IHttpContextAccessor httpContextAccessor):base(dbContext,httpContextAccessor)

        {
            this.AclResponse = new AclResponse();
            this._config = config;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            this._dbContext = dbContext;
            this._cryptographyService = cryptographyService;
            this._aclUserGroupService = aclUserGroupRepository;
            this._aclUserRepository = aclUserRepository;
            this._aclUserUserGroupRepository = aclUserUserGroupRepository;
            this._aclRoleRepository = aclRoleRepository;
            this._aclUserGroupRoleRepository = aclUserGroupRoleRepository;
            this._aclPageRepository = aclPageRepository;
            this._aclRolePageRepository = aclRolePageRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        /// <inheritdoc/>

        public AclResponse GetAll()
        {
            List<AclCompany>? aclCompany = this._dbContext.AclCompanies.Where(b => b.Status == 1).ToList();
            if (aclCompany.Any())
            {
                this.AclResponse.Data = aclCompany;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
            }
            else
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }

            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }

        /// <inheritdoc/>
        public async Task<AclResponse> AddAclCompany(AclCompanyCreateRequest request)
        {
            try
            {
                AclCompany? aclCompany = PrepareInputData(request);
                aclCompany = Add(aclCompany);
                if (aclCompany != null && aclCompany.Id != 0)
                {
                    AclUserGroupRequest userGroupRequest = new AclUserGroupRequest()
                    {
                        GroupName = this._config["USER_GROUP_NAME"] ?? "ADMIN_USERGROUP",
                        Status = 1
                    };
                    this._aclUserGroupService.SetCompanyId(aclCompany.Id);
                    var userGroup = this._aclUserGroupService.PrepareInputData(userGroupRequest);
                    userGroup.CompanyId = aclCompany.Id;
                    userGroup = this._aclUserGroupService.Add(userGroup);
                    var salt = this._cryptographyService.GenerateSalt();
                    string[] nameArr = request.Name.Split(' ');
                    string firstName = (nameArr.Length > 0) ? nameArr[0] : "";
                    string lname = (nameArr.Length > 1) ? nameArr[1] : firstName;
                    AclUser user = new AclUser()
                    {
                        Email = aclCompany.Email,
                        Password = (request.Password != null && request.Password.Length != 88) ? this._cryptographyService.HashPassword(request.Password, salt) : request.Password,
                        UserType = this._aclUserRepository.SetUserType(true),
                        FirstName = firstName,
                        LastName = lname,
                        Language = "en-US",
                        Username = aclCompany.Email,
                        CreatedById = (uint)AppAuth.GetAuthInfo().UserId,
                        CompanyId = (uint)aclCompany.Id,
                        Salt = salt,
                        Claims = new Claim[] { },
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    var aclUser = this._aclUserRepository.Add(user);
                    var aclUserUserGroup = PrepareDataForUserUserGroups(userGroup?.Id, aclUser?.Id);
                    this._aclUserUserGroupRepository.Add(aclUserUserGroup);
                    AclRole role = new AclRole()
                    {
                        Name = this._config["ROLE_TITLE"] ?? "ADMIN_ROLE",
                        Title = this._config["ROLE_TITLE"] ?? "ADMIN_ROLE",
                        CompanyId = (uint)aclCompany.Id,
                        CreatedById = (uint)AppAuth.GetAuthInfo().UserId,
                        UpdatedById = (uint)AppAuth.GetAuthInfo().UserId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Status = 1
                    };
                    var roleAdd = this._aclRoleRepository.Add(role);

                    AclUsergroupRole userGroupRole = new AclUsergroupRole()
                    {
                        UsergroupId = aclCompany.Id,
                        RoleId = (roleAdd?.Id) ?? 0,
                        CompanyId = aclCompany.Id,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    var createdUserGroupRole = this._aclUserGroupRoleRepository.Add(userGroupRole);
                    List<AclPage> aclPagesByModuleId = await this._dbContext.AclPages.Where(x => x.ModuleId == ulong.Parse(this._config["S_ADMIN_DEFAULT_MODULE_ID"] ?? "1003")).ToListAsync();
                    List<ulong> pageIds = aclPagesByModuleId.Select(page => page.Id).ToList();
                    List<AclRolePage> aclRolePages = pageIds.Select(pageId => new AclRolePage
                    {
                        RoleId = role.Id,
                        PageId = pageId,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToList();
                    this._aclRolePageRepository.AddAll(aclRolePages.ToArray());
                }
                this.AclResponse.Data = aclCompany;
                this.AclResponse.Message = aclCompany != null ? this.MessageResponse.createMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
        public AclResponse EditAclCompany(ulong id, AclCompanyEditRequest request)
        {
            try
            {
                AclCompany? aclCompany = Find(id);
                if (aclCompany == null)
                {
                    throw new Exception("Company not exist");
                }

                aclCompany = PrepareInputData(null, request, aclCompany);
                aclCompany = Update(aclCompany);
                this.AclResponse.Data = aclCompany;
                this.AclResponse.Message = aclCompany != null ? this.MessageResponse.editMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclCompany? aclCompany = Find(id);
                this.AclResponse.Data = aclCompany;
                this.AclResponse.Message = aclCompany != null ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
        public AclResponse DeleteCompany(ulong id)
        {

            AclCompany? aclCompany = Find(id);

            if (aclCompany != null)
            {
                aclCompany.Status = 0;
                this.AclResponse.Data = base.Update(aclCompany);;
            }
            this.AclResponse.Message = aclCompany != null ? this.MessageResponse.DeleteMessage : this.MessageResponse.notFoundMessage;
            this.AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }

        /// <inheritdoc/>
        public AclCompany PrepareInputData(AclCompanyCreateRequest? request = null, AclCompanyEditRequest? editRequest = null, AclCompany? company = null)
        {
            AclCompany aclCompany = company ?? new AclCompany();

            if (request == null && editRequest != null)
            {
                bool isvalid = IsCompanyNameUnique(editRequest.Name, company.Id);
                if (isvalid)
                {
                    throw new Exception("Company name is Not Unique");
                }
                aclCompany.Name = editRequest.Name;
                aclCompany.Cname = editRequest.Cname;
                aclCompany.Cemail = editRequest.Cemail;
                aclCompany.Address1 = editRequest.Address1;
                aclCompany.Address2 = editRequest.Address2;
                aclCompany.Postcode = editRequest.PostCode;
                aclCompany.Phone = editRequest.Phone;
                aclCompany.Fax = editRequest.Fax;
                aclCompany.City = editRequest.City;
                aclCompany.State = editRequest.State;
                aclCompany.Country = editRequest.Country;
                aclCompany.Logo = editRequest.Logo;
                aclCompany.RegistrationNo = editRequest.RegistrationNo;
                aclCompany.Timezone = editRequest.Timezone;
                aclCompany.TimezoneValue = editRequest.TimezoneValue;
                aclCompany.TaxNo = editRequest.TaxNo;
                aclCompany.Status = editRequest.Status;
            }
            if (request != null && editRequest == null)
            {
                bool isvalid = IsCompanyNameUnique(request.Name);
                if (isvalid)
                {
                    throw new Exception("Company name is Not Unique");
                }

                var isAlreadyExist = this._aclUserRepository.FindByEmail(request.Email);
                if (isAlreadyExist != null)
                {
                    throw new Exception("Email is Not Unique");
                }
                aclCompany.Name = request.Name;
                aclCompany.Cname = request.Cname;
                aclCompany.Cemail = request.Cemail;
                aclCompany.Address1 = request.Address1;
                aclCompany.Address2 = request.Address2;
                aclCompany.Postcode = request.PostCode;
                aclCompany.Phone = request.Phone;
                aclCompany.Email = request.Email;
                aclCompany.Fax = request.Fax;
                aclCompany.City = request.City;
                aclCompany.State = request.State;
                aclCompany.Country = request.Country;
                aclCompany.Logo = request.Logo;
                aclCompany.RegistrationNo = request.RegistrationNo;
                aclCompany.Timezone = request.Timezone;
                aclCompany.TimezoneValue = request.TimeZoneValue;
                aclCompany.TaxNo = request.TaxNo;
                aclCompany.UniqueColumnName = request.UniqueColumnName;
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
    }
}
