using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Repositories.Company;
using ACL.Application.Ports.Services;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities;
using ACL.Core.Entities.Company;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Persistence.Repositories;
using ACL.Infrastructure.Persistence.Repositories.Company;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Services
{
    /// <inheritdoc/>
    public class AclBranchService : AclBranchRepository, IAclBranchService
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Branch";
        private IAclBranchRepository _repository;

        /// <inheritdoc/>
        public AclBranchService(ApplicationDbContext dbContext, IAclBranchRepository repository):base(dbContext)
        {
            _repository = repository;
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse Get()
        {
            var aclBranches =  _repository.All();

            this.aclResponse.Message = aclBranches.Any() ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclBranches;
            this.aclResponse.StatusCode = aclBranches.Any() ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclBranchRequest request)
        {
            try
            {
                AclBranch _aclBranch = PrepareInputData(request);
                this.aclResponse.Data = _repository.Add(_aclBranch);
                this.aclResponse.Message = _aclBranch != null ? this.messageResponse.createMessage : this.messageResponse.createFail;

                this.aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_ADD", new { data = request, message = ex.Message, });
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclBranchRequest request)
        {
            try
            {
                var _aclBranch =  _repository.GetById(id);
                _aclBranch = PrepareInputData(request, _aclBranch);
                this.aclResponse.Data = _repository.Update(_aclBranch);
                this.aclResponse.Message = _aclBranch != null ? this.messageResponse.editMessage : this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_EDIT", new { data = request, message = ex.Message, });
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Find(ulong id)
        {
            try
            {
                var aclCompanyModule = _repository.GetById(id);
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

        /// <inheritdoc/>
        public new AclResponse Delete(ulong id)
        {
            var aclCompanyModule = _repository.Delete(id);
            this.aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Message = aclCompanyModule != null ? this.messageResponse.deleteMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                 _repository.Delete(aclCompanyModule);
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
