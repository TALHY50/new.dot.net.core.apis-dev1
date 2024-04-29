using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Utilities;
using ACL.Services;

namespace ACL.Repositories.V1
{
    public class AclUserGroupRepository : GenericRepository<AclUsergroup, ApplicationDbContext,ICustomUnitOfWork>, IAclUserGroupRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group";
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        private ICustomUnitOfWork _customUnitOfWork;


        public AclUserGroupRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            AppAuth.SetAuthInfo();
            _customUnitOfWork = _unitOfWork;
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
        }

        public async Task<AclResponse> GetAll()
        {
            var result = await base.All();
            if (result.Any())
            {
                aclResponse.Data = result;
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> AddUserGroup(AclUserGroupRequest usergroup)
        {
            try
            {
                var result = PrepareInputData(usergroup);
                await _customUnitOfWork.AclUserGroupRepository.AddAsync(result);
                await _customUnitOfWork.CompleteAsync();
                await _customUnitOfWork.AclUserGroupRepository.ReloadAsync(result);
                aclResponse.Data = result;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.UnprocessableEntity;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> UpdateUserGroup(ulong id, AclUserGroupRequest usergroup)
        {
            var result = await base.GetById(id);
            if (result != null)
            {
                result = PrepareInputData(usergroup, result);
                await _customUnitOfWork.AclUserGroupRepository.UpdateAsync(result);
                await _customUnitOfWork.CompleteAsync();
                await _customUnitOfWork.AclUserGroupRepository.ReloadAsync(result);
                aclResponse.Data = result;
                aclResponse.Message = messageResponse.editMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            var result = await base.GetById(id);
            if (result != null)
            {
                aclResponse.Data = result;
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> Delete(ulong id)
        {
            var result = await base.GetById(id);
            if (result != null)
            {
                await base.DeleteAsync(result);
                await _customUnitOfWork.CompleteAsync();
                await base.ReloadAsync(result);
                aclResponse.Data = result;
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public AclUsergroup PrepareInputData(AclUserGroupRequest request, AclUsergroup aclUsergroup = null)
        {
            var _aclInstance = aclUsergroup ?? new AclUsergroup();

            _aclInstance.Status = request.status;
            _aclInstance.GroupName = request.group_name;

            if (CompanyId == 0)
            {
                _aclInstance.CompanyId = AppAuth.GetAuthInfo().CompanyId; // We will get this from auth later
            }
            if (aclUsergroup == null)
            {
                _aclInstance.CreatedAt = DateTime.Now;
            }
            _aclInstance.UpdatedAt = DateTime.Now;

            return _aclInstance;
        }

        public ulong SetCompanyId(ulong companyId)
        {
            CompanyId = companyId;
            return CompanyId;
        }
    }
}
