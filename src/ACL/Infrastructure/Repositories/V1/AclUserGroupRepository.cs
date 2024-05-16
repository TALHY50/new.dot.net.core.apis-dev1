using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserGroupRepository : IAclUserGroupRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group";
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;

        public readonly ApplicationDbContext _dbContext;

        public AclUserGroupRepository(ApplicationDbContext dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }

        public async Task<AclResponse> GetAll()
        {
            List<AclUsergroup>? result = _dbContext.AclUsergroups.ToList();
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
        public async Task<AclResponse> AddUserGroup(AclUserGroupRequest usergroup)
        {
            try
            {
                AclUsergroup? result = PrepareInputData(usergroup);
                await _dbContext.AclUsergroups.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(result).ReloadAsync();
                this.aclResponse.Data = result;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public async Task<AclResponse> UpdateUserGroup(ulong id, AclUserGroupRequest usergroup)
        {
            AclUsergroup? result = await _dbContext.AclUsergroups.FindAsync(id);
            if (result != null)
            {
                result = PrepareInputData(usergroup, result);
                _dbContext.AclUsergroups.Update(result);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(result).ReloadAsync();
                this.aclResponse.Data = result;
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
        public async Task<AclResponse> FindById(ulong id)
        {
            AclUsergroup? result = await _dbContext.AclUsergroups.FindAsync(id);
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
        public async Task<AclResponse> Delete(ulong id)
        {
            AclUsergroup? result = await _dbContext.AclUsergroups.FindAsync(id);
            if (result != null)
            {
                _dbContext.AclUsergroups.Remove(result);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(result).ReloadAsync();
                this.aclResponse.Data = result;
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

        public ulong SetCompanyId(ulong companyId)
        {
            CompanyId = companyId;
            return CompanyId;
        }
    }
}
