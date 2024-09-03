using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Contracts;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Domain.Services
{
    /// <inheritdoc/>
    public class BranchService : BranchRepository, IBranchService
    {
        /// <inheritdoc/>
        public ApplicationResponse ApplicationResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Branch";
        private IBranchRepository _repository;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public BranchService(ApplicationDbContext dbContext, IBranchRepository repository, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            this._repository = repository;
            this.ApplicationResponse = new ApplicationResponse();
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public ApplicationResponse Get()
        {
            var aclBranches = this._repository.All();

            this.ApplicationResponse.Message = aclBranches.Any() ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
            this.ApplicationResponse.Data = aclBranches;
            this.ApplicationResponse.StatusCode = aclBranches.Any() ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ApplicationResponse.Timestamp = DateTime.Now;

            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse Add(AclBranchRequest request)
        {
            try
            {
                Branch _aclBranch = PrepareInputData(request);
                this.ApplicationResponse.Data = this._repository.Add(_aclBranch);
                this.ApplicationResponse.Message = _aclBranch != null ? this.messageResponse.createMessage : this.messageResponse.createFail;

                this.ApplicationResponse.StatusCode = _aclBranch != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_ADD", new { data = request, message = ex.Message, });
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }

        /// <inheritdoc/>
        public ApplicationResponse Edit(uint id, AclBranchRequest request)
        {
            try
            {
                var _aclBranch = this._repository.GetById(id);
                if (_aclBranch == null)
                {
                    throw new Exception("Branch id Not Exist");
                }
                _aclBranch = PrepareInputData(request, _aclBranch);
                this.ApplicationResponse.Data = this._repository.Update(_aclBranch);
                this.ApplicationResponse.Message = _aclBranch != null ? this.messageResponse.editMessage : this.messageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = _aclBranch != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_EDIT", new { data = request, message = ex.Message, });
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse Find(uint id)
        {
            try
            {
                var aclCompanyModule = this._repository.GetById(id);
                var message = aclCompanyModule != null ? this.messageResponse.fetchMessage : this.messageResponse.notFoundMessage;
                this.ApplicationResponse.Data = aclCompanyModule;
                this.ApplicationResponse.Message = message;
                this.ApplicationResponse.StatusCode = aclCompanyModule != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
                this.ApplicationResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                this.ApplicationResponse.Timestamp = DateTime.Now;
            }
            return this.ApplicationResponse;
        }

        /// <inheritdoc/>
        public new ApplicationResponse Delete(uint id)
        {
            var aclCompanyModule = this._repository.Delete(id);
            this.ApplicationResponse.StatusCode = aclCompanyModule != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ApplicationResponse.Message = aclCompanyModule != null ? this.messageResponse.deleteMessage : this.messageResponse.notFoundMessage;
            this.ApplicationResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                this._repository.Delete(aclCompanyModule);
            }
            return this.ApplicationResponse;
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
