
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Interfaces.Repositories.V1;
using Microsoft.EntityFrameworkCore;
using ACL.Utilities;


namespace ACL.Repositories.V1
{
    public class AclUserGroupRoleRepository : GenericRepository<AclUsergroupRole>, IAclUserGroupRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "UserGroupRole";
        public AclUserGroupRoleRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);

        }

        public async Task<AclResponse> GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = await _unitOfWork.ApplicationDbContext.AclRoles.Select(role => new { role.Id, role.Title }).ToListAsync();
            var associatedRoles = _unitOfWork.ApplicationDbContext.AclUsergroupRoles
                                   .Where(usergroupRole => usergroupRole.UsergroupId == userGroupId)
                                   .Join(_unitOfWork.ApplicationDbContext.AclRoles,
                                          usergroupRole => usergroupRole.RoleId,
                                          role => role.Id,
                                          (usergroupRole, role) => new
                                          {
                                              UsergroupId = usergroupRole.UsergroupId,
                                              RoleTitle = role.Title,
                                              RoleId = usergroupRole.RoleId
                                          })
                                   .ToList();


            aclResponse.Message = messageResponse.fetchMessage;
            aclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

            return aclResponse;
        }
        public async Task<AclResponse> Update(AclUserGroupRoleRequest request)
        {

            var aclUserGroupRole = await _unitOfWork.ApplicationDbContext.AclUsergroupRoles.Where(x => x.UsergroupId == request.user_group_id).ToListAsync();
            var userGroupRoles = GetUserGroupRoles(request);
            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync())
                {

                    try
                    {
                        if (aclUserGroupRole.Any())
                        {
                            await base.RemoveRange(aclUserGroupRole);
                            await _unitOfWork.CompleteAsync();
                        }
                        await base.AddRange(userGroupRoles);
                        await _unitOfWork.CompleteAsync();
                        await base.ReloadEntitiesAsync(userGroupRoles);
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
