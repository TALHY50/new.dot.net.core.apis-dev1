using ACL.App.Application.Interfaces.Repositories.Auth;
using ACL.App.Application.Interfaces.Repositories.Role;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Utilities;
using SharedKernel.Main.Domain.ACL.Domain.Role;

namespace ACL.App.Infrastructure.Persistence.Repositories.Role
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
            this._aclUserRepository = aclUserRepository;
            this._dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
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
            var valid = this._dbContext.AclRoles.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = this._dbContext.AclRoles.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
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
            var valid = this._dbContext.AclRoles.Any(x => x.Title.ToLower() == title.ToLower());
            if (id > 0)
            {
                valid = this._dbContext.AclRoles.Any(x => x.Title.ToLower() == title.ToLower() && x.Id != id);
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
            var delete = this._dbContext.AclRoles.Find(id);
            this._dbContext.AclRoles.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;
        }
        /// <inheritdoc/>
        public List<AclRole>? All()
        {

            return this._dbContext.AclRoles.Where(x=>x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();

        }
        /// <inheritdoc/>
        public AclRole? Find(ulong id)
        {
            return this._dbContext.AclRoles.Where(x=>x.Id == id && x.CompanyId == AppAuth.GetAuthInfo().CompanyId).FirstOrDefault();

        }
        /// <inheritdoc/>
        public AclRole? Add(AclRole aclRole)
        {

            this._dbContext.AclRoles.Add(aclRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclRole).ReloadAsync();
            return aclRole;

        }
        /// <inheritdoc/>
        public AclRole? Update(AclRole aclRole)
        {

            this._dbContext.AclRoles.Update(aclRole);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclRole).Reload();
            return aclRole;

        }
        /// <inheritdoc/>
        public AclRole? Delete(AclRole aclRole)
        {

            this._dbContext.AclRoles.Remove(aclRole);
            this._dbContext.SaveChangesAsync();
            return aclRole;

        }

        public bool IsExist(ulong id)
        {
            return  this._dbContext.AclRoles.Any(x => x.Id == id && x.CompanyId == AppAuth.GetAuthInfo().CompanyId); 
        }
    }
}
