using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Services.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Role;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Persistence.Repositories.Role;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Infrastructure.Services.Role
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    public class AclRoleService : AclRoleRepository, IAclRoleService
    {
        public AclResponse AclResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role";
        private readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public new static IHttpContextAccessor HttpContextAccessor;
        private enum RoleIds : ulong { super_super_admin = 1, ADMIN_ROLE = 2 };
        public AclRoleService(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, aclUserRepository, httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            AclResponse = new AclResponse();
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclRoles = All().Select(x => new
            {
                x.Id,
                x.Name,
                x.Status,
                x.CompanyId

            }).ToList();
            if (aclRoles.Any())
            {
                AclResponse.Message = MessageResponse.fetchMessage;
            }
            AclResponse.Data = aclRoles;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;

            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclRoleRequest request)
        {
            var aclRole = PrepareInputData(request);
            AclResponse.Data = Add(aclRole);
            AclResponse.Message = MessageResponse.createMessage;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = Find(id);

            if (aclRole == null)
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
                AclResponse.StatusCode = AppStatusCode.NOTFOUND;
                return AclResponse;
            }

            aclRole = PrepareInputData(request, aclRole);
            _dbContext.AclRoles.Update(aclRole);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclRole).Reload();
            List<ulong>? userIds = _aclUserRepository?.GetUserIdByChangePermission(null, null, null, id);
            if (userIds.Count() > 0)
            {
                _aclUserRepository.UpdateUserPermissionVersion(userIds);
            }
            AclResponse.Data = aclRole;
            AclResponse.Message = MessageResponse.editMessage;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            return AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclRole = Find(id);
            AclResponse.Data = aclRole;
            AclResponse.Message = MessageResponse.fetchMessage;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            if (aclRole == null)
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
                AclResponse.StatusCode = AppStatusCode.NOTFOUND;
            }
            return AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclRole = Find(id);

            if (aclRole != null && !RoleIdNotToDelete(id))
            {
                AclResponse.Data = Delete(id);
                AclResponse.Message = MessageResponse.deleteMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, null, id);
                _aclUserRepository.UpdateUserPermissionVersion(userIds);
            }

            return AclResponse;

        }
        private AclRole PrepareInputData(AclRoleRequest request, AclRole? aclRole = null)
        {
            if (aclRole == null)
            {
                aclRole = new AclRole();
                aclRole.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclRole.CreatedAt = DateTime.Now;
            }
            aclRole.Title = ExistByTitle(aclRole.Id, request.Title);
            aclRole.Name = ExistByName(aclRole.Id, request.Name);
            aclRole.Status = request.Status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }
    }
}
