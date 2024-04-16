
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Interfaces.Repositories.V1;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.Design;
using Org.BouncyCastle.Ocsp;


namespace ACL.Repositories.V1
{
    public class AclUserGroupRoleRepository :GenericRepository<AclUsergroupRole>, IAclUserGroupRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User Group Role";
        private ulong companyId = 2;

        public AclUserGroupRoleRepository(IUnitOfWork _unitOfWork):base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }

        public AclResponse GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = _unitOfWork.ApplicationDbContext.AclRoles.Select(role => new { role.Id, role.Title }).ToList();
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
            using (var transaction = _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (aclUserGroupRole.Any())
                    {
                        _unitOfWork.ApplicationDbContext.AclUsergroupRoles.RemoveRange(aclUserGroupRole);
                    }
                     _unitOfWork.ApplicationDbContext.AclUsergroupRoles.AddRange(userGroupRoles);
                    await _unitOfWork.CommitTransactionAsync();
                    await ReloadEntitiesAsync(userGroupRoles);
                    aclResponse.Data = userGroupRoles;
                    aclResponse.Message = messageResponse.createMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }

            }
            await _unitOfWork.CompleteAsync();
            return aclResponse;
        }


        private AclUsergroupRole[] GetUserGroupRoles(AclUserGroupRoleRequest request)
        {

            var userGroupRoles = request.role_ids.Select(roleId => new AclUsergroupRole
            {
                UsergroupId = request.user_group_id,
                RoleId = roleId,
                CompanyId = companyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }).ToArray();

            return userGroupRoles;
        }

        public async Task ReloadEntitiesAsync(IEnumerable<AclUsergroupRole> entities)
        {
            foreach (var entity in entities)
            {
                await _unitOfWork.ApplicationDbContext.Entry(entity).ReloadAsync();
            }
        }


    }
}
