using ACL.Application.Interfaces;
using ACL.Application.Interfaces.ServiceInterfaces;
using ACL.Core.Models;
using ACL.Infrastructure.Repositories.V1;
using ACL.Infrastructure.Utilities;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure
{
    public partial class AclBranchService :AclBranchRepository, IAclBranchService
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Branch";

        public AclBranchService(ICustomUnitOfWork unitOfWork) : base(unitOfWork)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, this._unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> Get()
        {
            var aclCompanyModules = await base.All();

            this.aclResponse.Message = aclCompanyModules.Any() ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModules;
            this.aclResponse.StatusCode = aclCompanyModules.Any() ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        public async Task<AclResponse> Add(AclBranchRequest request)
        {
            try
            {
                AclBranch _aclBranch = PrepareInputData(request);
                await base.AddAsync(_aclBranch);
                await this._unitOfWork.CompleteAsync();
                await base.ReloadAsync(_aclBranch);
                this.aclResponse.Data = _aclBranch;
                this.aclResponse.Message = _aclBranch != null ? this.messageResponse.createMessage : this.messageResponse.createFail;

                this.aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                this._unitOfWork.Logger.LogError(ex, "Error at BRANCH_ADD", new { data = request, message = ex.Message, });
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        public async Task<AclResponse> Edit(ulong id, AclBranchRequest request)
        {
            try
            {
                var _aclBranch = await base.GetById(id);
                _aclBranch = PrepareInputData(request, _aclBranch);
                await base.UpdateAsync(_aclBranch);
                await this._unitOfWork.CompleteAsync();
                await base.ReloadAsync(_aclBranch);
                this.aclResponse.Data = _aclBranch;
                this.aclResponse.Message = _aclBranch != null ? this.messageResponse.editMessage : this.messageResponse.notFoundMessage;

                this.aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                this._unitOfWork.Logger.LogError(ex, "Error at BRANCH_EDIT", new { data = request, message = ex.Message, });
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public async Task<AclResponse> Find(ulong id)
        {
            try
            {
                var aclCompanyModule = await base.GetById(id);
                var message = aclCompanyModule != null ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
                this.aclResponse.Data = aclCompanyModule;
                this.aclResponse.Message = message;
                this.aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
                this.aclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
                this.aclResponse.Timestamp = DateTime.Now;
            }
            return this.aclResponse;
        }

        public async Task<AclResponse> Delete(ulong id)
        {
            var aclCompanyModule = await base.GetById(id);
            this.aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Message = aclCompanyModule != null ? this.messageResponse.deleteMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                await base.DeleteAsync(aclCompanyModule);
                await this._unitOfWork.CompleteAsync();
            }
            return this.aclResponse;
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
