using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Utilities;
using SharedLibrary.Services;
using ACL.Database;
using SharedLibrary.Response.CustomStatusCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ACL.Application.Enums;
using ACL.Core.Models;

namespace ACL.Repositories.V1
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
            _customUnitOfWork = _unitOfWork;
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
            _distributedCache = distributedCache;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclRoles = await _customUnitOfWork.AclRoleRepository.Where(x => true).Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).ToListAsync();
            if (aclRoles.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclRoles;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclRoleRequest request)
        {

            var aclRole = PrepareInputData(request);
            await base.AddAsync(aclRole);
            await _unitOfWork.CompleteAsync();
            await _customUnitOfWork.AclRoleRepository.ReloadAsync(aclRole);
            aclResponse.Data = aclRole;
            aclResponse.Message = messageResponse.createMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return aclResponse;

        }
        public async Task<AclResponse> Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = await base.GetById(id);
            if (aclRole == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                return aclResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            await base.UpdateAsync(aclRole);
            await _unitOfWork.CompleteAsync();
            await _customUnitOfWork.AclRoleRepository.ReloadAsync(aclRole);
            aclResponse.Data = aclRole;
            aclResponse.Message = messageResponse.editMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return aclResponse;

        }
        public async Task<AclResponse> FindById(ulong id)
        {

            var aclRole = await _customUnitOfWork.AclRoleRepository.Where(x => true).Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).FirstOrDefaultAsync(x => x.Id == id);

            aclResponse.Data = aclRole;
            aclResponse.Message = messageResponse.fetchMessage;
            if (aclRole == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
            }

            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclRole = await base.GetById(id);

            if (aclRole != null)
            {
                await base.DeleteAsync(aclRole);
                await _unitOfWork.CompleteAsync();
                RemoveCache(id);
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return aclResponse;

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
