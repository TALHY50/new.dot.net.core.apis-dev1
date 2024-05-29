using ACL.Application.Enums;
using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Role;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Role
{
    /// <inheritdoc/>
    public class AclRoleRepository : IAclRoleRepository
    {
        public AclResponse AclResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role";
        private readonly IDistributedCache _distributedCache;
        private readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        public AclRoleRepository(ApplicationDbContext dbContext, IDistributedCache distributedCache, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclRoles = All().Where(c => c.CreatedById == AppAuth.GetAuthInfo().UserId).Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).ToList();
            if (aclRoles.Any())
            {
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.AclResponse.Data = aclRoles;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclRoleRequest request)
        {

            var aclRole = PrepareInputData(request);
            this.AclResponse.Data = Add(aclRole);
            this.AclResponse.Message = this.MessageResponse.createMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = Find(id) is var role && role.CreatedById == AppAuth.GetAuthInfo().UserId ? role : null;

            if (aclRole == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                return this.AclResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            _dbContext.AclRoles.Update(aclRole);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclRole).Reload();
            List<ulong>? userIds = _aclUserRepository?.GetUserIdByChangePermission(null, null, null, id);
            _aclUserRepository.UpdateUserPermissionVersion(userIds);
            this.AclResponse.Data = aclRole;
            this.AclResponse.Message = this.MessageResponse.editMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclRole = Find(id) is var role && role.CreatedById == AppAuth.GetAuthInfo().UserId ? role : null;


            this.AclResponse.Data = aclRole;
            this.AclResponse.Message = this.MessageResponse.fetchMessage;
            if (aclRole == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
            }

            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclRole = Find(id) is var role && role.CreatedById == AppAuth.GetAuthInfo().UserId ? role : null;


            if (aclRole != null)
            {
                this.AclResponse.Data = Delete(id);
                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, null, id);
                _aclUserRepository.UpdateUserPermissionVersion(userIds);
            }

            return this.AclResponse;

        }
        private AclRole PrepareInputData(AclRoleRequest request, AclRole? aclRole = null)
        {
            aclRole ??= new AclRole
                {
                    CreatedById = AppAuth.GetAuthInfo().UserId,
                    CreatedAt = DateTime.Now
                };
            aclRole.Title = request.Title;
            aclRole.Name = request.Name;
            aclRole.Status = request.Status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }
  
        private async Task RemoveCache(ulong roleId)
        {
            var key = $"{Enum.GetName(CacheKeys.RoleRouteNames)}-{roleId}";
            if (_distributedCache is IDistributedCache)
            {
                var cachedRouteNames = await this._distributedCache.GetStringAsync(key);
                if (cachedRouteNames != null)
                {
                    await this._distributedCache.RemoveAsync(key);
                }
            }
        }

        /// <inheritdoc/>
        public AclRole? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclRoles.Find(id);
                _dbContext.AclRoles.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public List<AclRole>? All()
        {
            try
            {
                return _dbContext.AclRoles.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclRole? Find(ulong id)
        {
            try
            {
                return _dbContext.AclRoles.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclRole? Add(AclRole aclRole)
        {
            try
            {
                _dbContext.AclRoles.Add(aclRole);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclRole).ReloadAsync();
                return aclRole;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclRole? Update(AclRole aclRole)
        {
            try
            {
                _dbContext.AclRoles.Update(aclRole);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclRole).Reload();
                return aclRole;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclRole? Delete(AclRole aclRole)
        {
            try
            {
                _dbContext.AclRoles.Remove(aclRole);
                _dbContext.SaveChangesAsync();
                return aclRole;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IsExist(ulong id)
        {
            return _dbContext.AclRoles.Any(i => i.Id == id);
        }
    }
}
