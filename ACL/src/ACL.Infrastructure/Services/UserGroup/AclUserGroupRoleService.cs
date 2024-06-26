using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Services.UserGroup;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Persistence.Repositories.UserGroup;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Infrastructure.Services.UserGroup
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
            _aclUserRepository = aclUserRepository;
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            AclResponse = new AclResponse();
            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = _dbContext.AclRoles.Where(x => x.CompanyId == AppAuth.GetAuthInfo().CompanyId).Select(role => new { role.Id, role.Title }).ToList();
            var associatedRoles = All().Where(ugr => ugr.UsergroupId == userGroupId && ugr.CompanyId == AppAuth.GetAuthInfo().CompanyId)
                .Join(roles, ugr => ugr.RoleId, r => r.Id,
                (ugr, r) => new
                {
                    UsergroupId = ugr.UsergroupId,
                    RoleTitle = r.Title,
                    RoleId = ugr.RoleId
                }).ToList();
            AclResponse.Message = MessageResponse.fetchMessage;
            AclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return AclResponse;
        }
        /// <inheritdoc/>
        public Task<AclResponse> Update(AclUserGroupRoleRequest request)
        {

            var userGroupRoles = GetUserGroupRoles(request);
            var aclUserGroupRole = All().Where(x => x.UsergroupId == request.UserGroupId).ToList();
            var executionStrategy = _dbContext.Database.CreateExecutionStrategy();

            executionStrategy.Execute(() =>
           {
               using var transaction = _dbContext.Database.BeginTransaction();
               try
               {
                   if (aclUserGroupRole != null && aclUserGroupRole.Count != 0)
                   {
                       _dbContext.AclUsergroupRoles.RemoveRange(aclUserGroupRole);
                       _dbContext.SaveChanges();
                   }
                   _dbContext.AclUsergroupRoles.AddRange(userGroupRoles);
                   _dbContext.SaveChanges();
                   ReloadEntities(userGroupRoles);
                   AclResponse.Data = userGroupRoles;
                   AclResponse.Message = MessageResponse.createMessage;
                   AclResponse.StatusCode = AppStatusCode.SUCCESS;
                   List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, null, null, request.UserGroupId);
                   if (userIds != null)
                   {
                       _aclUserRepository.UpdateUserPermissionVersion(userIds);
                   }

                   transaction.Commit();
               }
               catch (Exception ex)
               {
                   transaction.Rollback();
                   AclResponse.Message = ex.Message;
                   AclResponse.StatusCode = AppStatusCode.FAIL;
               }
           });

            return Task.FromResult(AclResponse);
        }


    }
}
