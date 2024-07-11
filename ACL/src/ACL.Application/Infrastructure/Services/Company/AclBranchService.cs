using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Company;
using Notification.Application.Domain.Ports.Repositories.Company;
using Notification.Application.Domain.Ports.Services.Company;
using Notification.Application.Infrastructure.Persistence.Configurations;
using Notification.Application.Infrastructure.Persistence.Repositories.Company;
using Notification.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Application.Infrastructure.Services.Company
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
            aclResponse = new AclResponse();
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            messageResponse = new MessageResponse(modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse Get()
        {
            var aclBranches = _repository.All();

            aclResponse.Message = aclBranches.Any() ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
            aclResponse.Data = aclBranches;
            aclResponse.StatusCode = aclBranches.Any() ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclBranchRequest request)
        {
            try
            {
                AclBranch _aclBranch = PrepareInputData(request);
                aclResponse.Data = _repository.Add(_aclBranch);
                aclResponse.Message = _aclBranch != null ? messageResponse.createMessage : messageResponse.createFail;

                aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_ADD", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclBranchRequest request)
        {
            try
            {
                var _aclBranch = _repository.GetById(id);
                if (_aclBranch == null)
                {
                    throw new Exception("Branch id Not Exist");
                }
                _aclBranch = PrepareInputData(request, _aclBranch);
                aclResponse.Data = _repository.Update(_aclBranch);
                aclResponse.Message = _aclBranch != null ? messageResponse.editMessage : messageResponse.notFoundMessage;
                aclResponse.StatusCode = _aclBranch != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                // base.Logger.LogError(ex, "Error at BRANCH_EDIT", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Find(ulong id)
        {
            try
            {
                var aclCompanyModule = _repository.GetById(id);
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

        /// <inheritdoc/>
        public new AclResponse Delete(ulong id)
        {
            var aclCompanyModule = _repository.Delete(id);
            aclResponse.StatusCode = aclCompanyModule != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Message = aclCompanyModule != null ? messageResponse.deleteMessage : messageResponse.notFoundMessage;
            aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                _repository.Delete(aclCompanyModule);
            }
            return aclResponse;
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
