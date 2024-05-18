﻿using ACL.Application.Enums;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using Microsoft.Extensions.Caching.Distributed;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclRoleRepository : IAclRoleRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Role";
        private readonly IDistributedCache _distributedCache;
        private ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclRoleRepository(ApplicationDbContext dbContext, IDistributedCache distributedCache)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            this._distributedCache = distributedCache;
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclRoles = All().Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).ToList();
            if (aclRoles.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclRoles;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclRoleRequest request)
        {

            var aclRole = PrepareInputData(request);
            this.aclResponse.Data = Add(aclRole);
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = Find(id);
            if (aclRole == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            _dbContext.AclRoles.Update(aclRole);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclRole).Reload();
            this.aclResponse.Data = aclRole;
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclRole = Find(id);

            this.aclResponse.Data = aclRole;
            this.aclResponse.Message = this.messageResponse.fetchMessage;
            if (aclRole == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
            }

            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclRole = Find(id);

            if (aclRole != null)
            {
                this.aclResponse.Data = Delete(id);
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
        /// <inheritdoc/>
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
    }
}