using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
    /// <inheritdoc/>
    public class SubModuleRepository :EfRepository<SubModule>, ISubModuleRepository
    {
        
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        private enum SubModuleIds : uint { _2001 = 2001, _2020 = 2020, _2021 = 2021, _2022 = 2022, _2050 = 2050, _2051 = 2051, _2052 = 2052, _2053 = 2053, _2054 = 2054, _2055 = 2055 };
        /// <inheritdoc/>
        public SubModuleRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) :base(dbContext)
        {
            this._userRepository = userRepository;
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
       
        /// <inheritdoc/>
        public bool SubModuleIdNotToDelete(uint submoduleId)
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
        public SubModule? Find(uint id)
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
        public SubModule? Delete(uint id)
        {
            var delete = Find(id);
            this._dbContext.AclSubModules.Remove(delete);
            this._dbContext.SaveChanges();
            return delete;
        }


        /// <inheritdoc/>
        public bool ModuleIdExist(uint moduleId)
        {
            return this._dbContext.AclModules.Any(x => x.Id == moduleId);
        }

        public bool ExistById(uint? id, uint value)
        {
            if (id > 0)
            {
                return this._dbContext.AclSubModules.Any(x => x.Id == value && x.Id != id);
            }
            return this._dbContext.AclSubModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(uint? id, string name)
        {
            if (id > 0)
            {
                return this._dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return this._dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower());
        }


    }
}
