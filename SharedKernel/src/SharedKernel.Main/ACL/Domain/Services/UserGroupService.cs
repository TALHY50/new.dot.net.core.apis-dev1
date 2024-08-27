using Microsoft.AspNetCore.Http;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;
using SharedKernel.Main.ACL.Domain.Entities;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Context;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Infrastructure.Auth;

namespace SharedKernel.Main.ACL.Domain.Services
{
    public class UserGroupService : UserGroupRepository, IUserGroupService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "User Group";
        /// <inheritdoc/>
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public new static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public new readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public UserGroupService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, userRepository, httpContextAccessor)
        {
            this._userRepository = userRepository;
            this.ScopeResponse = new ScopeResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            List<Usergroup>? result = All().Where(x => x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();
            if (result.Any())
            {
                this.ScopeResponse.Data = result;
                this.ScopeResponse.Message = this.messageResponse.fetchMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.ScopeResponse.Message = this.messageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse AddUserGroup(AclUserGroupRequest usergroup)
        {
            try
            {
                Usergroup? result = PrepareInputData(usergroup);
                this.ScopeResponse.Data = Add(result);
                this.ScopeResponse.Message = this.messageResponse.createMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception)
            {
                this.ScopeResponse.Message = this.messageResponse.createFail;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse UpdateUserGroup(ulong id, AclUserGroupRequest userGroup)
        {
            Usergroup? result = Find(id);
            if (result != null)
            {
                bool isCompanyMatch = result.CompanyId == AppAuth.GetAuthInfo().CompanyId;
                if (!isCompanyMatch)
                {
                    result = null;
                }
            }
            if (result != null)
            {
                result = PrepareInputData(userGroup, result);
                this.ScopeResponse.Data = Update(result);
                this.ScopeResponse.Message = this.messageResponse.editMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.ScopeResponse.Message = this.messageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse FindById(ulong id)
        {
            Usergroup? result = Find(id);
            if (result != null)
            {
                bool isCompanyMatch = result.CompanyId == AppAuth.GetAuthInfo().CompanyId;
                if (!isCompanyMatch)
                {
                    result = null;
                }
            }
            if (result != null)
            {
                bool isCompanyMatch = result.CompanyId == AppAuth.GetAuthInfo().CompanyId;
                if (!isCompanyMatch)
                {
                    result = null;
                }
            }
            if (result != null)
            {
                this.ScopeResponse.Data = result;
                this.ScopeResponse.Message = this.messageResponse.fetchMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.ScopeResponse.Message = this.messageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Delete(ulong id)
        {
            Usergroup? result = Find(id);
            if (result != null)
            {
                bool isCompanyMatch = result.CompanyId == AppAuth.GetAuthInfo().CompanyId;
                if (!isCompanyMatch)
                {
                    result = null;
                }
            }
            if (result != null)
            {
                this.ScopeResponse.Data = Deleted(id);
                this.ScopeResponse.Message = this.messageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.ScopeResponse.Message = this.messageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public Usergroup PrepareInputData(AclUserGroupRequest request, Usergroup? aclUserGroup = null)
        {
            Usergroup? aclInstance = aclUserGroup ?? new Usergroup();

            aclInstance.Status = request.Status;
            aclInstance.GroupName = request.GroupName;

            if (CompanyId == 0)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                aclInstance.CompanyId = AppAuth.GetAuthInfo().CompanyId; // We will get this from auth later
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            else
            {
                aclInstance.CompanyId = CompanyId;
            }
            if (aclUserGroup == null)
            {
                aclInstance.CreatedAt = DateTime.Now;
            }
            aclInstance.UpdatedAt = DateTime.Now;

            return aclInstance;
        }
    }
}
