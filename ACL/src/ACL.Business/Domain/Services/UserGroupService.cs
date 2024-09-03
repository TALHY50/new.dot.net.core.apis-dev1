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
    public class UserGroupService : UserGroupRepository, IUserGroupService
    {
        /// <inheritdoc/>
        public ApplicationResponse ApplicationResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "User Group";
        /// <inheritdoc/>
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public new static uint CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public new readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public UserGroupService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, userRepository, httpContextAccessor)
        {
            this._userRepository = userRepository;
            this.ApplicationResponse = new ApplicationResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public ApplicationResponse GetAll()
        {
            List<Usergroup>? result = All().Where(x => x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();
            if (result.Any())
            {
                this.ApplicationResponse.Data = result;
                this.ApplicationResponse.Message = this.messageResponse.fetchMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            else
            {
                this.ApplicationResponse.Message = this.messageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse AddUserGroup(AclUserGroupRequest usergroup)
        {
            try
            {
                Usergroup? result = PrepareInputData(usergroup);
                this.ApplicationResponse.Data = Add(result);
                this.ApplicationResponse.Message = this.messageResponse.createMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception)
            {
                this.ApplicationResponse.Message = this.messageResponse.createFail;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse UpdateUserGroup(uint id, AclUserGroupRequest userGroup)
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
                this.ApplicationResponse.Data = Update(result);
                this.ApplicationResponse.Message = this.messageResponse.editMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.ApplicationResponse.Message = this.messageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse FindById(uint id)
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
                this.ApplicationResponse.Data = result;
                this.ApplicationResponse.Message = this.messageResponse.fetchMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            else
            {
                this.ApplicationResponse.Message = this.messageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse Delete(uint id)
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
                this.ApplicationResponse.Data = Deleted(id);
                this.ApplicationResponse.Message = this.messageResponse.deleteMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.ApplicationResponse.Message = this.messageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
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
