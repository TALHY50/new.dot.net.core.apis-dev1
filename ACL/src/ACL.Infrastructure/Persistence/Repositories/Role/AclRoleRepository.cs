
using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Role;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Role
{
      
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class AclRoleRepository : IAclRoleRepository
    {
        public AclResponse AclResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role";
        private readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        private enum RoleIds : ulong { super_super_admin = 1, ADMIN_ROLE = 2  };
        public AclRoleRepository(ApplicationDbContext dbContext,IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
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
            var aclRole = Find(id) ;

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
            aclRole.Title = ExistByTitle(aclRole.Id,request.Title);
            aclRole.Name = ExistByName(aclRole.Id,request.Name);
            aclRole.Status = request.Status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }

        /// <inheritdoc/>
        private bool RoleIdNotToDelete(ulong roleId)
        {
            bool exists = Enum.IsDefined(typeof(RoleIds), roleId);
            if (exists)
            {
                throw new Exception("Id not to delete.");
            }
            return exists;
        }

        /// <inheritdoc/>
        private string ExistByName(ulong? id, string name)
        {
            var valid = _dbContext.AclRoles.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = _dbContext.AclRoles.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            if (valid)
            {
                throw new InvalidOperationException("Name does not unique.");
            }
            return name;
        }
        /// <inheritdoc/>
        private string ExistByTitle(ulong? id, string title)
        {
            var valid = _dbContext.AclRoles.Any(x => x.Title.ToLower() == title.ToLower());
            if (id > 0)
            {
                valid = _dbContext.AclRoles.Any(x => x.Title.ToLower() == title.ToLower() && x.Id != id);
            }
            if (valid)
            {
                throw new Exception("Name does not unique.");
            }
            return title;
        }

        /// <inheritdoc/>
        public AclRole? Delete(ulong id)
        {
            var delete = _dbContext.AclRoles.Find(id);
            _dbContext.AclRoles.Remove(delete);
            _dbContext.SaveChanges();
            return delete;
        }
        /// <inheritdoc/>
        public List<AclRole>? All()
        {

            return _dbContext.AclRoles.Where(x=>x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();

        }
        /// <inheritdoc/>
        public AclRole? Find(ulong id)
        {
            return _dbContext.AclRoles.Where(x=>x.Id == id && x.CompanyId == AppAuth.GetAuthInfo().CompanyId).FirstOrDefault();

        }
        /// <inheritdoc/>
        public AclRole? Add(AclRole aclRole)
        {

            _dbContext.AclRoles.Add(aclRole);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclRole).ReloadAsync();
            return aclRole;

        }
        /// <inheritdoc/>
        public AclRole? Update(AclRole aclRole)
        {

            _dbContext.AclRoles.Update(aclRole);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclRole).Reload();
            return aclRole;

        }
        /// <inheritdoc/>
        public AclRole? Delete(AclRole aclRole)
        {

            _dbContext.AclRoles.Remove(aclRole);
            _dbContext.SaveChangesAsync();
            return aclRole;

        }

        public bool IsExist(ulong id)
        {
            return  _dbContext.AclRoles.Any(x => x.Id == id && x.CompanyId == AppAuth.GetAuthInfo().CompanyId); 
        }
    }
}
