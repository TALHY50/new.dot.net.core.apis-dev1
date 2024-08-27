using Microsoft.AspNetCore.Http;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Domain.Entities;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Auth;

namespace SharedKernel.Main.ACL.Infrastructure.Persistence.Repositories
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class SubModuleRepository : ISubModuleRepository
    {
        
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        private enum SubModuleIds : ulong { _2001 = 2001, _2020 = 2020, _2021 = 2021, _2022 = 2022, _2050 = 2050, _2051 = 2051, _2052 = 2052, _2053 = 2053, _2054 = 2054, _2055 = 2055 };
        /// <inheritdoc/>
        public SubModuleRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._userRepository = userRepository;
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
        public List<SubModule>? All()
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
        public SubModule? Find(ulong id)
        {
            return this._dbContext.AclSubModules.Find(id);
        }
        /// <inheritdoc/>
        public SubModule? Add(SubModule subModule)
        {

            this._dbContext.AclSubModules.Add(subModule);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(subModule).Reload();
            return subModule;

        }
        /// <inheritdoc/>
        public SubModule? Update(SubModule subModule)
        {

            this._dbContext.AclSubModules.Update(subModule);
            this._dbContext.SaveChanges();
            this._dbContext.Entry(subModule).Reload();
            return subModule;

        }
        /// <inheritdoc/>
        public SubModule? Delete(SubModule subModule)
        {

            this._dbContext.AclSubModules.Remove(subModule);
            this._dbContext.SaveChanges();
            return subModule;

        }
        /// <inheritdoc/>
        public SubModule? Delete(ulong id)
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
