using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Repositories.Auth;
using Notification.Application.Domain.Ports.Services.UserGroup;
using Notification.Application.Domain.UserGroup;
using Notification.Application.Infrastructure.Persistence.Configurations;
using Notification.Application.Infrastructure.Persistence.Repositories.UserGroup;
using Notification.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Application.Infrastructure.Services.UserGroup
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
            _aclUserRepository = aclUserRepository;
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclUsergroup>? result = All().Where(x => x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();
            if (result.Any())
            {
                aclResponse.Data = result;
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse AddUserGroup(AclUserGroupRequest usergroup)
        {
            try
            {
                AclUsergroup? result = PrepareInputData(usergroup);
                aclResponse.Data = Add(result);
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception)
            {
                aclResponse.Message = messageResponse.createFail;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
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
                aclResponse.Data = Update(result);
                aclResponse.Message = messageResponse.editMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
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
                aclResponse.Data = result;
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
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
                aclResponse.Data = Deleted(id);
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
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
