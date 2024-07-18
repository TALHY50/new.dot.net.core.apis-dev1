using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Auth;
using App.Domain.Ports.Services.UserGroup;
using App.Domain.UserGroup;
using App.Infrastructure.Persistence.Configurations;
using App.Infrastructure.Persistence.Repositories.UserGroup;
using App.Infrastructure.Utilities;
using SharedKernel.Contracts.Response;

namespace App.Infrastructure.Services.UserGroup
{
    public class AclUserGroupService : AclUserGroupRepository, IAclUserGroupService
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "User Group";
        /// <inheritdoc/>
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public new static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public new readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public AclUserGroupService(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, aclUserRepository, httpContextAccessor)
        {
            this._aclUserRepository = aclUserRepository;
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclUsergroup>? result = All().Where(x => x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();
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
        /// <inheritdoc/>
        public AclResponse AddUserGroup(AclUserGroupRequest usergroup)
        {
            try
            {
                AclUsergroup? result = PrepareInputData(usergroup);
                this.aclResponse.Data = Add(result);
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception)
            {
                this.aclResponse.Message = this.messageResponse.createFail;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse UpdateUserGroup(ulong id, AclUserGroupRequest userGroup)
        {
            AclUsergroup? result = Find(id);
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
                this.aclResponse.Data = Update(result);
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    this._aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            AclUsergroup? result = Find(id);
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
        /// <inheritdoc/>
        public AclResponse Delete(ulong id)
        {
            AclUsergroup? result = Find(id);
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
                this.aclResponse.Data = Deleted(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    this._aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclUsergroup PrepareInputData(AclUserGroupRequest request, AclUsergroup? aclUserGroup = null)
        {
            AclUsergroup? aclInstance = aclUserGroup ?? new AclUsergroup();

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
