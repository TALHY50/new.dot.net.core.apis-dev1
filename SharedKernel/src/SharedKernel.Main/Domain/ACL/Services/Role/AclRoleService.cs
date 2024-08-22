﻿using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Contracts.ACL.Requests;
using SharedKernel.Main.Contracts.ACL.Response;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Domain.ACL.Domain.Role;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Role;

namespace SharedKernel.Main.Domain.ACL.Services.Role
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    public class AclRoleService : AclRoleRepository, IAclRoleService
    {
        public AclResponse AclResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role";
        private readonly AclApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public new static IHttpContextAccessor HttpContextAccessor;
        private enum RoleIds : ulong { super_super_admin = 1, ADMIN_ROLE = 2 };
        public AclRoleService(AclApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, aclUserRepository, httpContextAccessor)
        {
            this._aclUserRepository = aclUserRepository;
            this.AclResponse = new AclResponse();
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
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
            var aclRole = Find(id);

            if (aclRole == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.NOTFOUND;
                return this.AclResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            this._dbContext.AclRoles.Update(aclRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclRole).Reload();
            List<ulong>? userIds = this._aclUserRepository?.GetUserIdByChangePermission(null, null, null, id);
            if (userIds.Count() > 0)
            {
                this._aclUserRepository.UpdateUserPermissionVersion(userIds);
            }
            this.AclResponse.Data = aclRole;
            this.AclResponse.Message = this.MessageResponse.editMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclRole = Find(id);
            this.AclResponse.Data = aclRole;
            this.AclResponse.Message = this.MessageResponse.fetchMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            if (aclRole == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.NOTFOUND;
            }
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclRole = Find(id);

            if (aclRole != null && !RoleIdNotToDelete(id))
            {
                this.AclResponse.Data = Delete(id);
                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(null, null, null, id);
                this._aclUserRepository.UpdateUserPermissionVersion(userIds);
            }

            return this.AclResponse;

        }
        private AclRole PrepareInputData(AclRoleRequest request, AclRole? aclRole = null)
        {
            if (aclRole == null)
            {
                aclRole = new AclRole();
                aclRole.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclRole.CreatedAt = DateTime.Now;
            }
            aclRole.Title = ExistByTitle(aclRole.Id, request.Title);
            aclRole.Name = ExistByName(aclRole.Id, request.Name);
            aclRole.Status = request.Status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }
    }
}