using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Utilities;
using System.Threading.Tasks;

namespace ACL.Repositories.V1
{
    public class AclCompanyRepository : GenericRepository<AclCompany>, IAclCompanyRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company";
        private IConfiguration _config;
        public AclCompanyRepository(IUnitOfWork _unitOfWork, IConfiguration config) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
            _config = config;
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclCompany = await base.GetById(id);
                aclResponse.Data = aclCompany;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclCompany == null)
                {
                    aclResponse.Message = messageResponse.noFoundMessage;
                }

                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
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
                            await _unitOfWork.AclCompanyRepository.AddAsync(aclCompany);
                            await _unitOfWork.CompleteAsync();
                            await base.ReloadAsync(aclCompany);

                            if (aclCompany.Id != 0)
                            {
                                UserGroupRequest userGroupRequest = new UserGroupRequest()
                                {
                                    group_name = _config["USER_GROUP_NAME"],
                                    status = 1
                                };
                                _unitOfWork.AclUserGroupRepository.SetCompanyId(aclCompany.Id);
                                var userGroup = await _unitOfWork.AclUserGroupRepository.AddUserGroup(userGroupRequest);
                                await _unitOfWork.CompleteAsync();
                                var createdUserGroup = (AclUsergroup)userGroup.Data;
                                await _unitOfWork.AclUserGroupRepository.ReloadAsync(createdUserGroup);

                                string[] nameArr = request.name.Split(' ');
                                string fname = (nameArr.Length > 0) ? nameArr[0] : "";
                                string lname = (nameArr.Length > 1) ? nameArr[1] : fname;
                                AclUserRequest user = new AclUserRequest()
                                {
                                    email = aclCompany.Email,
                                    password = request.password,
                                    first_name = fname,
                                    last_name = lname
                                };
                                _unitOfWork.AclUserRepository.SetCompanyId((uint)aclCompany.Id);
                                _unitOfWork.AclUserRepository.SetUserType(true);
                                var useradd = await _unitOfWork.AclUserRepository.Add(user);
                                await _unitOfWork.CompleteAsync();
                                AclUser createdUser = (AclUser)useradd.Data;
                                await _unitOfWork.AclUserRepository.ReloadAsync(createdUser);

                                AclRoleRequest role = new AclRoleRequest()
                                {
                                    name = aclCompany.Name,
                                    status = 1
                                };

                                _unitOfWork.AclRoleRepository.SetCompanyId((uint)aclCompany.Id);
                                var roleAdd = _unitOfWork.AclRoleRepository.Add(role);
                                await _unitOfWork.CompleteAsync();
                                AclRole createdRole = (AclRole)roleAdd.Data;
                                await _unitOfWork.AclRoleRepository.ReloadAsync(createdRole);

                                AclUsergroupRole userGroupRole = new AclUsergroupRole()
                                {
                                    UsergroupId = aclCompany.Id,
                                    RoleId = createdRole.Id,
                                    CompanyId = aclCompany.Id,
                                    CreatedAt = DateTime.UtcNow,
                                    UpdatedAt = DateTime.UtcNow
                                };
                                var createdUserGroupRole = _unitOfWork.AclUserGroupRoleRepository.Add(userGroupRole);
                                await _unitOfWork.CompleteAsync();
                                List<AclRolePage> aclRolePagesById = await _unitOfWork.AclRolePageRepository.Where(x => x.RoleId == ulong.Parse(_config["S_ADMIN_DEFAULT_MODULE_ID"])).ToListAsync();
                                List<ulong> pageIds = aclRolePagesById.Select(page => page.Id).ToList();
                                List<AclRolePage> aclRolePages = pageIds.Select(pageId => new AclRolePage
                                {
                                    RoleId = createdRole.Id,
                                    PageId = pageId,
                                    CreatedAt = DateTime.UtcNow,
                                    UpdatedAt = DateTime.UtcNow
                                }).ToList();
                                await _unitOfWork.AclRolePageRepository.AddRange(aclRolePages.ToArray());
                                await _unitOfWork.CompleteAsync();
                            }

                            aclResponse.Data = aclCompany;
                            aclResponse.Message = messageResponse.createMessage;
                            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

                            await transaction.CommitAsync();
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            aclResponse.Message = ex.Message;
                            aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> EditAclCompany(ulong Id, AclCompanyEditRequest request)
        {
            try
            {
                var _aclCompany = await base.GetById(Id);
                if (_aclCompany != null)
                {
                    _aclCompany = PrepareInputData(null, request, _aclCompany);
                    await base.UpdateAsync(_aclCompany);
                    await _unitOfWork.CompleteAsync();
                    await base.ReloadAsync(_aclCompany);
                    aclResponse.Data = _aclCompany;
                    aclResponse.Message = messageResponse.editMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    aclResponse.Message = messageResponse.noFoundMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclCompany = await base.All();
            if (aclCompany.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.Data = aclCompany;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
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
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public AclCompany PrepareInputData(AclCompanyCreateRequest requ = null, AclCompanyEditRequest req = null, AclCompany _aclCompany = null)
        {
            AclCompany aclCompany = _aclCompany == null ? new AclCompany() : _aclCompany;
            if (requ == null && req != null)
            {
                aclCompany.Name = req.name;
                aclCompany.Cname = req.cname;
                aclCompany.Cemail = req.cemail;
                aclCompany.Address1 = req.address1;
                aclCompany.Address2 = req.address2;
                aclCompany.Postcode = req.postcode;
                aclCompany.Phone = req.phone;
                aclCompany.Fax = req.fax;
                aclCompany.City = req.city;
                aclCompany.State = req.state;
                aclCompany.Country = req.country;
                aclCompany.Logo = req.logo;
                aclCompany.RegistrationNo = req.registration_no;
                aclCompany.Timezone = req.timezone;
                aclCompany.TimezoneValue = req.timezone_value;
                aclCompany.TaxNo = req.tax_no;
                aclCompany.Status = req.status;
            }
            if (requ != null && req == null)
            {
                aclCompany.Name = requ.name;
                aclCompany.Cname = requ.cname;
                aclCompany.Cemail = requ.cemail;
                aclCompany.Address1 = requ.address1;
                aclCompany.Address2 = requ.address2;
                aclCompany.Postcode = requ.postcode;
                aclCompany.Phone = requ.phone;
                aclCompany.Email = requ.email;
                aclCompany.Fax = requ.fax;
                aclCompany.City = requ.city;
                aclCompany.State = requ.state;
                aclCompany.Country = requ.country;
                aclCompany.Logo = requ.logo;
                aclCompany.RegistrationNo = requ.registration_no;
                aclCompany.Timezone = requ.timezone;
                aclCompany.TimezoneValue = requ.timezone_value;
                aclCompany.TaxNo = requ.tax_no;
                aclCompany.UniqueColumnName = requ.unique_column_name;
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
            // Implement logic to get the authenticated user's ID
            // For example:
            // return AppAuth.getAuthInfo().user_id;
            return 1;
        }
    }
}
