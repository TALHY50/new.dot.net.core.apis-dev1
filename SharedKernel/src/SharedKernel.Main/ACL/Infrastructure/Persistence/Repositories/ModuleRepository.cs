using Microsoft.AspNetCore.Http;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Domain.Entities;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Auth;

namespace SharedKernel.Main.ACL.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class ModuleRepository : IModuleRepository
    {
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public static IHttpContextAccessor HttpContextAccessor;

        /// <inheritdoc/>
        public ModuleRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
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
        public Module? Find(ulong id)
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
        public Module? Delete(ulong id)
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
