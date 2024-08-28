using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Domain.Entities;
using ACL.App.Infrastructure.Auth.Auth;
using ACL.App.Infrastructure.Persistence.Context;

namespace ACL.App.Infrastructure.Persistence.Repositories
{
      
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        private enum RoleIds : ulong { super_super_admin = 1, ADMIN_ROLE = 2  };
        public RoleRepository(ApplicationDbContext dbContext,IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._userRepository = userRepository;
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
        public Role? Delete(ulong id)
        {
            var delete = this._dbContext.AclRoles.Find(id);
            this._dbContext.AclRoles.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;
        }
        /// <inheritdoc/>
        public List<Role>? All()
        {

            return Queryable.Where(this._dbContext.AclRoles, x=>x.CompanyId == AppAuth.GetAuthInfo().CompanyId).ToList();

        }
        /// <inheritdoc/>
        public Role? Find(ulong id)
        {
            return Queryable.Where(this._dbContext.AclRoles, x=>x.Id == id && x.CompanyId == AppAuth.GetAuthInfo().CompanyId).FirstOrDefault();

        }
        /// <inheritdoc/>
        public Role? Add(Role role)
        {

            this._dbContext.AclRoles.Add(role);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(role).ReloadAsync();
            return role;

        }
        /// <inheritdoc/>
        public Role? Update(Role role)
        {

            this._dbContext.AclRoles.Update(role);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(role).Reload();
            return role;

        }
        /// <inheritdoc/>
        public Role? Delete(Role role)
        {

            this._dbContext.AclRoles.Remove(role);
            this._dbContext.SaveChangesAsync();
            return role;

        }

        public bool IsExist(ulong id)
        {
            return  Queryable.Any(this._dbContext.AclRoles, x => x.Id == id && x.CompanyId == AppAuth.GetAuthInfo().CompanyId); 
        }
    }
}
