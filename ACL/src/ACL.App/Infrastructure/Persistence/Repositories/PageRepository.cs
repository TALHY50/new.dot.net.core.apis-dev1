using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Domain.Entities;
using ACL.App.Infrastructure.Auth.Auth;
using ACL.App.Infrastructure.Persistence.Context;

namespace ACL.App.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class PageRepository : IPageRepository
    {
        private readonly IPageRouteRepository _routeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public PageRepository(ApplicationDbContext dbContext, IPageRouteRepository routeRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            this._routeRepository = routeRepository;
            this._userRepository = userRepository;
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
        }

        /// <inheritdoc/>
        public void DeletePageRouteByPageId(ulong pageId)
        {
            this._routeRepository.DeleteAllByPageId(pageId);
        }
        /// <inheritdoc/>
        public List<Page>? All()
        {
            try
            {
                return this._dbContext.AclPages.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Page? Find(ulong id)
        {
            try
            {
                return this._dbContext.AclPages.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Add(Page page)
        {
            try
            {
                this._dbContext.AclPages.Add(page);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(page).ReloadAsync();
                return page;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Update(Page page)
        {
            try
            {
                this._dbContext.AclPages.Update(page);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(page).ReloadAsync();
                return page;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Delete(Page page)
        {
            try
            {
                this._dbContext.AclPages.Remove(page);
                this._dbContext.SaveChangesAsync();
                return page;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Delete(ulong id)
        {
            try
            {
                var delete = this._dbContext.AclPages.Find(id);
                if (delete != null)
                    this._dbContext.AclPages.Remove(delete);
                this._dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsAclPageIdExist(ulong id)
        {
            return this._dbContext.AclPages.Any(x => x.Id == id);
        }

        public bool IsModuleIdExist(ulong id)
        {
            return this._dbContext.AclModules.Any(x => x.Id == id);
        }

        public bool IsSubModuleIdExist(ulong id)
        {
            return this._dbContext.AclSubModules.Any(x => x.Id == id);
        }
        public bool IsExist(ulong id)
        {
            return this._dbContext.AclPages.Any(i => i.Id == id);
        }
    }
}
