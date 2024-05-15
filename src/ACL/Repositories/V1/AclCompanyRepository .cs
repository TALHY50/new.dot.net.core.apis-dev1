using ACL.Controllers.V1;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ACL.Services;
using System.Globalization;
using System.Net;
using ACL.Core.Models;
using SharedLibrary.Services;
using Microsoft.Extensions.Logging;
using Castle.Core.Logging;
using SharedLibrary.Interfaces;
using ACL.Database;
using ACL.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Repositories.V1
{
    public class AclCompanyRepository : GenericRepository<AclCompany, ApplicationDbContext, ICustomUnitOfWork>, IAclCompanyRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company";
        private IConfiguration _config;
        private ICustomUnitOfWork _customUnitOfWork;


        public AclCompanyRepository(ICustomUnitOfWork _unitOfWork, IConfiguration config) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            aclResponse = new AclResponse();
            _customUnitOfWork = _unitOfWork;
            _config = config;
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclCompany = await base.Where(b => b.Status == 1).ToListAsync();
            if (aclCompany.Any())
            {

                aclResponse.Data = aclCompany;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            aclResponse.Message = aclCompany != null ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
            aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public async Task<AclResponse> AddAclCompany(AclCompanyCreateRequest request)
        {
            try
            {
                var aclCompany = PrepareInputData(request);
                var executionStrategy = _unitOfWork.CreateExecutionStrategy();

                await executionStrategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await _unitOfWork.BeginTransactionAsync())
                    {
                        try
                        {
                            var aclCompany = PrepareInputData(request);
                            await base.AddAsync(aclCompany);
                            await _unitOfWork.CompleteAsync();
                            await base.ReloadAsync(aclCompany);

                            if (aclCompany.Id != 0)
                            {
                                AclUserGroupRequest userGroupRequest = new AclUserGroupRequest()
                                {
                                    GroupName = _config["USER_GROUP_NAME"],
                                    Status = 1
                                };
                                _unitOfWork.AclUserGroupRepository.SetCompanyId(aclCompany.Id);
                                var userGroup = await _unitOfWork.AclUserGroupRepository.AddUserGroup(userGroupRequest);
                                await _unitOfWork.CompleteAsync();
                                var createdUserGroup = (AclUsergroup)userGroup.Data;
                                await _customUnitOfWork.AclUserGroupRepository.ReloadAsync(createdUserGroup);

                                var salt = _unitOfWork.cryptographyService.GenerateSalt();
                                string[] nameArr = request.Name.Split(' ');
                                string fname = (nameArr.Length > 0) ? nameArr[0] : "";
                                string lname = (nameArr.Length > 1) ? nameArr[1] : fname;
                                AclUser user = new AclUser()
                                {
                                    Email = aclCompany.Email,
                                    Password = (request.Password != null && request.Password.Length != 88) ? _unitOfWork.cryptographyService.HashPassword(request.Password, salt) : request.Password,
                                    UserType = _customUnitOfWork.AclUserRepository.SetUserType(true),
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

                                _unitOfWork.AclUserRepository.SetCompanyId((uint)aclCompany.Id);
                                _unitOfWork.AclUserRepository.SetUserType(true);
                                _unitOfWork.AclUserRepository.Add(user);
                                await _unitOfWork.CompleteAsync();
                                await _unitOfWork.AclUserRepository.ReloadAsync(user);
                                var userusergroup = PrepareDataForUserUserGroups(createdUserGroup.Id, user.Id);
                                _unitOfWork.AclUserUserGroupRepository.Add(userusergroup);
                                await _unitOfWork.CompleteAsync();

                                AclRole role = new AclRole()
                                {
                                    Name = aclCompany.Name,
                                    Title = _config["ROLE_TITLE"],
                                    CompanyId = (uint)aclCompany.Id,
                                    CreatedById = 0,
                                    UpdatedById = 0,
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now,
                                    Status = 1
                                };
                                var roleAdd = await _unitOfWork.AclRoleRepository.AddAsync(role);
                                await _unitOfWork.CompleteAsync();
                                await _unitOfWork.AclRoleRepository.ReloadAsync(role);

                                AclUsergroupRole userGroupRole = new AclUsergroupRole()
                                {
                                    UsergroupId = aclCompany.Id,
                                    RoleId = role.Id,
                                    CompanyId = aclCompany.Id,
                                    CreatedAt = DateTime.UtcNow,
                                    UpdatedAt = DateTime.UtcNow
                                };
                                var createdUserGroupRole = _unitOfWork.AclUserGroupRoleRepository.Add(userGroupRole);
                                await _unitOfWork.CompleteAsync();
                                List<AclPage> aclPagesByModuleId = await _customUnitOfWork.AclPageRepository.Where(x => x.ModuleId == ulong.Parse(_config["S_ADMIN_DEFAULT_MODULE_ID"])).ToListAsync();
                                List<ulong> pageIds = aclPagesByModuleId.Select(page => page.Id).ToList();
                                List<AclRolePage> aclRolePages = pageIds.Select(pageId => new AclRolePage
                                {
                                    RoleId = role.Id,
                                    PageId = pageId,
                                    CreatedAt = DateTime.UtcNow,
                                    UpdatedAt = DateTime.UtcNow
                                }).ToList();
                                await _unitOfWork.AclRolePageRepository.AddRange(aclRolePages.ToArray());
                                await _unitOfWork.CompleteAsync();
                            }

                            aclResponse.Data = aclCompany;

                            aclResponse.Message = aclCompany != null ? messageResponse.createMessage : messageResponse.notFoundMessage;

                            aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;

                            await transaction.CommitAsync();
                        }
                        catch (Exception ex)
                        {
                            if (_unitOfWork.Logger == null)
                            {

                            }
                            _unitOfWork.Logger.LogError(ex, "Error at COMPANY_CREATE", new { data = request, message = ex.Message, });

                            await transaction.RollbackAsync();
                            aclResponse.Message = ex.Message;
                            aclResponse.StatusCode = AppStatusCode.FAIL;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                _unitOfWork.Logger.LogError(null, "Error at COMPANY_CREATE", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> EditAclCompany(ulong Id, AclCompanyEditRequest request)
        {
            try
            {
                var _aclCompany = await base.GetById(Id);
                _aclCompany = PrepareInputData(null, request, _aclCompany);
                await base.UpdateAsync(_aclCompany);
                await _unitOfWork.CompleteAsync();
                await base.ReloadAsync(_aclCompany);
                aclResponse.Data = _aclCompany;
                aclResponse.Message = _aclCompany != null ? messageResponse.editMessage : messageResponse.notFoundMessage;

                aclResponse.StatusCode = _aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                _unitOfWork.Logger.LogError(ex, "Error at COMPANY_EDIT", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            var aclResponse = new AclResponse();

            try
            {
                var aclCompany = await base.GetById(id);

                aclResponse.Data = aclCompany;
                aclResponse.Message = aclCompany != null ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
                aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                _unitOfWork.Logger.LogError(ex, "Error at COMPANY_FIND", new { data = id, message = ex.Message });
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
                await _unitOfWork.CompleteAsync();
                aclResponse.Data = aclCompany;
            }
            aclResponse.Message = aclCompany != null ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
            aclResponse.StatusCode = aclCompany != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
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
