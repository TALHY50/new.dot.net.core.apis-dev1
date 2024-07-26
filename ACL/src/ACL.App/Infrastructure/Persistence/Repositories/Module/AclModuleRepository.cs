using ACL.App.Domain.Module;
using ACL.App.Domain.Ports.Repositories.Auth;
using ACL.App.Domain.Ports.Repositories.Module;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Utilities;

namespace ACL.App.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclModuleRepository : IAclModuleRepository
    {
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        public static IHttpContextAccessor HttpContextAccessor;

        /// <inheritdoc/>
        public AclModuleRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this._aclUserRepository = aclUserRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }

        /// <inheritdoc/>

        public bool ExistById(ulong? id, ulong value)
        {
            if (id > 0)
            {
                return this._dbContext.AclModules.Any(x => x.Id == value && x.Id != id);
            }
            return this._dbContext.AclModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(ulong id, string name)
        {
            if (id > 0)
            {
                return this._dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return this._dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower());
        }

        /// <inheritdoc/>
        public List<AclModule>? All()
        {
            try
            {
                return this._dbContext.AclModules.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclModule? Find(ulong id)
        {
            try
            {
                return this._dbContext.AclModules.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclModule? Add(AclModule aclModule)
        {
            try
            {
                this._dbContext.AclModules.Add(aclModule);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclModule).ReloadAsync();
                return aclModule;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclModule? Update(AclModule aclModule)
        {
            try
            {
                this._dbContext.AclModules.Update(aclModule);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclModule).ReloadAsync();
                return aclModule;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclModule? Delete(AclModule aclModule)
        {
            try
            {
                this._dbContext.AclModules.Remove(aclModule);
                this._dbContext.SaveChanges();
                return aclModule;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclModule? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                this._dbContext.AclModules.Remove(delete);
                this._dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsModuleIdAlreadyExist(ulong id, ulong? requestId = null)
        {
            if (requestId == null)
            {
                return this._dbContext.AclModules.Any(i => i.Id == id);
            }
            else
            {
                return this._dbContext.AclModules.Any(i => i.Id == id && i.Id != requestId);
            }
        }
        public bool IsModuleNameAlreadyExist(string name, ulong? requestId = null)
        {
            if (requestId == null)
            {
                return this._dbContext.AclModules.Any(i => i.Name == name);
            }
            else
            {
                return this._dbContext.AclModules.Any(i => i.Name == name && i.Id != requestId);
            }
        }
    }
}
