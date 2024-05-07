using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SharedLibrary.Utilities;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Utilities;
using ACL.Services;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Repositories.V1
{
    public class AclUserRepository : GenericRepository<AclUser, ApplicationDbContext, ICustomUnitOfWork>, IAclUserRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User";
        private uint _companyId;
        private uint _userType;
        private bool is_user_type_created_by_company = false;
        private IConfiguration _config;
        private ICustomUnitOfWork _customUnitOfWork;

        public AclUserRepository(ICustomUnitOfWork _unitOfWork, IConfiguration config) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            AppAuth.SetAuthInfo();
            _config = config;
            aclResponse = new AclResponse();
            _companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
            _userType = (uint)AppAuth.GetAuthInfo().UserType;
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclUser = await base.All();
            if (aclUser.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclUser;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> AddUser(AclUserRequest request)
        {

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync())
                {
                    try
                    {
                        var aclUser = PrepareInputData(request);
                        await base.AddAsync(aclUser);
                        await _unitOfWork.CompleteAsync();
                        await base.ReloadAsync(aclUser);

                        //  need to insert user user group
                        var userGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                        await _unitOfWork.ApplicationDbContext.AddRangeAsync(userGroupPrepareData);
                        await _unitOfWork.CompleteAsync();

                        aclResponse.Data = aclUser;
                        aclResponse.Message = messageResponse.createMessage;
                        aclResponse.StatusCode = AppStatusCode.SUCCESS;

                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        aclResponse.Message = ex.Message;
                        aclResponse.StatusCode = AppStatusCode.FAIL;
                    }
                }
            });

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }


        public async Task<AclResponse> Edit(ulong id, AclUserRequest request)
        {
            try
            {
                var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.Find(id);

                if (aclUser != null)
                {
                    aclUser = PrepareInputData(request, aclUser);
                    base.Update(aclUser);
                    _unitOfWork.Complete();
                    await base.ReloadAsync(aclUser);

                    // first delete all user user group
                    var UserUserGroups = _customUnitOfWork.AclUserUserGroupRepository.Where(x => x.UserId == id).ToArray();
                    await _customUnitOfWork.AclUserUserGroupRepository.RemoveRange(UserUserGroups);
                    _unitOfWork.Complete();

                    // need to insert user user group
                    var UserGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                    await _customUnitOfWork.AclUserUserGroupRepository.AddRange(UserGroupPrepareData);
                    _unitOfWork.Complete();

                    aclResponse.Data = aclUser;
                    aclResponse.Message = messageResponse.editMessage;
                    aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                    aclResponse.StatusCode = AppStatusCode.FAIL;
                    return aclResponse;
                }

            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclUser = await _customUnitOfWork.AclUserRepository.GetById(id);
                aclResponse.Data = aclUser;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclUser == null)
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                }

                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            AclUser? aclUser = await _customUnitOfWork.AclUserRepository.GetById(id);

            if (aclUser != null)
            {
                await base.DeleteAsync(aclUser);
                _unitOfWork.ApplicationDbContext.SaveChanges();

                // delete all item for user user group
                var UserUserGroups = _unitOfWork.ApplicationDbContext.AclUserUsergroups.Where(x => x.UserId == id).ToArray();
                _unitOfWork.ApplicationDbContext.RemoveRange(UserUserGroups);
                _unitOfWork.Complete();


                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return aclResponse;
        }

        private AclUser PrepareInputData(AclUserRequest request, AclUser AclUser = null)
        {
            if (AclUser == null)
            {
                return new AclUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = Cryptographer.AppEncrypt(request.Password),
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
                    CompanyId = _companyId,
                    UserType = (_companyId == 0) ? uint.Parse(_config["USER_TYPE_S_ADMIN"]) : uint.Parse(_config["USER_TYPE_USER"])
                };
            }
            else
            {
                AclUser.FirstName = request.FirstName;
                AclUser.LastName = request.LastName;
                AclUser.Email = request.Email;
                AclUser.Password = Cryptographer.AppEncrypt(request.Password);
                AclUser.Avatar = request.Avatar;
                AclUser.Dob = request.DOB;
                AclUser.Gender = request.Gender;
                AclUser.Address = request.Address;
                AclUser.City = request.City;
                AclUser.Country = request.Country;
                AclUser.Phone = request.Phone;
                AclUser.Language = "en-US";
                AclUser.Username = request.UserName;
                AclUser.ImgPath = request.ImgPath;
                AclUser.Status = request.Status;
                AclUser.UpdatedAt = DateTime.Now;
                AclUser.CompanyId = (_companyId != 0) ? _companyId : 0;
                AclUser.UserType = (_userType != 0) ? _userType : 0;
            }
            return AclUser;
        }


        public AclUserUsergroup[] PrepareDataForUserUserGroups(AclUserRequest request, ulong user_id)
        {
            IList<AclUserUsergroup> res = new List<AclUserUsergroup>();

            foreach (ulong user_group in request.UserGroup)
            {
                AclUserUsergroup aclUserUserGroup = new AclUserUsergroup();
                aclUserUserGroup.UserId = user_id;
                aclUserUserGroup.UsergroupId = user_group;
                aclUserUserGroup.CreatedAt = DateTime.Now;
                aclUserUserGroup.UpdatedAt = DateTime.Now;
                res.Add(aclUserUserGroup);
            }
            return res.ToArray();
        }

        public uint SetCompanyId(uint companyId)
        {
            _companyId = companyId;
            return _companyId;
        }
        public uint SetUserType(bool is_user_type_created_by_company)
        {

            return _userType = is_user_type_created_by_company ? uint.Parse(_config["USER_TYPE_S_ADMIN"]) : uint.Parse(_config["USER_TYPE_USER"]);
        }

    }
}
