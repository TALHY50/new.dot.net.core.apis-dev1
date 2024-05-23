﻿using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Company;
using ACL.Application.Ports.Repositories.Module;
using ACL.Application.Ports.Repositories.Role;
using ACL.Application.Ports.Repositories.UserGroup;
using ACL.Application.Ports.Services;
using ACL.Application.Ports.Services.Cryptography;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Auth;
using ACL.Core.Entities.Company;
using ACL.Core.Entities.Module;
using ACL.Core.Entities.Role;
using ACL.Core.Entities.UserGroup;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Response.CustomStatusCode;
using Claim = ACL.Core.Entities.Auth.Claim;

namespace ACL.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclCompanyRepository : IAclCompanyRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
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
        public static IHttpContextAccessor HttpContextAccessor;

        private readonly ApplicationDbContext _dbContext;


        /// <inheritdoc/>
        public AclCompanyRepository(ApplicationDbContext dbContext, IConfiguration config, ICryptographyService cryptographyService, IAclUserGroupRepository aclUserGroupRepository, IAclUserRepository aclUserRepository, IAclUserUserGroupRepository aclUserUserGroupRepository, IAclRoleRepository aclRoleRepository, IAclUserGroupRoleRepository aclUserGroupRoleRepository, IAclPageRepository aclPageRepository, IAclRolePageRepository aclRolePageRepository, IHttpContextAccessor httpContextAccessor)

        {
            this.AclResponse = new AclResponse();
            this._config = config;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
            this._cryptographyService = cryptographyService;
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

        public async Task<AclResponse> GetAll()
        {
            List<AclCompany>? aclCompany = await _dbContext.AclCompanies.Where(b => b.Status == 1).ToListAsync();
            if (aclCompany.Any())
            {
                this.AclResponse.Data = aclCompany;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            this.AclResponse.Message = aclCompany != null ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
            this.AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
                        GroupName = _config["USER_GROUP_NAME"] ?? "ADMIN_USERGROUP",
                        Status = 1
                    };
                    _aclUserGroupRepository.SetCompanyId(aclCompany.Id);
                    var userGroup = _aclUserGroupRepository.PrepareInputData(userGroupRequest);
                    userGroup.CompanyId = aclCompany.Id;
                    userGroup = _aclUserGroupRepository.Add(userGroup);
                    var salt = _cryptographyService.GenerateSalt();
                    string[] nameArr = request.Name.Split(' ');
                    string fname = (nameArr.Length > 0) ? nameArr[0] : "";
                    string lname = (nameArr.Length > 1) ? nameArr[1] : fname;
                    AclUser user = new AclUser()
                    {
                        Email = aclCompany.Email,
                        Password = (request.Password != null && request.Password.Length != 88) ? _cryptographyService.HashPassword(request.Password, salt) : request.Password,
                        UserType = _aclUserRepository.SetUserType(true),
                        FirstName = fname,
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
                    var addeduser = _aclUserRepository.Add(user);
                    var userusergroup = PrepareDataForUserUserGroups(userGroup?.Id, addeduser?.Id);
                    _aclUserUserGroupRepository.Add(userusergroup);
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
        public AclResponse EditAclCompany(ulong Id, AclCompanyEditRequest request)
        {
            try
            {
                AclCompany? _aclCompany = Find(Id);
                _aclCompany = PrepareInputData(null, request, _aclCompany);
                _aclCompany = Update(_aclCompany);
                this.AclResponse.Data = _aclCompany;
                this.AclResponse.Message = _aclCompany != null ? this.MessageResponse.editMessage : this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = _aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
                AclResponse.Data = aclCompany;
                AclResponse.Message = aclCompany != null ? this.MessageResponse.fetchMessage : this.MessageResponse.notFoundMessage;
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
        public async Task<AclResponse> DeleteCompany(ulong id)
        {

            AclCompany? aclCompany = Find(id);

            if (aclCompany != null)
            {
                aclCompany.Status = 0;
                _dbContext.AclCompanies.Update(aclCompany);
                await _dbContext.SaveChangesAsync();
                this.AclResponse.Data = aclCompany;
            }
            this.AclResponse.Message = aclCompany != null ? this.MessageResponse.DeleteMessage : this.MessageResponse.notFoundMessage;
            this.AclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }

        /// <inheritdoc/>
        public AclCompany PrepareInputData(AclCompanyCreateRequest? requ = null, AclCompanyEditRequest? req = null, AclCompany? _aclCompany = null)
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

        /// <inheritdoc/>
        public AclUserUsergroup PrepareDataForUserUserGroups(ulong? usergroup, ulong? user_id)
        {
            AclUserUsergroup aclUserUserGroup = new AclUserUsergroup();
            aclUserUserGroup.UserId = user_id ?? 0;
            aclUserUserGroup.UsergroupId = usergroup ?? 0;
            aclUserUserGroup.CreatedAt = DateTime.Now;
            aclUserUserGroup.UpdatedAt = DateTime.Now;
            return aclUserUserGroup;
        }
        /// <inheritdoc/>
        public List<AclCompany>? All()
        {
            try
            {
                return _dbContext.AclCompanies.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompany? Find(ulong id)
        {
            try
            {
                return _dbContext.AclCompanies.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompany? Add(AclCompany aclCompany)
        {
            try
            {
                _dbContext.AclCompanies.Add(aclCompany);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCompany).ReloadAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompany? Update(AclCompany aclCompany)
        {
            try
            {
                _dbContext.AclCompanies.Update(aclCompany);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCompany).ReloadAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclCompany? Delete(AclCompany aclCompany)
        {
            try
            {
                _dbContext.AclCompanies.Remove(aclCompany);
                _dbContext.SaveChangesAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclCompany? Delete(ulong id)
        {
            try
            {
                var aclCompany = Find(id);
                if (aclCompany != null)
                    _dbContext.AclCompanies.Remove(aclCompany);
                _dbContext.SaveChangesAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
