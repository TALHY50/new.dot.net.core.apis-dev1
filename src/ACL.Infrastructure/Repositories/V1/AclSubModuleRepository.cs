using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.UseCases.Interfaces.Repositories.V1;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclSubModuleRepository : IAclSubModuleRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private readonly string modelName = "Sub Module";
        readonly ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclSubModuleRepository(ApplicationDbContext dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclSubModules = _dbContext.AclSubModules
                .Join(_dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
                {
                    submodule = sm,
                    module = m

                }).ToList();
            if (aclSubModules.Count != 0)
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclSubModules;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclSubModuleRequest request)
        {
            var aclSubModule = PrepareInputData(request);
            this.aclResponse.Data = Add(aclSubModule); ;
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = Find(id);
            if (aclSubModule == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }
            aclSubModule = PrepareInputData(request, aclSubModule);
            this.aclResponse.Data = Update(aclSubModule);
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclSubModule = All().Where(x => x.Id == id)
               .Join(_dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
               {
                   submodule = sm,
                   module = m

               }).FirstOrDefault();
            this.aclResponse.Data = aclSubModule;
            this.aclResponse.Message = this.messageResponse.fetchMessage;
            if (aclSubModule == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
            }
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var subModule = Find(id);

            if (subModule != null)
            {
                this.aclResponse.Data = Delete(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

        }
        /// <inheritdoc/>
        public bool ExistById(ulong? id, ulong value)
        {
            if (id > 0)
            {
                return _dbContext.AclSubModules.Any(x => x.Id == value && x.Id != id);
            }
            return _dbContext.AclSubModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(ulong id, string name)
        {
            if (id > 0)
            {
                return _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower());
        }
        private static AclSubModule PrepareInputData(AclSubModuleRequest request, AclSubModule aclSubModule = null)
        {
            if (aclSubModule == null)
            {
                aclSubModule = new AclSubModule();
                aclSubModule.Id = request.Id;
                aclSubModule.CreatedAt = DateTime.Now;
            }
            aclSubModule.ModuleId = request.ModuleId;
            aclSubModule.Name = request.Name;
            aclSubModule.ControllerName = request.ControllerName;
            aclSubModule.DefaultMethod = request.DefaultMethod;
            aclSubModule.DisplayName = request.DisplayName;
            aclSubModule.Icon = request.Icon;
            aclSubModule.Sequence = request.Sequence;
            aclSubModule.UpdatedAt = DateTime.Now;
            return aclSubModule;
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
                return null;
            }

        }
        /// <inheritdoc/>
        public AclSubModule? Find(ulong id)
        {
            try
            {
                return _dbContext.AclSubModules.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclSubModule? Add(AclSubModule aclSubModule)
        {
            try
            {
                _dbContext.AclSubModules.Add(aclSubModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclSubModule).Reload();
                return aclSubModule;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclSubModule? Update(AclSubModule aclSubModule)
        {
            try
            {
                _dbContext.AclSubModules.Update(aclSubModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclSubModule).Reload();
                return aclSubModule;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclSubModule? Delete(AclSubModule aclSubModule)
        {
            try
            {
                _dbContext.AclSubModules.Remove(aclSubModule);
                _dbContext.SaveChanges();
                return aclSubModule;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclSubModule? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                _dbContext.AclSubModules.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
