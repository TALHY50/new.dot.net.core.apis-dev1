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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public AclBranchService(ApplicationDbContext dbContext, IAclBranchRepository repository, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            _repository = repository;
            this.aclResponse = new AclResponse();
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse Get()
        {
            var aclBranches = _repository.All();

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
                var _aclBranch = _repository.GetById(id);
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

        private AclBranch PrepareInputData(AclBranchRequest request, AclBranch? branch = null)
        {
            AclBranch aclBranch = branch ?? new AclBranch();
            aclBranch.Name = request.Name;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            aclBranch.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclBranch.Address = request.Address;
            aclBranch.Description = request.Description;
            aclBranch.Sequence = request.Sequence;
            aclBranch.Status = (byte)(request.Status ?? 1);
            aclBranch.UpdatedAt = DateTime.Now;
            aclBranch.UpdatedById = AppAuth.GetAuthInfo().UserId;
            if (branch == null)
            {
                aclBranch.CreatedAt = DateTime.Now;
                aclBranch.CreatedById = AppAuth.GetAuthInfo().UserId;
            }
            return aclBranch;
        }
    }
}
