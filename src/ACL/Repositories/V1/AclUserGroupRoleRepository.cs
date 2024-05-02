﻿
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Interfaces.Repositories.V1;
using Microsoft.EntityFrameworkCore;
using ACL.Utilities;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Services;


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
            var roles = await _customUnitOfWork.AclRoleRepository
        .Where(role => true) // Replace 'true' with your actual filter condition
        .Select(role => new { role.Id, role.Title }) // Project the selected properties
        .ToListAsync();
            var associatedRoles = await _customUnitOfWork.AclUserGroupRoleRepository
        .Where(usergroupRole => usergroupRole.UsergroupId == userGroupId)
        .Join(
            _customUnitOfWork.AclRoleRepository.Where(role => true), // Replace 'true' with your actual filter condition
            usergroupRole => usergroupRole.RoleId,
            role => role.Id,
            (usergroupRole, role) => new
            {
                UsergroupId = usergroupRole.UsergroupId,
                RoleTitle = role.Title,
                RoleId = usergroupRole.RoleId
            })
        .ToListAsync();


            aclResponse.Message = messageResponse.fetchMessage;
            aclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

            return aclResponse;
        }
        public async Task<AclResponse> Update(AclUserGroupRoleRequest request)
        {
            var aclUserGroupRole = await _customUnitOfWork.AclUserGroupRoleRepository
                .Where(x => x.UsergroupId == request.user_group_id)
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
                        aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        aclResponse.Message = ex.Message;
                        aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
            });

            return aclResponse;
        }



        private AclUsergroupRole[] GetUserGroupRoles(AclUserGroupRoleRequest request)
        {

            var userGroupRoles = request.role_ids.Select(roleId => new AclUsergroupRole
            {
                UsergroupId = request.user_group_id,
                RoleId = roleId,
                CompanyId = AppAuth.GetAuthInfo().CompanyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }).ToArray();

            return userGroupRoles;
        }


    }
}
