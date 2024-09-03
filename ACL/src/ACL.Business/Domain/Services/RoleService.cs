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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    public class RoleService : RoleRepository, IRoleService
    {
        public ScopeResponse ScopeResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role";
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public new static IHttpContextAccessor HttpContextAccessor;
        private enum RoleIds : uint { super_super_admin = 1, ADMIN_ROLE = 2 };
        public RoleService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, userRepository, httpContextAccessor)
        {
            this._userRepository = userRepository;
            this.ScopeResponse = new ScopeResponse();
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
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
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ScopeResponse.Data = aclRoles;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Add(AclRoleRequest request)
        {
            var aclRole = PrepareInputData(request);
            this.ScopeResponse.Data = Add(aclRole);
            this.ScopeResponse.Message = this.MessageResponse.createMessage;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Edit(uint id, AclRoleRequest request)
        {
            var aclRole = Find(id);

            if (aclRole == null)
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
                return this.ScopeResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            this._dbContext.AclRoles.Update(aclRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclRole).Reload();
            List<uint>? userIds = this._userRepository?.GetUserIdByChangePermission(null, null, null, id);
            if (userIds.Count() > 0)
            {
                this._userRepository.UpdateUserPermissionVersion(userIds);
            }
            this.ScopeResponse.Data = aclRole;
            this.ScopeResponse.Message = this.MessageResponse.editMessage;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse FindById(uint id)
        {

            var aclRole = Find(id);
            this.ScopeResponse.Data = aclRole;
            this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            if (aclRole == null)
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
            }
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse DeleteById(uint id)
        {
            var aclRole = Find(id);

            if (aclRole != null && !RoleIdNotToDelete(id))
            {
                this.ScopeResponse.Data = Delete(id);
                this.ScopeResponse.Message = this.MessageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, null, id);
                this._userRepository.UpdateUserPermissionVersion(userIds);
            }

            return this.ScopeResponse;

        }
        private Role PrepareInputData(AclRoleRequest request, Role? aclRole = null)
        {
            if (aclRole == null)
            {
                aclRole = new Role();
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
