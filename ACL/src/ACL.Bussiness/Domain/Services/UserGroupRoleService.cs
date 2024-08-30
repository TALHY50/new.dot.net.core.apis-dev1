using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Infrastructure.Auth.Auth;
using ACL.Bussiness.Infrastructure.Persistence.Context;
using ACL.Bussiness.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Contracts.Common;

namespace ACL.Bussiness.Domain.Services
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    public class UserGroupRoleService : UserGroupRoleRepository, IUserGroupRoleService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "User Group Role";
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public new static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public UserGroupRoleService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, userRepository, httpContextAccessor)
        {
            this._userRepository = userRepository;
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.ScopeResponse = new ScopeResponse();
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public ScopeResponse GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = this._dbContext.AclRoles.Where(x => x.CompanyId == AppAuth.GetAuthInfo().CompanyId).Select(role => new { role.Id, role.Title }).ToList();
            var associatedRoles = All().Where(ugr => ugr.UsergroupId == userGroupId && ugr.CompanyId == AppAuth.GetAuthInfo().CompanyId)
                .Join(roles, ugr => ugr.RoleId, r => r.Id,
                (ugr, r) => new
                {
                    UsergroupId = ugr.UsergroupId,
                    RoleTitle = r.Title,
                    RoleId = ugr.RoleId
                }).ToList();
            this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            this.ScopeResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public Task<ScopeResponse> Update(AclUserGroupRoleRequest request)
        {

            var userGroupRoles = GetUserGroupRoles(request);
            var aclUserGroupRole = All().Where(x => x.UsergroupId == request.UserGroupId).ToList();
            var executionStrategy = this._dbContext.Database.CreateExecutionStrategy();

            executionStrategy.Execute(() =>
           {
               using var transaction = this._dbContext.Database.BeginTransaction();
               try
               {
                   if (aclUserGroupRole != null && aclUserGroupRole.Count != 0)
                   {
                       this._dbContext.AclUsergroupRoles.RemoveRange(aclUserGroupRole);
                       this._dbContext.SaveChanges();
                   }
                   this._dbContext.AclUsergroupRoles.AddRange(userGroupRoles);
                   this._dbContext.SaveChanges();
                   ReloadEntities(userGroupRoles);
                   this.ScopeResponse.Data = userGroupRoles;
                   this.ScopeResponse.Message = this.MessageResponse.createMessage;
                   this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                   List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, null, null, request.UserGroupId);
                   if (userIds != null)
                   {
                       this._userRepository.UpdateUserPermissionVersion(userIds);
                   }

                   transaction.Commit();
               }
               catch (Exception ex)
               {
                   transaction.Rollback();
                   this.ScopeResponse.Message = ex.Message;
                   this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
               }
           });

            return Task.FromResult(this.ScopeResponse);
        }


    }
}
