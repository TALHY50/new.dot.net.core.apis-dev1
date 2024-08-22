using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Module;
using SharedKernel.Main.Domain.ACL.Domain.Module;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Module
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class AclSubModuleRepository : IAclSubModuleRepository
    {
        
        readonly AclApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        private enum SubModuleIds : ulong { _2001 = 2001, _2020 = 2020, _2021 = 2021, _2022 = 2022, _2050 = 2050, _2051 = 2051, _2052 = 2052, _2053 = 2053, _2054 = 2054, _2055 = 2055 };
        /// <inheritdoc/>
        public AclSubModuleRepository(AclApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._aclUserRepository = aclUserRepository;
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
       
        /// <inheritdoc/>
        public bool SubModuleIdNotToDelete(ulong submoduleId)
        {
            bool exists = Enum.IsDefined(typeof(SubModuleIds), submoduleId);
            if (exists)
            {
                throw new InvalidOperationException("Id not to delete.");
            }
            return exists;
        }

        /// <inheritdoc/>
        public List<AclSubModule>? All()
        {
            try
            {
                return this._dbContext.AclSubModules.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclSubModule? Find(ulong id)
        {
            return this._dbContext.AclSubModules.Find(id);
        }
        /// <inheritdoc/>
        public AclSubModule? Add(AclSubModule aclSubModule)
        {

            this._dbContext.AclSubModules.Add(aclSubModule);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclSubModule).Reload();
            return aclSubModule;

        }
        /// <inheritdoc/>
        public AclSubModule? Update(AclSubModule aclSubModule)
        {

            this._dbContext.AclSubModules.Update(aclSubModule);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(aclSubModule).Reload();
            return aclSubModule;

        }
        /// <inheritdoc/>
        public AclSubModule? Delete(AclSubModule aclSubModule)
        {

            this._dbContext.AclSubModules.Remove(aclSubModule);
            this._dbContext.SaveChanges();
            return aclSubModule;

        }
        /// <inheritdoc/>
        public AclSubModule? Delete(ulong id)
        {
            var delete = Find(id);
            this._dbContext.AclSubModules.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;
        }

        /// <inheritdoc/>
        public string ExistByName(ulong? id, string name)
        {
            var valid = this._dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = this._dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            if (valid)
            {
                throw new InvalidOperationException("Submodule Name does not unique.");
            }
            return name;
        }
        /// <inheritdoc/>
        public ulong ModuleIdExist(ulong moduleId)
        {
            var valid = this._dbContext.AclModules.Any(x => x.Id == moduleId);

            if (!valid)
            {
                throw new Exception("Module Id does not exist.");
            }

            return moduleId;
        }


    }
}
