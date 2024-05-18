using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.UseCases.Interfaces.Repositories.V1;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclUserGroupRoleRepository : IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private readonly string modelName = "User Group Role";
        readonly ApplicationDbContext _dbContext;
        private IAclRoleRepository _aclRoleRepository;
        /// <inheritdoc/>
        public AclUserGroupRoleRepository(ApplicationDbContext dbcontext, IAclRoleRepository aclRoleRepository)
        {
            _aclRoleRepository = aclRoleRepository;
            _dbContext = dbcontext;
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);

        }
        /// <inheritdoc/>
        public AclResponse GetRolesByUserGroupId(ulong userGroupId)
        {
            var roles = _aclRoleRepository.All().Select(role => new { role.Id, role.Title }).ToList();
            var associatedRoles = All().Where(ugr => ugr.UsergroupId == userGroupId)
                .Join(_dbContext.AclRoles, ugr => ugr.RoleId, r => r.Id,
                (ugr, r) => new
                {
                    UsergroupId = ugr.UsergroupId,
                    RoleTitle = r.Title,
                    RoleId = ugr.RoleId
                }).ToList();
            this.aclResponse.Message = this.messageResponse.fetchMessage;
            this.aclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> Update(AclUserGroupRoleRequest request)
        {
            var aclUserGroupRole = All().Where(x => x.UsergroupId == request.UserGroupId).ToList();

            var userGroupRoles = GetUserGroupRoles(request);
            var executionStrategy = _dbContext.Database.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (aclUserGroupRole.Any())
                        {
                            _dbContext.AclUsergroupRoles.RemoveRange(aclUserGroupRole);
                            _dbContext.SaveChanges();
                        }
                        _dbContext.AclUsergroupRoles.AddRange(userGroupRoles);
                        await _dbContext.SaveChangesAsync();
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



        private static AclUsergroupRole[] GetUserGroupRoles(AclUserGroupRoleRequest request)
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
        /// <inheritdoc/>
        public async Task ReloadEntitiesAsync(IEnumerable<AclUsergroupRole> entities)
        {
            await Task.WhenAll(entities.Select(entity => _dbContext.Entry(entity).ReloadAsync()));
        }
        /// <inheritdoc/>
        public List<AclUsergroupRole>? All()
        {
            try
            {
                return _dbContext.AclUsergroupRoles.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Find(ulong id)
        {
            try
            {
                return _dbContext.AclUsergroupRoles.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Add(AclUsergroupRole aclUsergroupRole)
        {
            try
            {
                _dbContext.AclUsergroupRoles.Add(aclUsergroupRole);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUsergroupRole).Reload();
                return aclUsergroupRole;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Update(AclUsergroupRole aclUsergroupRole)
        {
            try
            {
                _dbContext.AclUsergroupRoles.Update(aclUsergroupRole);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUsergroupRole).Reload();
                return aclUsergroupRole;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Delete(AclUsergroupRole aclUsergroupRole)
        {
            try
            {
                _dbContext.AclUsergroupRoles.Remove(aclUsergroupRole);
                _dbContext.SaveChanges();
                return aclUsergroupRole;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclUsergroupRole? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                _dbContext.AclUsergroupRoles.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
