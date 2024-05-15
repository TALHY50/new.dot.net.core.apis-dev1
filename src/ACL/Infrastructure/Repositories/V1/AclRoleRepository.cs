using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.UseCases.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclRoleRepository : GenericRepository<AclRole, ApplicationDbContext, ICustomUnitOfWork>, IAclRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role";
        private ICustomUnitOfWork _customUnitOfWork;
        private readonly IDistributedCache _distributedCache;
        public AclRoleRepository(ICustomUnitOfWork _unitOfWork, IDistributedCache distributedCache) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            this._customUnitOfWork = _unitOfWork;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclRoles = await this._customUnitOfWork.AclRoleRepository.Where(x => true).Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).ToListAsync();
            if (aclRoles.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclRoles;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;
        }
        public async Task<AclResponse> Add(AclRoleRequest request)
        {

            var aclRole = PrepareInputData(request);
            await base.AddAsync(aclRole);
            await this._unitOfWork.CompleteAsync();
            await this._customUnitOfWork.AclRoleRepository.ReloadAsync(aclRole);
            this.aclResponse.Data = aclRole;
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.aclResponse;

        }
        public async Task<AclResponse> Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = await base.GetById(id);
            if (aclRole == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            await base.UpdateAsync(aclRole);
            await this._unitOfWork.CompleteAsync();
            await this._customUnitOfWork.AclRoleRepository.ReloadAsync(aclRole);
            this.aclResponse.Data = aclRole;
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.aclResponse;

        }
        public async Task<AclResponse> FindById(ulong id)
        {

            var aclRole = await this._customUnitOfWork.AclRoleRepository.Where(x => true).Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).FirstOrDefaultAsync(x => x.Id == id);

            this.aclResponse.Data = aclRole;
            this.aclResponse.Message = this.messageResponse.fetchMessage;
            if (aclRole == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
            }

            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclRole = await base.GetById(id);

            if (aclRole != null)
            {
                await base.DeleteAsync(aclRole);
                await this._unitOfWork.CompleteAsync();
                RemoveCache(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

        }
        private AclRole PrepareInputData(AclRoleRequest request, AclRole aclRole = null)
        {
            if (aclRole == null)
            {
                aclRole = new AclRole();
                aclRole.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclRole.CreatedAt = DateTime.Now;
            }
            aclRole.Title = request.Title;
            aclRole.Name = request.Name;
            aclRole.Status = request.Status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }

        private void RemoveCache(ulong roleId)
        {
            var key = $"{Enum.GetName(CacheKeys.RoleRouteNames)}-{roleId}";
            if (this._distributedCache is IDistributedCache)
            {
                var cachedRouteNames = this._distributedCache.GetStringAsync(key);
                if (cachedRouteNames != null)
                {
                    this._distributedCache.RemoveAsync(key);
                }
            }
        }


    }
}
