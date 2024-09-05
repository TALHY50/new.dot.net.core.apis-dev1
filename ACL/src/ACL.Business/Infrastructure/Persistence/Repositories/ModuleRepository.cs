using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class ModuleRepository : EfRepository<Module>, IModuleRepository
    {
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public static IHttpContextAccessor HttpContextAccessor;

        /// <inheritdoc/>
        public ModuleRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._dbContext = dbContext;
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this._userRepository = userRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }

        /// <inheritdoc/>

        public bool ExistById(uint? id, uint value)
        {
            if (id > 0)
            {
                return this._dbContext.AclModules.Any(x => x.Id == value && x.Id != id);
            }
            return this._dbContext.AclModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(uint? id, string name)
        {
            if (id > 0)
            {
                return this._dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return this._dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower());
        }

        /// <inheritdoc/>
        public List<Module>? All()
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
        public Module? Find(uint id)
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
        public Module? Add(Module aclModule)
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
        public Module? Update(Module aclModule)
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
        public Module? Delete(Module aclModule)
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
        public Module? Delete(uint id)
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

        public bool IsModuleIdAlreadyExist(uint id, uint? requestId = null)
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
        public bool IsModuleNameAlreadyExist(string name, uint? requestId = null)
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
