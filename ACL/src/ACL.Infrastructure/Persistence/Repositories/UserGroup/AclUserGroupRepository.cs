using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.UserGroup;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.UserGroup;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.UserGroup
{
    /// <inheritdoc/>
    public class AclUserGroupRepository : IAclUserGroupRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "User Group";
        /// <inheritdoc/>
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public AclUserGroupRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclUsergroup>? result = All().Where(x=>x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();
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
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null,null,null,id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
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
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, null, null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
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
        /// <inheritdoc/>
        public ulong SetCompanyId(ulong companyId)
        {
            CompanyId = companyId;
            return CompanyId;
        }
        /// <inheritdoc/>
        public List<AclUsergroup>? All()
        {
            try
            {
                return _dbContext.AclUsergroups.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Find(ulong id)
        {
            try
            {
                return _dbContext.AclUsergroups.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Add(AclUsergroup aclUsergroup)
        {
            try
            {
                _dbContext.AclUsergroups.Add(aclUsergroup);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUsergroup).Reload();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroup? Update(AclUsergroup aclUsergroup)
        {
            try
            {
                _dbContext.AclUsergroups.Update(aclUsergroup);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUsergroup).Reload();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroup? Delete(AclUsergroup aclUsergroup)
        {
            try
            {
                _dbContext.AclUsergroups.Remove(aclUsergroup);
                _dbContext.SaveChanges();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Deleted(ulong id)
        {
            try
            {
                var delete = Find(id);
                _dbContext.AclUsergroups.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsExist(ulong id)
        {
            return _dbContext.AclUserUsergroups.Any(m=> m.Id == id);
        }
    }
}
