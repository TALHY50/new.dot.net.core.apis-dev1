using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Application.Ports.Repositories.Role;
using ACL.Application.Ports.Repositories.UserGroup;
using ACL.Application.Ports.Services.Company;
using ACL.Application.Ports.Services.Cryptography;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Auth;
using ACL.Core.Entities.Company;
using ACL.Core.Entities.Module;
using ACL.Core.Entities.Role;
using ACL.Core.Entities.UserGroup;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Persistence.Repositories.Company;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Response.CustomStatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Infrastructure.Services.Company
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
        private readonly IAclUserGroupRepository _aclUserGroupRepository;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly IAclUserUserGroupRepository _aclUserUserGroupRepository;
        private readonly IAclRoleRepository _aclRoleRepository;
        private readonly IAclUserGroupRoleRepository _aclUserGroupRoleRepository;
        private readonly IAclPageRepository _aclPageRepository;
        private readonly IAclRolePageRepository _aclRolePageRepository;
        public new static IHttpContextAccessor HttpContextAccessor;

        private readonly ApplicationDbContext _dbContext;


        /// <inheritdoc/>
        public AclCompanyService(ApplicationDbContext dbContext, IConfiguration config, ICryptographyService cryptographyService, IAclUserGroupRepository aclUserGroupRepository, IAclUserRepository aclUserRepository, IAclUserUserGroupRepository aclUserUserGroupRepository, IAclRoleRepository aclRoleRepository, IAclUserGroupRoleRepository aclUserGroupRoleRepository, IAclPageRepository aclPageRepository, IAclRolePageRepository aclRolePageRepository, IHttpContextAccessor httpContextAccessor):base(dbContext,httpContextAccessor)

        {
            AclResponse = new AclResponse();
            _config = config;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument
            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
            _cryptographyService = cryptographyService;
            _aclUserGroupRepository = aclUserGroupRepository;
            _aclUserRepository = aclUserRepository;
            _aclUserUserGroupRepository = aclUserUserGroupRepository;
            _aclRoleRepository = aclRoleRepository;
            _aclUserGroupRoleRepository = aclUserGroupRoleRepository;
            _aclPageRepository = aclPageRepository;
            _aclRolePageRepository = aclRolePageRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        /// <inheritdoc/>

        public AclResponse GetAll()
        {
            List<AclCompany>? aclCompany = _dbContext.AclCompanies.Where(b => b.Status == 1).ToList();
            if (aclCompany.Any())
            {
                AclResponse.Data = aclCompany;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
                AclResponse.Message = MessageResponse.fetchMessage;
            }
            else
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }

            AclResponse.Timestamp = DateTime.Now;

            return AclResponse;
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
                        GroupName = _config["USER_GROUP_NAME"] ?? "ADMIN_USERGROUP",
                        Status = 1
                    };
                    _aclUserGroupRepository.SetCompanyId(aclCompany.Id);
                    var userGroup = _aclUserGroupRepository.PrepareInputData(userGroupRequest);
                    userGroup.CompanyId = aclCompany.Id;
                    userGroup = _aclUserGroupRepository.Add(userGroup);
                    var salt = _cryptographyService.GenerateSalt();
                    string[] nameArr = request.Name.Split(' ');
                    string firstName = (nameArr.Length > 0) ? nameArr[0] : "";
                    string lname = (nameArr.Length > 1) ? nameArr[1] : firstName;
                    AclUser user = new AclUser()
                    {
                        Email = aclCompany.Email,
                        Password = (request.Password != null && request.Password.Length != 88) ? _cryptographyService.HashPassword(request.Password, salt) : request.Password,
                        UserType = _aclUserRepository.SetUserType(true),
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
                    var aclUser = _aclUserRepository.Add(user);
                    var aclUserUserGroup = PrepareDataForUserUserGroups(userGroup?.Id, aclUser?.Id);
                    _aclUserUserGroupRepository.Add(aclUserUserGroup);
                    AclRole role = new AclRole()
                    {
                        Name = _config["ROLE_TITLE"] ?? "ADMIN_ROLE",
                        Title = _config["ROLE_TITLE"] ?? "ADMIN_ROLE",
                        CompanyId = (uint)aclCompany.Id,
                        CreatedById = (uint)AppAuth.GetAuthInfo().UserId,
                        UpdatedById = (uint)AppAuth.GetAuthInfo().UserId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Status = 1
                    };
                    var roleAdd = _aclRoleRepository.Add(role);

                    AclUsergroupRole userGroupRole = new AclUsergroupRole()
                    {
                        UsergroupId = aclCompany.Id,
                        RoleId = (roleAdd?.Id) ?? 0,
                        CompanyId = aclCompany.Id,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    var createdUserGroupRole = _aclUserGroupRoleRepository.Add(userGroupRole);
                    List<AclPage> aclPagesByModuleId = await _dbContext.AclPages.Where(x => x.ModuleId == ulong.Parse(_config["S_ADMIN_DEFAULT_MODULE_ID"] ?? "1003")).ToListAsync();
                    List<ulong> pageIds = aclPagesByModuleId.Select(page => page.Id).ToList();
                    List<AclRolePage> aclRolePages = pageIds.Select(pageId => new AclRolePage
                    {
                        RoleId = role.Id,
                        PageId = pageId,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToList();
                    _aclRolePageRepository.AddAll(aclRolePages.ToArray());
                }
                AclResponse.Data = aclCompany;
                AclResponse.Message = aclCompany != null ? MessageResponse.createMessage : MessageResponse.notFoundMessage;
                AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
                AclResponse.Data = aclCompany;
                AclResponse.Message = aclCompany != null ? MessageResponse.editMessage : MessageResponse.notFoundMessage;
                AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclCompany? aclCompany = Find(id);
                AclResponse.Data = aclCompany;
                AclResponse.Message = aclCompany != null ? MessageResponse.fetchMessage : MessageResponse.notFoundMessage;
                AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
        public AclResponse DeleteCompany(ulong id)
        {

            AclCompany? aclCompany = Find(id);

            if (aclCompany != null)
            {
                aclCompany.Status = 0;
                AclResponse.Data = base.Update(aclCompany);;
            }
            AclResponse.Message = aclCompany != null ? MessageResponse.DeleteMessage : MessageResponse.notFoundMessage;
            AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            AclResponse.Timestamp = DateTime.Now;

            return AclResponse;
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

                var isAlreadyExist = _aclUserRepository.FindByEmail(request.Email);
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
