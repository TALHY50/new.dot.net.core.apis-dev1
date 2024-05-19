using ACL.Application.Ports.Repositories.Auth;
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
using ACL.Infrastructure.Persistence.Database;
using ACL.Infrastructure.Utilities;
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
        public AclResponse aclResponse;
        /// <inheritdoc/>
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


        private readonly ApplicationDbContext _dbContext;


        /// <inheritdoc/>
        public AclCompanyRepository(ApplicationDbContext dbContext, IConfiguration config, ICryptographyService _cryptographyService, IAclUserGroupRepository _AclUserGroupRepository, IAclUserRepository _AclUserRepository, IAclUserUserGroupRepository _AclUserUserGroupRepository, IAclRoleRepository _AclRoleRepository, IAclUserGroupRoleRepository _AclUserGroupRoleRepository, IAclPageRepository _AclPageRepository, IAclRolePageRepository _AclRolePageRepository)

        {
            this.aclResponse = new AclResponse();
            this._config = config;
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
            cryptographyService = _cryptographyService;
            AclUserGroupRepository = _AclUserGroupRepository;
            AclUserRepository = _AclUserRepository;
            AclUserUserGroupRepository = _AclUserUserGroupRepository;
            AclRoleRepository = _AclRoleRepository;
            AclUserGroupRoleRepository = _AclUserGroupRoleRepository;
            AclPageRepository = _AclPageRepository;
            AclRolePageRepository = _AclRolePageRepository;
        }
        /// <inheritdoc/>

        public async Task<AclResponse> GetAll()
        {
            List<AclCompany>? aclCompany = await _dbContext.AclCompanies.Where(b => b.Status == 1).ToListAsync();
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
                        GroupName = _config["USER_GROUP_NAME"]??"ADMIN_USERGROUP",
                        Status = 1
                    };
                    AclUserGroupRepository.SetCompanyId(aclCompany.Id);
                    var userGroup = AclUserGroupRepository.PrepareInputData(userGroupRequest);
                     userGroup =  AclUserGroupRepository.Add(userGroup);
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
                        Claims = new Claim[] { },
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    AclUserRepository.SetCompanyId((uint)aclCompany.Id);
                    AclUserRepository.SetUserType(true);
                    var addeduser = AclUserRepository.Add(user);
                    var userusergroup = PrepareDataForUserUserGroups(userGroup?.Id, addeduser?.Id);
                    AclUserUserGroupRepository.Add(userusergroup);
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
                    var roleAdd = AclRoleRepository.Add(role);

                    AclUsergroupRole userGroupRole = new AclUsergroupRole()
                    {
                        UsergroupId = aclCompany.Id,
                        RoleId = (roleAdd?.Id) ?? 0,
                        CompanyId = aclCompany.Id,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    var createdUserGroupRole = AclUserGroupRoleRepository.Add(userGroupRole);
                    List<AclPage> aclPagesByModuleId = await _dbContext.AclPages.Where(x => x.ModuleId == ulong.Parse(_config["S_ADMIN_DEFAULT_MODULE_ID"]??"1003")).ToListAsync();
                    List<ulong> pageIds = aclPagesByModuleId.Select(page => page.Id).ToList();
                    List<AclRolePage> aclRolePages = pageIds.Select(pageId => new AclRolePage
                    {
                        RoleId = role.Id,
                        PageId = pageId,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToList();
                    AclRolePageRepository.AddAll(aclRolePages.ToArray());
                }
                this.aclResponse.Data = aclCompany;
                this.aclResponse.Message = aclCompany != null ? this.messageResponse.createMessage : this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
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
        public AclResponse EditAclCompany(ulong Id, AclCompanyEditRequest request)
        {
            try
            {
                AclCompany? _aclCompany = Find(Id);
                _aclCompany = PrepareInputData(null, request, _aclCompany);
                _aclCompany = Update(_aclCompany);
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
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclCompany? aclCompany = Find(id);
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
        /// <inheritdoc/>
        public async Task<AclResponse> DeleteCompany(ulong id)
        {

            AclCompany? aclCompany = Find(id);

            if (aclCompany != null)
            {
                aclCompany.Status = 0;
                _dbContext.AclCompanies.Update(aclCompany);
                await _dbContext.SaveChangesAsync();
                this.aclResponse.Data = aclCompany;
            }
            this.aclResponse.Message = aclCompany != null ? this.messageResponse.DeleteMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
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
            aclUserUserGroup.UserId = user_id??0;
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
                if(aclCompany!=null)
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
