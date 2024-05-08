using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces.ServiceInterfaces;
using ACL.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Services
{
    public partial class AclBranchService :AclBranchRepository, IAclBranchService
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Branch";

        public AclBranchService(ICustomUnitOfWork unitOfWork) : base(unitOfWork)
        {
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> Get()
        {
            var aclCompanyModules = await base.All();

            aclResponse.Message = aclCompanyModules.Any() ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
            aclResponse.Data = aclCompanyModules;
            aclResponse.StatusCode = aclCompanyModules.Any() ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclBranchRequest request)
        {
            try
            {
                AclBranch _aclBranch = PrepareInputData(request);
                await base.AddAsync(_aclBranch);
                await _unitOfWork.CompleteAsync();
                await base.ReloadAsync(_aclBranch);
                aclResponse.Data = _aclBranch;
                aclResponse.Message = _aclBranch != null ? messageResponse.createMessage : messageResponse.createFail;

                aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                _unitOfWork.Logger.LogError(ex, "Error at BRANCH_ADD", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> Edit(ulong id, AclBranchRequest request)
        {
            try
            {
                var _aclBranch = await base.GetById(id);
                _aclBranch = PrepareInputData(request, _aclBranch);
                await base.UpdateAsync(_aclBranch);
                await _unitOfWork.CompleteAsync();
                await base.ReloadAsync(_aclBranch);
                aclResponse.Data = _aclBranch;
                aclResponse.Message = _aclBranch != null ? messageResponse.editMessage : messageResponse.notFoundMessage;

                aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                _unitOfWork.Logger.LogError(ex, "Error at BRANCH_EDIT", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> Find(ulong id)
        {
            try
            {
                var aclCompanyModule = await base.GetById(id);
                var message = aclCompanyModule != null ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
                aclResponse.Data = aclCompanyModule;
                aclResponse.Message = message;
                aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                aclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
                aclResponse.Timestamp = DateTime.Now;
            }
            return aclResponse;
        }

        public async Task<AclResponse> Delete(ulong id)
        {
            var aclCompanyModule = await base.GetById(id);
            aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Message = aclCompanyModule != null ? messageResponse.deleteMessage : messageResponse.notFoundMessage;
            aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                await base.DeleteAsync(aclCompanyModule);
                await _unitOfWork.CompleteAsync();
            }
            return aclResponse;
        }

        private AclBranch PrepareInputData(AclBranchRequest request, AclBranch aclBranch = null)
        {
            AclBranch _aclBranch = aclBranch ?? new AclBranch();
            _aclBranch.Name = request.Name;
            _aclBranch.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            _aclBranch.Address = request.Address;
            _aclBranch.Description = request.Description;
            _aclBranch.Sequence = request.Sequence;
            _aclBranch.Status = (byte)(request.Status ?? 1);
            _aclBranch.UpdatedAt = DateTime.Now;
            _aclBranch.UpdatedById = AppAuth.GetAuthInfo().UserId;
            if (aclBranch == null)
            {
                _aclBranch.CreatedAt = DateTime.Now;
                _aclBranch.CreatedById = AppAuth.GetAuthInfo().UserId;
            }
            return _aclBranch;
        }
    }
}
