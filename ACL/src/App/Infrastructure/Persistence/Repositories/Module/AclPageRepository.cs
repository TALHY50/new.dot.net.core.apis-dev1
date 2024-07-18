using App.Domain.Module;
using App.Domain.Ports.Repositories.Auth;
using App.Domain.Ports.Repositories.Module;
using App.Infrastructure.Persistence.Configurations;
using App.Infrastructure.Utilities;

namespace App.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclPageRepository : IAclPageRepository
    {
        private readonly IAclPageRouteRepository _routeRepository;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclPageRepository(ApplicationDbContext dbContext, IAclPageRouteRepository routeRepository, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            this._routeRepository = routeRepository;
            this._aclUserRepository = aclUserRepository;
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
        public List<AclPage>? All()
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
        public AclPage? Find(ulong id)
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
        public AclPage? Add(AclPage aclPage)
        {
            try
            {
                this._dbContext.AclPages.Add(aclPage);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclPage).ReloadAsync();
                return aclPage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPage? Update(AclPage aclPage)
        {
            try
            {
                this._dbContext.AclPages.Update(aclPage);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclPage).ReloadAsync();
                return aclPage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPage? Delete(AclPage aclPage)
        {
            try
            {
                this._dbContext.AclPages.Remove(aclPage);
                this._dbContext.SaveChangesAsync();
                return aclPage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPage? Delete(ulong id)
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
