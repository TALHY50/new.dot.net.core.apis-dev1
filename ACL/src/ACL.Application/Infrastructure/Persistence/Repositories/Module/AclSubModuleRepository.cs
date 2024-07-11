using Notification.Application.Domain.Module;
using Notification.Application.Domain.Ports.Repositories.Auth;
using Notification.Application.Domain.Ports.Repositories.Module;
using Notification.Application.Infrastructure.Persistence.Configurations;
using Notification.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace ACL.Application.Infrastructure.Persistence.Repositories.Module
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class AclSubModuleRepository : IAclSubModuleRepository
    {
        
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        private enum SubModuleIds : ulong { _2001 = 2001, _2020 = 2020, _2021 = 2021, _2022 = 2022, _2050 = 2050, _2051 = 2051, _2052 = 2052, _2053 = 2053, _2054 = 2054, _2055 = 2055 };
        /// <inheritdoc/>
        public AclSubModuleRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
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
                return _dbContext.AclSubModules.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclSubModule? Find(ulong id)
        {
            return _dbContext.AclSubModules.Find(id);
        }
        /// <inheritdoc/>
        public AclSubModule? Add(AclSubModule aclSubModule)
        {

            _dbContext.AclSubModules.Add(aclSubModule);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclSubModule).Reload();
            return aclSubModule;

        }
        /// <inheritdoc/>
        public AclSubModule? Update(AclSubModule aclSubModule)
        {

            _dbContext.AclSubModules.Update(aclSubModule);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclSubModule).Reload();
            return aclSubModule;

        }
        /// <inheritdoc/>
        public AclSubModule? Delete(AclSubModule aclSubModule)
        {

            _dbContext.AclSubModules.Remove(aclSubModule);
            _dbContext.SaveChanges();
            return aclSubModule;

        }
        /// <inheritdoc/>
        public AclSubModule? Delete(ulong id)
        {
            var delete = Find(id);
            _dbContext.AclSubModules.Remove(delete);
            _dbContext.SaveChanges();
            return delete;
        }

        /// <inheritdoc/>
        public string ExistByName(ulong? id, string name)
        {
            var valid = _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
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
            var valid = _dbContext.AclModules.Any(x => x.Id == moduleId);

            if (!valid)
            {
                throw new Exception("Module Id does not exist.");
            }

            return moduleId;
        }


    }
}
