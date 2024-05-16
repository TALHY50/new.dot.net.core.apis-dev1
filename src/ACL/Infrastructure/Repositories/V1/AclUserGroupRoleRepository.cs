
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserGroupRoleRepository : IAclUserGroupRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group Role";
        ApplicationDbContext _dbcontext;

        public AclUserGroupRoleRepository(ApplicationDbContext dbcontext) 
        {
            _dbcontext = dbcontext;
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);

        }

        public async Task<AclResponse> GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = await _dbcontext.AclRoles
                .Select(role => new { role.Id, role.Title }).ToListAsync();

            var associatedRoles = await _dbcontext.AclUsergroupRoles.Where(ugr => ugr.UsergroupId == userGroupId)
                .Join(_dbcontext.AclRoles, ugr => ugr.RoleId, r => r.Id,
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
            var aclUserGroupRole = await _dbcontext.AclUsergroupRoles.Where(x => x.UsergroupId == request.UserGroupId).ToListAsync();

            var userGroupRoles = GetUserGroupRoles(request);
            var executionStrategy = _dbcontext.Database.CreateExecutionStrategy();

            var aclResponse = new AclResponse(); // Assuming aclResponse is already defined

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _dbcontext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (aclUserGroupRole.Any())
                        {
                             _dbcontext.AclUsergroupRoles.RemoveRange(aclUserGroupRole);
                            await _dbcontext.SaveChangesAsync();
                        }
                         _dbcontext.AclUsergroupRoles.AddRange(userGroupRoles);
                        await _dbcontext.SaveChangesAsync();
                        await ReloadEntitiesAsync(userGroupRoles);
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

        public async Task ReloadEntitiesAsync(IEnumerable<AclUsergroupRole> entities)
        {
            await Task.WhenAll(entities.Select(entity => _dbcontext.Entry(entity).ReloadAsync()));
        }


    }
}
