using Microsoft.AspNetCore.Http;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Domain.Entities;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Auth;

namespace SharedKernel.Main.ACL.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class RolePageRepository : IRolePageRepository
    {
        /// <inheritdoc/>
        public ApplicationDbContext Context { get; }

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPageRepository _pageRepository;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public RolePageRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, IPageRepository pageRepository)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._pageRepository = pageRepository;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.
            Context = dbContext;
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, Context);
            AppAuth.SetAuthInfo(ContextAccessor);
        }
        /// <inheritdoc/>
        public List<RolePage>? All()
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
        public RolePage? Find(ulong id)
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
        public RolePage? Add(RolePage rolePage)
        {
            try
            {
                Context.AclRolePages.Add(rolePage);
                Context.SaveChanges();
                Context.Entry(rolePage).ReloadAsync();
                return rolePage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public RolePage? Update(RolePage rolePage)
        {
            try
            {
                Context.AclRolePages.Update(rolePage);
                Context.SaveChanges();
                Context.Entry(rolePage).ReloadAsync();
                return rolePage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public RolePage? Delete(RolePage rolePage)
        {
            try
            {
                Context.AclRolePages.Remove(rolePage);
                Context.SaveChangesAsync();
                return rolePage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public PageRoute? Delete(ulong id)
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
        public RolePage[]? AddAll(RolePage[] aclRolePages)
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
        public RolePage[]? DeleteAll(RolePage[] aclRolePages)
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
        public RolePage[]? DeleteAllByRoleId(ulong roleId)
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
