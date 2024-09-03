using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Domain.Services
{
    public class CompanyService : CompanyRepository, ICompanyService
    {
        /// <inheritdoc/>
        public new ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public new MessageResponse MessageResponse;
        private readonly string _modelName = "Company";
        private readonly IConfiguration _config;
        private readonly ICryptography _cryptography;
        private readonly IUserGroupService _userGroupService;
        private readonly IUserRepository _userRepository;
        private readonly IUserUserGroupRepository _userUserGroupRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserGroupRoleRepository _userGroupRoleRepository;
        private readonly IPageRepository _pageRepository;
        private readonly IRolePageRepository _rolePageRepository;
        public new static IHttpContextAccessor HttpContextAccessor;

        private readonly ApplicationDbContext _dbContext;


        /// <inheritdoc/>
        public CompanyService(ApplicationDbContext dbContext, IConfiguration config, ICryptography cryptography, IUserGroupService userGroupRepository, IUserRepository userRepository, IUserUserGroupRepository userUserGroupRepository, IRoleRepository roleRepository, IUserGroupRoleRepository userGroupRoleRepository, IPageRepository pageRepository, IRolePageRepository rolePageRepository, IHttpContextAccessor httpContextAccessor):base(dbContext,httpContextAccessor)

        {
            this.ScopeResponse = new ScopeResponse();
            this._config = config;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            this._dbContext = dbContext;
            this._cryptography = cryptography;
            this._userGroupService = userGroupRepository;
            this._userRepository = userRepository;
            this._userUserGroupRepository = userUserGroupRepository;
            this._roleRepository = roleRepository;
            this._userGroupRoleRepository = userGroupRoleRepository;
            this._pageRepository = pageRepository;
            this._rolePageRepository = rolePageRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        /// <inheritdoc/>

        public ScopeResponse GetAll()
        {
            List<Company>? aclCompany = this._dbContext.Companies.Where(b => b.Status == 1).ToList();
            if (aclCompany.Any())
            {
                this.ScopeResponse.Data = aclCompany;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            }
            else
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }

            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }

        /// <inheritdoc/>
        public async Task<ScopeResponse> AddAclCompany(AclCompanyCreateRequest request)
        {
            try
            {
                Company? aclCompany = PrepareInputData(request);
                aclCompany = Add(aclCompany);
                if (aclCompany != null && aclCompany.Id != 0)
                {
                    AclUserGroupRequest userGroupRequest = new AclUserGroupRequest()
                    {
                        GroupName = this._config["USER_GROUP_NAME"] ?? "ADMIN_USERGROUP",
                        Status = 1
                    };
                    this._userGroupService.SetCompanyId(aclCompany.Id);
                    var userGroup = this._userGroupService.PrepareInputData(userGroupRequest);
                    userGroup.CompanyId = aclCompany.Id;
                    userGroup = this._userGroupService.Add(userGroup);
                    var salt = this._cryptography.GenerateSalt();
                    string[] nameArr = request.Name.Split(' ');
                    string firstName = (nameArr.Length > 0) ? nameArr[0] : "";
                    string lname = (nameArr.Length > 1) ? nameArr[1] : firstName;
                    User user = new User()
                    {
                        Email = aclCompany.Email,
                        Password = (request.Password != null && request.Password.Length != 88) ? this._cryptography.HashPassword(request.Password, salt) : request.Password,
                        UserType = this._userRepository.SetUserType(true),
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
                    var aclUser = this._userRepository.Add(user);
                    var aclUserUserGroup = PrepareDataForUserUserGroups(userGroup?.Id, aclUser?.Id);
                    this._userUserGroupRepository.Add(aclUserUserGroup);
                    Role role = new Role()
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
                    var roleAdd = this._roleRepository.Add(role);

                    UsergroupRole userGroupRole = new UsergroupRole()
                    {
                        UsergroupId = aclCompany.Id,
                        RoleId = (roleAdd?.Id) ?? 0,
                        CompanyId = aclCompany.Id,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    var createdUserGroupRole = this._userGroupRoleRepository.Add(userGroupRole);
                    List<Page> aclPagesByModuleId = await this._dbContext.AclPages.Where(x => x.ModuleId == uint.Parse(this._config["S_ADMIN_DEFAULT_MODULE_ID"] ?? "1003")).ToListAsync();
                    List<uint> pageIds = aclPagesByModuleId.Select(page => page.Id).ToList();
                    List<RolePage> aclRolePages = pageIds.Select(pageId => new RolePage
                    {
                        RoleId = role.Id,
                        PageId = pageId,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToList();
                    this._rolePageRepository.AddAll(aclRolePages.ToArray());
                }
                this.ScopeResponse.Data = aclCompany;
                this.ScopeResponse.Message = aclCompany != null ? this.MessageResponse.createMessage : this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = aclCompany != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
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
        public ScopeResponse EditAclCompany(uint id, AclCompanyEditRequest request)
        {
            try
            {
                Company? aclCompany = Find(id);
                if (aclCompany == null)
                {
                    throw new Exception("Company not exist");
                }

                aclCompany = PrepareInputData(null, request, aclCompany);
                aclCompany = Update(aclCompany);
                this.ScopeResponse.Data = aclCompany;
                this.ScopeResponse.Message = aclCompany != null ? this.MessageResponse.editMessage : this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = aclCompany != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
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
        public ScopeResponse FindById(uint id)
        {
            try
            {
                Company? aclCompany = Find(id);
                this.ScopeResponse.Data = aclCompany;
                this.ScopeResponse.Message = aclCompany != null ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = aclCompany != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
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
        public ScopeResponse DeleteCompany(uint id)
        {

            Company? aclCompany = Find(id);

            if (aclCompany != null)
            {
                aclCompany.Status = 0;
                this.ScopeResponse.Data = base.Update(aclCompany);;
            }
            this.ScopeResponse.Message = aclCompany != null ? this.MessageResponse.DeleteMessage : this.MessageResponse.notFoundMessage;
            this.ScopeResponse.StatusCode = aclCompany != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }

        /// <inheritdoc/>
        public Company PrepareInputData(AclCompanyCreateRequest? request = null, AclCompanyEditRequest? editRequest = null, Company? company = null)
        {
            Company aclCompany = company ?? new Company();

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

                var isAlreadyExist = this._userRepository.FindByEmail(request.Email);
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
