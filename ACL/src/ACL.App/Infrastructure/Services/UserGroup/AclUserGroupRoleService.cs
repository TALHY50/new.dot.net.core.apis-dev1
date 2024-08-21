using ACL.App.Application.Interfaces.Repositories.Auth;
using ACL.App.Application.Interfaces.Services.UserGroup;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Persistence.Repositories.UserGroup;
using ACL.App.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;

namespace ACL.App.Infrastructure.Services.UserGroup
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    public class AclUserGroupRoleService : AclUserGroupRoleRepository, IAclUserGroupRoleService
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "User Group Role";
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public new static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclUserGroupRoleService(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, aclUserRepository, httpContextAccessor)
        {
            this._aclUserRepository = aclUserRepository;
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.AclResponse = new AclResponse();
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse GetRolesByUserGroupId(ulong userGroupId)
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
            this.AclResponse.Message = this.MessageResponse.fetchMessage;
            this.AclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public Task<AclResponse> Update(AclUserGroupRoleRequest request)
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
                   this.AclResponse.Data = userGroupRoles;
                   this.AclResponse.Message = this.MessageResponse.createMessage;
                   this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                   List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(null, null, null, null, request.UserGroupId);
                   if (userIds != null)
                   {
                       this._aclUserRepository.UpdateUserPermissionVersion(userIds);
                   }

                   transaction.Commit();
               }
               catch (Exception ex)
               {
                   transaction.Rollback();
                   this.AclResponse.Message = ex.Message;
                   this.AclResponse.StatusCode = AppStatusCode.FAIL;
               }
           });

            return Task.FromResult(this.AclResponse);
        }


    }
}
