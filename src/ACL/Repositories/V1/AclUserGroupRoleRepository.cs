using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;
using ACL.Utilities;
using SharedLibrary.Services;
using ACL.Database;
using SharedLibrary.Response.CustomStatusCode;


namespace ACL.Repositories.V1
{
    public class AclUserGroupRoleRepository : GenericRepository<AclUsergroupRole, ApplicationDbContext, ICustomUnitOfWork>, IAclUserGroupRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group Role";
        private ICustomUnitOfWork _customUnitOfWork;

        public AclUserGroupRoleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);

        }

        public async Task<AclResponse> GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = await _customUnitOfWork.AclRoleRepository.Where(role => true)
                .Select(role => new { role.Id, role.Title }).ToListAsync();

            var associatedRoles = await _customUnitOfWork.AclUserGroupRoleRepository
                .Where(ugr => ugr.UsergroupId == userGroupId)
                .Join(_customUnitOfWork.AclRoleRepository
                .Where(role => true), ugr => ugr.RoleId, r => r.Id,
                (ugr, r) => new
                {
                    UsergroupId = ugr.UsergroupId,
                    RoleTitle = r.Title,
                    RoleId = ugr.RoleId
                }).ToListAsync();


            aclResponse.Message = messageResponse.fetchMessage;
            aclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return aclResponse;
        }
        public async Task<AclResponse> Update(AclUserGroupRoleRequest request)
        {
            var aclUserGroupRole = await _customUnitOfWork.AclUserGroupRoleRepository
                .Where(x => x.UsergroupId == request.UserGroupId)
                .ToListAsync();

            var userGroupRoles = GetUserGroupRoles(request);
            var executionStrategy = _customUnitOfWork.CreateExecutionStrategy();

            var aclResponse = new AclResponse(); // Assuming aclResponse is already defined

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _customUnitOfWork.BeginTransactionAsync())
                {
                    try
                    {
                        if (aclUserGroupRole.Any())
                        {
                            await _customUnitOfWork.AclUserGroupRoleRepository.RemoveRange(aclUserGroupRole);
                            await _customUnitOfWork.CompleteAsync();
                        }
                        await _customUnitOfWork.AclUserGroupRoleRepository.AddRange(userGroupRoles);
                        await _customUnitOfWork.CompleteAsync();
                        await _customUnitOfWork.AclUserGroupRoleRepository.ReloadEntitiesAsync(userGroupRoles);
                        aclResponse.Data = userGroupRoles;
                        aclResponse.Message = messageResponse.createMessage;
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
