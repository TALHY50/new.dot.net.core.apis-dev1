using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;
using ACL.App.Infrastructure.Auth.Auth;
using ACL.App.Infrastructure.Persistence.Context;
using ACL.App.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace ACL.App.Domain.Services
{
    /// <inheritdoc/>
    public class BranchService : BranchRepository, IBranchService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Branch";
        private IBranchRepository _repository;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public BranchService(ApplicationDbContext dbContext, IBranchRepository repository, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            this._repository = repository;
            this.ScopeResponse = new ScopeResponse();
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public ScopeResponse Get()
        {
            var aclBranches = this._repository.All();

            this.ScopeResponse.Message = aclBranches.Any() ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.ScopeResponse.Data = aclBranches;
            this.ScopeResponse.StatusCode = aclBranches.Any() ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Add(AclBranchRequest request)
        {
            try
            {
                Branch _aclBranch = PrepareInputData(request);
                this.ScopeResponse.Data = this._repository.Add(_aclBranch);
                this.ScopeResponse.Message = _aclBranch != null ? this.messageResponse.createMessage : this.messageResponse.createFail;

                this.ScopeResponse.StatusCode = _aclBranch != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_ADD", new { data = request, message = ex.Message, });
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }

        /// <inheritdoc/>
        public ScopeResponse Edit(ulong id, AclBranchRequest request)
        {
            try
            {
                var _aclBranch = this._repository.GetById(id);
                if (_aclBranch == null)
                {
                    throw new Exception("Branch id Not Exist");
                }
                _aclBranch = PrepareInputData(request, _aclBranch);
                this.ScopeResponse.Data = this._repository.Update(_aclBranch);
                this.ScopeResponse.Message = _aclBranch != null ? this.messageResponse.editMessage : this.messageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = _aclBranch != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_EDIT", new { data = request, message = ex.Message, });
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Find(ulong id)
        {
            try
            {
                var aclCompanyModule = this._repository.GetById(id);
                var message = aclCompanyModule != null ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
                this.ScopeResponse.Data = aclCompanyModule;
                this.ScopeResponse.Message = message;
                this.ScopeResponse.StatusCode = aclCompanyModule != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
                this.ScopeResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                this.ScopeResponse.Timestamp = DateTime.Now;
            }
            return this.ScopeResponse;
        }

        /// <inheritdoc/>
        public new ScopeResponse Delete(ulong id)
        {
            var aclCompanyModule = this._repository.Delete(id);
            this.ScopeResponse.StatusCode = aclCompanyModule != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ScopeResponse.Message = aclCompanyModule != null ? this.messageResponse.deleteMessage : this.messageResponse.notFoundMessage;
            this.ScopeResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                this._repository.Delete(aclCompanyModule);
            }
            return this.ScopeResponse;
        }

        private Branch PrepareInputData(AclBranchRequest request, Branch? branch = null)
        {
            Branch aclBranch = branch ?? new Branch();
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
