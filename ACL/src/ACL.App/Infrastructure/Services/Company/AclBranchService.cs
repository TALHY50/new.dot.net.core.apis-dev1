using ACL.App.Application.Interfaces.Repositories.Company;
using ACL.App.Application.Interfaces.Services.Company;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Persistence.Repositories.Company;
using ACL.App.Infrastructure.Utilities;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace ACL.App.Infrastructure.Services.Company
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
            this._repository = repository;
            this.aclResponse = new AclResponse();
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse Get()
        {
            var aclBranches = this._repository.All();

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
                this.aclResponse.Data = this._repository.Add(_aclBranch);
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
                var _aclBranch = this._repository.GetById(id);
                if (_aclBranch == null)
                {
                    throw new Exception("Branch id Not Exist");
                }
                _aclBranch = PrepareInputData(request, _aclBranch);
                this.aclResponse.Data = this._repository.Update(_aclBranch);
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
                var aclCompanyModule = this._repository.GetById(id);
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
            var aclCompanyModule = this._repository.Delete(id);
            this.aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Message = aclCompanyModule != null ? this.messageResponse.deleteMessage : this.messageResponse.notFoundMessage;
            this.aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                this._repository.Delete(aclCompanyModule);
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
