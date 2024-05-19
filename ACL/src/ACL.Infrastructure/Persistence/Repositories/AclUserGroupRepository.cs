using ACL.Application.Ports.Repositories;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.UserGroup;
using ACL.Infrastructure.Persistence.Database;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories
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
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;

        /// <inheritdoc/>
        public AclUserGroupRepository(ApplicationDbContext dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclUsergroup>? result = All();
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
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse UpdateUserGroup(ulong id, AclUserGroupRequest usergroup)
        {
            AclUsergroup? result = Find(id);
            if (result != null)
            {
                result = PrepareInputData(usergroup, result);
                this.aclResponse.Data = Update(result);
                this.aclResponse.Message = this.messageResponse.editMessage;
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
        public AclResponse FindById(ulong id)
        {
            AclUsergroup? result = Find(id);
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
                this.aclResponse.Data = Deleted(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
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
        public AclUsergroup PrepareInputData(AclUserGroupRequest request, AclUsergroup aclUsergroup = null)
        {
            AclUsergroup? _aclInstance = aclUsergroup ?? new AclUsergroup();

            _aclInstance.Status = request.Status;
            _aclInstance.GroupName = request.GroupName;

            if (CompanyId == 0)
            {
                _aclInstance.CompanyId = AppAuth.GetAuthInfo().CompanyId; // We will get this from auth later
            }
            if (aclUsergroup == null)
            {
                _aclInstance.CreatedAt = DateTime.Now;
            }
            _aclInstance.UpdatedAt = DateTime.Now;

            return _aclInstance;
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
                return null;
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
                return null;
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
                return null;
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
                return null;
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
                return null;
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
                return null;
            }

        }
    }
}
