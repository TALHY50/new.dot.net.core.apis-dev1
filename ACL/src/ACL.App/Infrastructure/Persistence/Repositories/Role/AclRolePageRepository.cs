using ACL.App.Domain.Module;
using ACL.App.Domain.Ports.Repositories.Auth;
using ACL.App.Domain.Ports.Repositories.Module;
using ACL.App.Domain.Ports.Repositories.Role;
using ACL.App.Domain.Role;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Utilities;

namespace ACL.App.Infrastructure.Persistence.Repositories.Role
{
    /// <inheritdoc/>
    public class AclRolePageRepository : IAclRolePageRepository
    {
        /// <inheritdoc/>
        public ApplicationDbContext Context { get; }

        private readonly IAclUserRepository _aclUserRepository;
        private readonly IAclRoleRepository _aclRoleRepository;
        private readonly IAclPageRepository _aclPageRepository;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclRolePageRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor, IAclRoleRepository aclRoleRepository, IAclPageRepository aclPageRepository)
        {
            this._aclUserRepository = aclUserRepository;
            this._aclRoleRepository = aclRoleRepository;
            this._aclPageRepository = aclPageRepository;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.
            Context = dbContext;
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, Context);
            AppAuth.SetAuthInfo(ContextAccessor);
        }
        /// <inheritdoc/>
        public List<AclRolePage>? All()
        {
            try
            {
                return Context.AclRolePages.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclRolePage? Find(ulong id)
        {
            try
            {
                return Context.AclRolePages.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclRolePage? Add(AclRolePage aclRolePage)
        {
            try
            {
                Context.AclRolePages.Add(aclRolePage);
                Context.SaveChanges();
                Context.Entry(aclRolePage).ReloadAsync();
                return aclRolePage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclRolePage? Update(AclRolePage aclRolePage)
        {
            try
            {
                Context.AclRolePages.Update(aclRolePage);
                Context.SaveChanges();
                Context.Entry(aclRolePage).ReloadAsync();
                return aclRolePage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclRolePage? Delete(AclRolePage aclRolePage)
        {
            try
            {
                Context.AclRolePages.Remove(aclRolePage);
                Context.SaveChangesAsync();
                return aclRolePage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPageRoute? Delete(ulong id)
        {
            try
            {
                var delete = Context.AclPageRoutes.Find(id);
                Context.AclPageRoutes.Remove(delete);
                Context.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclRolePage[]? AddAll(AclRolePage[] aclRolePages)
        {
            try
            {
                Context.AclRolePages.AddRange(aclRolePages);
                Context.SaveChanges();
                return aclRolePages;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclRolePage[]? DeleteAll(AclRolePage[] aclRolePages)
        {
            try
            {
                Context.AclRolePages.RemoveRange(aclRolePages);
                Context.SaveChanges();
                return aclRolePages;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclRolePage[]? DeleteAllByRoleId(ulong roleId)
        {
            try
            {
                var rolePagesToDelete = Context.AclRolePages.Where(rp => rp.RoleId == roleId);
                Context.AclRolePages.RemoveRange(rolePagesToDelete);
                Context.SaveChanges();
                return rolePagesToDelete.ToArray();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
