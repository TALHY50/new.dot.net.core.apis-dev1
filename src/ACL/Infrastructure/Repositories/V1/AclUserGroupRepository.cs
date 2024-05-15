using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserGroupRepository : GenericRepository<AclUsergroup, ApplicationDbContext, ICustomUnitOfWork>, IAclUserGroupRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group";
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        private ICustomUnitOfWork _customUnitOfWork;


        public AclUserGroupRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            AppAuth.SetAuthInfo();
            this._customUnitOfWork = _unitOfWork;
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var result = await base.All();
            if (result.Any())
            {
                this.aclResponse.Data = result;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> AddUserGroup(AclUserGroupRequest usergroup)
        {
            try
            {
                var result = PrepareInputData(usergroup);
                await this._customUnitOfWork.AclUserGroupRepository.AddAsync(result);
                await this._customUnitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclUserGroupRepository.ReloadAsync(result);
                this.aclResponse.Data = result;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public async Task<AclResponse> UpdateUserGroup(ulong id, AclUserGroupRequest usergroup)
        {
            var result = await base.GetById(id);
            if (result != null)
            {
                result = PrepareInputData(usergroup, result);
                await this._customUnitOfWork.AclUserGroupRepository.UpdateAsync(result);
                await this._customUnitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclUserGroupRepository.ReloadAsync(result);
                this.aclResponse.Data = result;
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            var result = await base.GetById(id);
            if (result != null)
            {
                this.aclResponse.Data = result;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> Delete(ulong id)
        {
            var result = await base.GetById(id);
            if (result != null)
            {
                await base.DeleteAsync(result);
                await this._customUnitOfWork.CompleteAsync();
                await base.ReloadAsync(result);
                this.aclResponse.Data = result;
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public AclUsergroup PrepareInputData(AclUserGroupRequest request, AclUsergroup aclUsergroup = null)
        {
            var _aclInstance = aclUsergroup ?? new AclUsergroup();

            _aclInstance.Status = request.Status;
            _aclInstance.GroupName = request.GroupName;

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
