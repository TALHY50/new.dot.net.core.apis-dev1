using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserGroupRoleRepository : GenericRepository<AclUsergroupRole, ApplicationDbContext, ICustomUnitOfWork>, IAclUserGroupRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group Role";
        private ICustomUnitOfWork _customUnitOfWork;

        public AclUserGroupRoleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            this._customUnitOfWork = _unitOfWork;
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);

        }

        public async Task<AclResponse> GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = await this._customUnitOfWork.AclRoleRepository.Where(role => true)
                .Select(role => new { role.Id, role.Title }).ToListAsync();

            var associatedRoles = await this._customUnitOfWork.AclUserGroupRoleRepository
                .Where(ugr => ugr.UsergroupId == userGroupId)
                .Join(this._customUnitOfWork.AclRoleRepository
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
            var aclUserGroupRole = await this._customUnitOfWork.AclUserGroupRoleRepository
                .Where(x => x.UsergroupId == request.UserGroupId)
                .ToListAsync();

            var userGroupRoles = GetUserGroupRoles(request);
            var executionStrategy = this._customUnitOfWork.CreateExecutionStrategy();

            var aclResponse = new AclResponse(); // Assuming aclResponse is already defined

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await this._customUnitOfWork.BeginTransactionAsync())
                {
                    try
                    {
                        if (aclUserGroupRole.Any())
                        {
                            await this._customUnitOfWork.AclUserGroupRoleRepository.RemoveRange(aclUserGroupRole);
                            await this._customUnitOfWork.CompleteAsync();
                        }
                        await this._customUnitOfWork.AclUserGroupRoleRepository.AddRange(userGroupRoles);
                        await this._customUnitOfWork.CompleteAsync();
                        await this._customUnitOfWork.AclUserGroupRoleRepository.ReloadEntitiesAsync(userGroupRoles);
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
