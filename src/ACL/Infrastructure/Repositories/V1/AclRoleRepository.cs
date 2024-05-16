using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using ACL.UseCases.Enums;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclRoleRepository : IAclRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role";
        private readonly IDistributedCache _distributedCache;
        private ApplicationDbContext _dbContext;
        public AclRoleRepository(ApplicationDbContext dbContext, IDistributedCache distributedCache)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
            _dbContext = dbContext;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclRoles = _dbContext.AclRoles.Where(x => true).Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).ToListAsync();
            if (aclRoles.Result.Any())
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
            await _dbContext.AclRoles.AddAsync(aclRole);
            _dbContext.SaveChanges();
            await _dbContext.Entry(aclRole).ReloadAsync();
            this.aclResponse.Data = aclRole;
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.aclResponse;

        }
        public async Task<AclResponse> Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = _dbContext.AclRoles.Find(id);
            if (aclRole == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            _dbContext.AclRoles.Update(aclRole);
            _dbContext.SaveChanges();
            await _dbContext.Entry(aclRole).ReloadAsync();
            this.aclResponse.Data = aclRole;
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.aclResponse;

        }
        public async Task<AclResponse> FindById(ulong id)
        {

            var aclRole = await _dbContext.AclRoles.Where(x => true).Select(x => new
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
            var aclRole = _dbContext.AclRoles.Find(id);

            if (aclRole != null)
            {
                _dbContext.AclRoles.Remove(aclRole);
                _dbContext.SaveChanges();
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
