using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserGroupRoleRepository : GenericRepository<AclUsergroupRole>, IAclUserGroupRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group Role";
        private IAclRoleRepository AclRoleRepository;

        public AclUserGroupRoleRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);

        }

        public async Task<AclResponse> GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = await AclRoleRepository.Where(role => true)
                .Select(role => new { role.Id, role.Title }).ToListAsync();

            var associatedRoles = await base
                .Where(ugr => ugr.UsergroupId == userGroupId)
                .Join(AclRoleRepository
                .Where(role => true), ugr => ugr.RoleId, r => r.Id,
                (ugr, r) => new
                {
                    UsergroupId = ugr.UsergroupId,
                    RoleTitle = r.Title,
                    RoleId = ugr.RoleId
                }).ToListAsync();


            this.aclResponse.Message = this.messageResponse.fetchMessage;
            this.aclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;
        }
        public async Task<AclResponse> Update(AclUserGroupRoleRequest request)
        {
            var aclUserGroupRole = await base
                .Where(x => x.UsergroupId == request.UserGroupId)
                .ToListAsync();

            var userGroupRoles = GetUserGroupRoles(request);
            var executionStrategy = base.CreateExecutionStrategy();

            var aclResponse = new AclResponse(); // Assuming aclResponse is already defined

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await base.BeginTransactionAsync())
                {
                    try
                    {
                        if (aclUserGroupRole.Any())
                        {
                            await base.RemoveRange(aclUserGroupRole);
                            await base.CompleteAsync();
                        }
                        await base.AddRange(userGroupRoles);
                        await base.CompleteAsync();
                        await base.ReloadEntitiesAsync(userGroupRoles);
                        aclResponse.Data = userGroupRoles;
                        aclResponse.Message = this.messageResponse.createMessage;
                        aclResponse.StatusCode = AppStatusCode.SUCCESS;
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        aclResponse.Message = ex.Message;
                        aclResponse.StatusCode = AppStatusCode.FAIL;
                    }
                }
            });

            return aclResponse;
        }



        private AclUsergroupRole[] GetUserGroupRoles(AclUserGroupRoleRequest request)
        {

            var userGroupRoles = request.RoleIds.Select(roleId => new AclUsergroupRole
            {
                UsergroupId = request.UserGroupId,
                RoleId = roleId,
                CompanyId = AppAuth.GetAuthInfo().CompanyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }).ToArray();

            return userGroupRoles;
        }


    }
}
