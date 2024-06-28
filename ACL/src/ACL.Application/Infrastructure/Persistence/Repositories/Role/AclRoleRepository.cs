using ACL.Application.Domain.Ports.Repositories.Auth;
using ACL.Application.Domain.Ports.Repositories.Role;
using ACL.Application.Domain.Role;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace ACL.Application.Infrastructure.Persistence.Repositories.Role
{
      
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class AclRoleRepository : IAclRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        private enum RoleIds : ulong { super_super_admin = 1, ADMIN_ROLE = 2  };
        public AclRoleRepository(ApplicationDbContext dbContext,IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }

        /// <inheritdoc/>
        public bool RoleIdNotToDelete(ulong roleId)
        {
            bool exists = Enum.IsDefined(typeof(RoleIds), roleId);
            if (exists)
            {
                throw new Exception("Id not to delete.");
            }
            return exists;
        }

        /// <inheritdoc/>
        public string ExistByName(ulong? id, string name)
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
        public string ExistByTitle(ulong? id, string title)
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
