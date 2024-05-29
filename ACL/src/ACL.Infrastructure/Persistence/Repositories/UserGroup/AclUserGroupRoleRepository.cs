using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Role;
using ACL.Application.Ports.Repositories.UserGroup;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.UserGroup;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.UserGroup
{
    /// <inheritdoc/>
    public class AclUserGroupRoleRepository : IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "User Group Role";
        readonly ApplicationDbContext _dbContext;
        private readonly IAclRoleRepository _aclRoleRepository;
        private readonly IAclUserRepository _aclUserRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclUserGroupRoleRepository(ApplicationDbContext dbContext, IAclRoleRepository aclRoleRepository, IAclUserRepository aclUserRepository,IHttpContextAccessor httpContextAccessor)
        {
            _aclRoleRepository = aclRoleRepository;
            _aclUserRepository = aclUserRepository;
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);

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
            this.AclResponse.Message = this.MessageResponse.fetchMessage;
            this.AclResponse.Data = new { UsergroupRoles = associatedRoles, Roles = roles };
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public Task<AclResponse> Update(AclUserGroupRoleRequest request)
        {
            var aclUserGroupRole = All()?.Where(x => x.UsergroupId == request.UserGroupId).ToList();

            var userGroupRoles = GetUserGroupRoles(request);
            var executionStrategy = _dbContext.Database.CreateExecutionStrategy();

             executionStrategy.Execute( () =>
            {
                using var transaction =  _dbContext.Database.BeginTransaction();
                try
                {
                    if (aclUserGroupRole!=null && aclUserGroupRole.Count != 0)
                    {
                        _dbContext.AclUsergroupRoles.RemoveRange(aclUserGroupRole);
                        _dbContext.SaveChanges();
                    }
                    _dbContext.AclUsergroupRoles.AddRange(userGroupRoles);
                     _dbContext.SaveChanges();
                     ReloadEntities(userGroupRoles);
                    AclResponse.Data = userGroupRoles;
                    AclResponse.Message = this.MessageResponse.createMessage;
                    AclResponse.StatusCode = AppStatusCode.SUCCESS;
                    List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null,null,null, request.UserGroupId);
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

        public async Task ReloadEntitiesAsync(IEnumerable<AclUsergroupRole> entities)
        {
            await Task.WhenAll(entities.Select(entity => _dbContext.Entry(entity).ReloadAsync()));
        }

        public Task ReloadEntities(IEnumerable<AclUsergroupRole> entities)
        {
            return Task.WhenAll(entities.Select(entity => _dbContext.Entry(entity).ReloadAsync()));
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
                throw new Exception();
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
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Add(AclUsergroupRole aclUserGroupRole)
        {
            try
            {
                _dbContext.AclUsergroupRoles.Add(aclUserGroupRole);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUserGroupRole).Reload();
                return aclUserGroupRole;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Update(AclUsergroupRole aclUserGroupRole)
        {
            try
            {
                _dbContext.AclUsergroupRoles.Update(aclUserGroupRole);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclUserGroupRole).Reload();
                return aclUserGroupRole;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroupRole? Delete(AclUsergroupRole aclUserGroupRole)
        {
            try
            {
                _dbContext.AclUsergroupRoles.Remove(aclUserGroupRole);
                _dbContext.SaveChanges();
                return aclUserGroupRole;
            }
            catch (Exception)
            {
                throw new Exception();
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
                throw new Exception();
            }
        }
    }
}
