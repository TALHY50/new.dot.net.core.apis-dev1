using ACL.Application.Domain.Module;
using ACL.Application.Domain.Ports.Repositories.Auth;
using ACL.Application.Domain.Ports.Repositories.Module;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace ACL.Application.Infrastructure.Persistence.Repositories.Module
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
            _dbContext = dbContext;
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            _aclUserRepository = aclUserRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }

        /// <inheritdoc/>

        public bool ExistById(ulong? id, ulong value)
        {
            if (id > 0)
            {
                return _dbContext.AclModules.Any(x => x.Id == value && x.Id != id);
            }
            return _dbContext.AclModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(ulong id, string name)
        {
            if (id > 0)
            {
                return _dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return _dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower());
        }

        /// <inheritdoc/>
        public List<AclModule>? All()
        {
            try
            {
                return _dbContext.AclModules.ToList();
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
                return _dbContext.AclModules.Find(id);
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
                _dbContext.AclModules.Add(aclModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclModule).ReloadAsync();
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
                _dbContext.AclModules.Update(aclModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclModule).ReloadAsync();
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
                _dbContext.AclModules.Remove(aclModule);
                _dbContext.SaveChanges();
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
                _dbContext.AclModules.Remove(delete);
                _dbContext.SaveChangesAsync();
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
                return _dbContext.AclModules.Any(i => i.Id == id);
            }
            else
            {
                return _dbContext.AclModules.Any(i => i.Id == id && i.Id != requestId);
            }
        }
        public bool IsModuleNameAlreadyExist(string name, ulong? requestId = null)
        {
            if (requestId == null)
            {
                return _dbContext.AclModules.Any(i => i.Name == name);
            }
            else
            {
                return _dbContext.AclModules.Any(i => i.Name == name && i.Id != requestId);
            }
        }
    }
}
